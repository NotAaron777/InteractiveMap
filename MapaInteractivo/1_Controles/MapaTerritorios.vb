Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

' =====================================================================================
'  MapaTerritorios
'  Control transparente que se coloca ENCIMA del mapa (Dock = Fill dentro de picMapa).
'  - Cada territorio (pueblo) tiene una o varias máscaras PNG con transparencia.
'  - Al mover el mouse detecta, por píxel, TODOS los territorios que cubren ese punto
'    (si dos pueblos comparten zona, devuelve los dos).
'  - Pinta con el ColorHover únicamente lo que está bajo el mouse.
'  - Al hacer clic: si hay un solo territorio lo abre; si hay varios muestra un menú
'    para elegir cuál abrir.
'  Las máscaras deben tener la misma proporción que el mapa; se escalan solas.
' =====================================================================================

''' <summary>Capa de máscara: imagen para pintar + canal alfa para detectar el mouse.</summary>
Friend Class CapaMascara
    Public Imagen As Bitmap
    Public Alfa() As Byte
    Public Ancho As Integer
    Public Alto As Integer
End Class

Public Class TerritorioInfo
    Public Property Id As String
    Public Property Nombre As String
    Public Property ColorHover As Color
    ''' <summary>Tolerancia (en píxeles de la máscara) para territorios muy pequeños.</summary>
    Public Property RadioClic As Integer
    Public Property Archivos As New List(Of String)
    Friend Capas As New List(Of CapaMascara)

    Friend Function Contiene(p As Point, tam As Size) As Boolean
        If tam.Width <= 0 OrElse tam.Height <= 0 Then Return False
        For Each c As CapaMascara In Capas
            Dim mx As Integer = CInt(p.X * c.Ancho / tam.Width)
            Dim my As Integer = CInt(p.Y * c.Alto / tam.Height)
            Dim r As Integer = RadioClic
            For y As Integer = Math.Max(0, my - r) To Math.Min(c.Alto - 1, my + r)
                For x As Integer = Math.Max(0, mx - r) To Math.Min(c.Ancho - 1, mx + r)
                    If c.Alfa(y * c.Ancho + x) > 64 Then Return True
                Next
            Next
        Next
        Return False
    End Function
End Class

Public Class TerritorioEventArgs
    Inherits EventArgs

    Public ReadOnly Property Territorios As List(Of TerritorioInfo)

    Public Sub New(territorios As List(Of TerritorioInfo))
        Me.Territorios = territorios
    End Sub

    ''' <summary>Nombres unidos: "Miskito", "Miskito y Mayangna", "Miskito, Mayangna y Ulwas".</summary>
    Public ReadOnly Property Nombres As String
        Get
            Dim n As List(Of String) = Territorios.Select(Function(t) t.Nombre).ToList()
            If n.Count = 0 Then Return ""
            If n.Count = 1 Then Return n(0)
            Return String.Join(", ", n.Take(n.Count - 1)) & " y " & n(n.Count - 1)
        End Get
    End Property
End Class

Public Class MapaTerritorios
    Inherits Control

    Private ReadOnly _territorios As New List(Of TerritorioInfo)
    Private _hover As New List(Of TerritorioInfo)

    ''' <summary>Se dispara cuando cambia lo que hay bajo el mouse (lista vacía = nada).</summary>
    Public Event HoverCambiado(sender As Object, e As TerritorioEventArgs)
    ''' <summary>Se dispara al elegir un territorio (clic directo o desde el menú).</summary>
    Public Event TerritorioSeleccionado(sender As Object, e As TerritorioEventArgs)

    <Category("Territorios"), Description("Carpeta donde están los PNG de las máscaras.")>
    Public Property CarpetaMascaras As String = ""

    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor Or
                 ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw, True)
        BackColor = Color.Transparent
        TabStop = False
    End Sub

    Private Function EnDiseno() As Boolean
        Return DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime
    End Function

    ''' <summary>Registra un territorio. Se pueden pasar varias máscaras (zonas separadas).</summary>
    Public Sub Agregar(id As String, nombre As String, colorHover As Color,
                       radioClic As Integer, ParamArray archivos() As String)
        Dim t As New TerritorioInfo With {
            .Id = id, .Nombre = nombre, .ColorHover = colorHover, .RadioClic = radioClic}
        t.Archivos.AddRange(archivos)
        _territorios.Add(t)
    End Sub

    ''' <summary>Carga todas las máscaras registradas con Agregar.</summary>
    Public Sub Cargar()
        For Each t As TerritorioInfo In _territorios
            t.Capas.Clear()
            For Each archivo As String In t.Archivos
                Dim ruta As String = Path.Combine(CarpetaMascaras, archivo)
                If Not File.Exists(ruta) Then
                    Throw New FileNotFoundException(
                        "No se encontró la máscara '" & archivo & "' en: " & CarpetaMascaras & vbCrLf &
                        "Copia la carpeta Recursos junto al .exe (en Visual Studio: seleccionar los PNG > " &
                        "Copiar al directorio de salida = Copiar si es posterior).", ruta)
                End If
                t.Capas.Add(CrearCapa(ruta))
            Next
        Next
    End Sub

    Private Shared Function CrearCapa(ruta As String) As CapaMascara
        Dim bmp As Bitmap
        Using fs As FileStream = File.OpenRead(ruta)
            Using tmp As Image = Image.FromStream(fs)
                bmp = New Bitmap(tmp.Width, tmp.Height, PixelFormat.Format32bppArgb)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.DrawImage(tmp, 0, 0, tmp.Width, tmp.Height)
                End Using
            End Using
        End Using

        Dim w As Integer = bmp.Width
        Dim h As Integer = bmp.Height
        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, w, h),
                                              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim stride As Integer = data.Stride
        Dim bytes(stride * h - 1) As Byte
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length)
        bmp.UnlockBits(data)

        Dim alfa(w * h - 1) As Byte
        For y As Integer = 0 To h - 1
            For x As Integer = 0 To w - 1
                alfa(y * w + x) = bytes(y * stride + x * 4 + 3)
            Next
        Next
        Return New CapaMascara With {.Imagen = bmp, .Alfa = alfa, .Ancho = w, .Alto = h}
    End Function

    Private Function TerritoriosEn(p As Point) As List(Of TerritorioInfo)
        Dim res As New List(Of TerritorioInfo)
        For Each t As TerritorioInfo In _territorios
            If t.Contiene(p, ClientSize) Then res.Add(t)
        Next
        Return res
    End Function

    Private Shared Function MismaLista(a As List(Of TerritorioInfo), b As List(Of TerritorioInfo)) As Boolean
        If a.Count <> b.Count Then Return False
        For i As Integer = 0 To a.Count - 1
            If Not Object.ReferenceEquals(a(i), b(i)) Then Return False
        Next
        Return True
    End Function

    Private Sub ActualizarHover(nuevo As List(Of TerritorioInfo))
        If MismaLista(_hover, nuevo) Then Return
        _hover = nuevo
        Cursor = If(nuevo.Count > 0, Cursors.Hand, Cursors.Default)
        Invalidate()
        RaiseEvent HoverCambiado(Me, New TerritorioEventArgs(nuevo))
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If EnDiseno() Then Return
        ActualizarHover(TerritoriosEn(e.Location))
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        ActualizarHover(New List(Of TerritorioInfo))
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)
        If e.Button <> MouseButtons.Left OrElse EnDiseno() Then Return

        Dim hits As List(Of TerritorioInfo) = TerritoriosEn(e.Location)
        If hits.Count = 1 Then
            RaiseEvent TerritorioSeleccionado(Me, New TerritorioEventArgs(hits))
        ElseIf hits.Count > 1 Then
            ' Zona compartida: el usuario elige cuál abrir
            Dim menu As New ContextMenuStrip()
            Dim cab As ToolStripLabel = New ToolStripLabel("Zona compartida. Abrir:")
            cab.Font = New Font(cab.Font, FontStyle.Bold)
            menu.Items.Add(cab)
            menu.Items.Add(New ToolStripSeparator())
            For Each t As TerritorioInfo In hits
                Dim item As New ToolStripMenuItem(t.Nombre) With {.Tag = t}
                AddHandler item.Click,
                    Sub(s As Object, ev As EventArgs)
                        Dim sel As TerritorioInfo = DirectCast(DirectCast(s, ToolStripMenuItem).Tag, TerritorioInfo)
                        RaiseEvent TerritorioSeleccionado(Me, New TerritorioEventArgs(New List(Of TerritorioInfo) From {sel}))
                    End Sub
                menu.Items.Add(item)
            Next
            AddHandler menu.Closed, Sub(s As Object, ev As ToolStripDropDownClosedEventArgs) BeginInvoke(Sub() menu.Dispose())
            menu.Show(Me, e.Location)
        End If
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g As Graphics = pe.Graphics

        If EnDiseno() Then
            Using p As New Pen(Color.FromArgb(242, 140, 40), 2) With {.DashStyle = DashStyle.Dash}
                g.DrawRectangle(p, 1, 1, Width - 3, Height - 3)
            End Using
            TextRenderer.DrawText(g, "MapaTerritorios (capa interactiva)", Font, ClientRectangle,
                                  Color.FromArgb(242, 140, 40),
                                  TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            Return
        End If

        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        For Each t As TerritorioInfo In _hover
            Using ia As New ImageAttributes()
                ' Pinta la forma del PNG con el color del territorio (conserva el alfa)
                Dim cm As New ColorMatrix(New Single()() {
                    New Single() {0, 0, 0, 0, 0},
                    New Single() {0, 0, 0, 0, 0},
                    New Single() {0, 0, 0, 0, 0},
                    New Single() {0, 0, 0, 0.85F, 0},
                    New Single() {t.ColorHover.R / 255.0F, t.ColorHover.G / 255.0F, t.ColorHover.B / 255.0F, 0, 1}})
                ia.SetColorMatrix(cm)
                For Each c As CapaMascara In t.Capas
                    g.DrawImage(c.Imagen, New Rectangle(0, 0, Width, Height),
                                0, 0, c.Ancho, c.Alto, GraphicsUnit.Pixel, ia)
                Next
            End Using
        Next
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            For Each t As TerritorioInfo In _territorios
                For Each c As CapaMascara In t.Capas
                    c.Imagen?.Dispose()
                Next
            Next
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
