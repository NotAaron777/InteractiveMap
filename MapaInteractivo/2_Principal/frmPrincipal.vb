Imports System.IO

Public Class frmPrincipal

    Private Const TEXTO_INICIAL As String = "Pase el mouse sobre el mapa para ver los pueblos de cada territorio."


    Private Sub ConectarCaciques(padre As Control)
        For Each ctl As Control In padre.Controls.Cast(Of Control).ToList()
            If TypeOf ctl Is Button AndAlso ctl.Name.StartsWith("btnCacique") Then
                AddHandler ctl.Click, AddressOf Cacique_Click
                ctl.BringToFront()
            End If
            If ctl.HasChildren Then ConectarCaciques(ctl)
        Next
    End Sub
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim recursos As String = Path.Combine(Application.StartupPath, "Recursos")

        ' Mapa en blanco (si no lo pusiste en picMapa.Image desde el diseñador)
        Dim rutaMapa As String = Path.Combine(recursos, "mapa_blanco.png")
        If picMapa.Image Is Nothing AndAlso File.Exists(rutaMapa) Then
            picMapa.Image = Image.FromFile(rutaMapa)
        End If

        ' Colores de la paleta (el blanco no se ve sobre el mapa blanco)
        Dim naranja As Color = Color.FromArgb(242, 140, 40)
        Dim amarillo As Color = Color.FromArgb(244, 196, 48)
        Dim azul As Color = Color.FromArgb(46, 134, 222)
        Dim verde As Color = Color.FromArgb(46, 139, 87)

        ' Territorios: Id, Nombre que se muestra, color, radio de tolerancia (px), PNG(s) de máscara.
        ' Las zonas compartidas se detectan solas porque las máscaras se superponen.
        With ctlTerritorios
            .CarpetaMascaras = Path.Combine(recursos, "Mascaras")
            .Agregar("Miskito", "Miskito", naranja, 0, "miskito.png")
            .Agregar("Mayangna", "Mayangna", azul, 0, "mayangna.png")
            .Agregar("Ulwas", "Ulwas", amarillo, 0, "ulwas.png")
            .Agregar("Rama", "Rama", verde, 0, "rama.png")
            .Agregar("Creole", "Creole", naranja, 8, "creole.png", "rama_creole.png")
            .Agregar("Chorotega", "Chorotega", amarillo, 0, "chorotega.png")
            .Agregar("Matagalpa", "Matagalpa", verde, 0, "matagalpa.png")
            .Agregar("Nahoas", "Nahoas", naranja, 25, "nahoas.png")
            .Agregar("Xiu", "Xiu", azul, 6, "xiu.png")
            .Cargar()
        End With

        ConectarCaciques(Me)
        lblHover.Text = TEXTO_INICIAL
    End Sub

    Private Sub ctlTerritorios_HoverCambiado(sender As Object, e As TerritorioEventArgs) Handles ctlTerritorios.HoverCambiado
        lblHover.Text = If(e.Territorios.Count = 0, TEXTO_INICIAL, e.Nombres)
    End Sub

    Private Sub ctlTerritorios_TerritorioSeleccionado(sender As Object, e As TerritorioEventArgs) Handles ctlTerritorios.TerritorioSeleccionado
        Select Case e.Territorios(0).Id
            Case "Miskito"
                Using f As New frmRegionMiskito()
                    f.ShowDialog(Me)
                End Using
            Case "Mayangna"
                Using f As New frmRegionMayangna()
                    f.ShowDialog(Me)
                End Using
            Case "Ulwas"
                Using f As New frmRegionUlwas()
                    f.ShowDialog(Me)
                End Using
            Case "Rama"
                Using f As New frmRegionRama()
                    f.ShowDialog(Me)
                End Using
            Case "Creole"
                Using f As New frmRegionCreole()
                    f.ShowDialog(Me)
                End Using
            Case "Chorotega"
                Using f As New frmRegionChorotega()
                    f.ShowDialog(Me)
                End Using
            Case "Matagalpa"
                Using f As New frmRegionMatagalpa()
                    f.ShowDialog(Me)
                End Using
            Case "Nahoas"
                Using f As New frmRegionNahoas()
                    f.ShowDialog(Me)
                End Using
            Case "Xiu"
                Using f As New frmRegionXiu()
                    f.ShowDialog(Me)
                End Using
        End Select
    End Sub

    Private Sub Cacique_Click(sender As Object, e As EventArgs)
        Select Case CInt(DirectCast(sender, Button).Tag)
            Case 1
                Using f As New frmCacique01()
                    f.ShowDialog(Me)
                End Using
            Case 2
                Using f As New frmCacique02()
                    f.ShowDialog(Me)
                End Using
            Case 3
                Using f As New frmCacique03()
                    f.ShowDialog(Me)
                End Using
            Case 4
                Using f As New frmCacique04()
                    f.ShowDialog(Me)
                End Using
            Case 5
                Using f As New frmCacique05()
                    f.ShowDialog(Me)
                End Using
            Case 6
                Using f As New frmCacique06()
                    f.ShowDialog(Me)
                End Using
            Case 7
                Using f As New frmCacique07()
                    f.ShowDialog(Me)
                End Using
            Case 8
                Using f As New frmCacique08()
                    f.ShowDialog(Me)
                End Using


        End Select
    End Sub

    Private Sub btnFuentes_Click(sender As Object, e As EventArgs) Handles btnFuentes.Click
        Using f As New frmFuentes()
            f.ShowDialog(Me)
        End Using
    End Sub


End Class
