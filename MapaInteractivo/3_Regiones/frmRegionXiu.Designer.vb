<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegionXiu
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.picRepresentacion = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.pnlScroll = New System.Windows.Forms.Panel()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.lblPueblos = New System.Windows.Forms.Label()
        Me.txtPueblos = New System.Windows.Forms.TextBox()
        Me.lblIdiomas = New System.Windows.Forms.Label()
        Me.txtIdiomas = New System.Windows.Forms.TextBox()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.lblCultura = New System.Windows.Forms.Label()
        Me.txtCultura = New System.Windows.Forms.TextBox()
        Me.lblGastronomia = New System.Windows.Forms.Label()
        Me.txtGastronomia = New System.Windows.Forms.TextBox()
        Me.lblMedicina = New System.Windows.Forms.Label()
        Me.txtMedicina = New System.Windows.Forms.TextBox()
        Me.lblOrganizacion = New System.Windows.Forms.Label()
        Me.txtOrganizacion = New System.Windows.Forms.TextBox()
        Me.lblResistencia = New System.Windows.Forms.Label()
        Me.txtResistencia = New System.Windows.Forms.TextBox()
        Me.lblDatos = New System.Windows.Forms.Label()
        Me.txtDatos = New System.Windows.Forms.TextBox()
        Me.lblFuentes = New System.Windows.Forms.Label()
        Me.txtFuentes = New System.Windows.Forms.TextBox()
        Me.lblQR = New System.Windows.Forms.Label()
        Me.picQR = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlScroll.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(46, 134, 222)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Size = New System.Drawing.Size(884, 210)
        Me.pnlEncabezado.Controls.Add(Me.picRepresentacion)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblSubtitulo)
        '
        'picRepresentacion
        '
        Me.picRepresentacion.Name = "picRepresentacion"
        Me.picRepresentacion.BackColor = System.Drawing.Color.White
        Me.picRepresentacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picRepresentacion.Location = New System.Drawing.Point(25, 15)
        Me.picRepresentacion.Size = New System.Drawing.Size(180, 180)
        Me.picRepresentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picRepresentacion.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.AutoSize = False
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 22!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(225, 45)
        Me.lblTitulo.Size = New System.Drawing.Size(640, 55)
        Me.lblTitulo.Text = "Xiu"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.AutoSize = False
        Me.lblSubtitulo.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblSubtitulo.Location = New System.Drawing.Point(225, 105)
        Me.lblSubtitulo.Size = New System.Drawing.Size(640, 30)
        Me.lblSubtitulo.Text = "Pueblo / territorio"
        Me.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPie
        '
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(46, 134, 222)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Size = New System.Drawing.Size(884, 55)
        Me.pnlPie.Controls.Add(Me.btnVolver)
        '
        'btnVolver
        '
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(242, 140, 40)
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.FlatAppearance.BorderSize = 0
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.ForeColor = System.Drawing.Color.White
        Me.btnVolver.Location = New System.Drawing.Point(370, 8)
        Me.btnVolver.Size = New System.Drawing.Size(140, 38)
        Me.btnVolver.Text = "Volver al mapa"
        Me.btnVolver.UseVisualStyleBackColor = False
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        '
        'pnlScroll
        '
        Me.pnlScroll.Name = "pnlScroll"
        Me.pnlScroll.AutoScroll = True
        Me.pnlScroll.AutoScrollMargin = New System.Drawing.Size(0, 20)
        Me.pnlScroll.BackColor = System.Drawing.Color.FromArgb(11, 60, 93)
        Me.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScroll.Controls.Add(Me.lblUbicacion)
        Me.pnlScroll.Controls.Add(Me.txtUbicacion)
        Me.pnlScroll.Controls.Add(Me.lblPueblos)
        Me.pnlScroll.Controls.Add(Me.txtPueblos)
        Me.pnlScroll.Controls.Add(Me.lblIdiomas)
        Me.pnlScroll.Controls.Add(Me.txtIdiomas)
        Me.pnlScroll.Controls.Add(Me.lblHistoria)
        Me.pnlScroll.Controls.Add(Me.txtHistoria)
        Me.pnlScroll.Controls.Add(Me.lblCultura)
        Me.pnlScroll.Controls.Add(Me.txtCultura)
        Me.pnlScroll.Controls.Add(Me.lblGastronomia)
        Me.pnlScroll.Controls.Add(Me.txtGastronomia)
        Me.pnlScroll.Controls.Add(Me.lblMedicina)
        Me.pnlScroll.Controls.Add(Me.txtMedicina)
        Me.pnlScroll.Controls.Add(Me.lblOrganizacion)
        Me.pnlScroll.Controls.Add(Me.txtOrganizacion)
        Me.pnlScroll.Controls.Add(Me.lblResistencia)
        Me.pnlScroll.Controls.Add(Me.txtResistencia)
        Me.pnlScroll.Controls.Add(Me.lblDatos)
        Me.pnlScroll.Controls.Add(Me.txtDatos)
        Me.pnlScroll.Controls.Add(Me.lblFuentes)
        Me.pnlScroll.Controls.Add(Me.txtFuentes)
        Me.pnlScroll.Controls.Add(Me.lblQR)
        Me.pnlScroll.Controls.Add(Me.picQR)
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.AutoSize = False
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblUbicacion.Location = New System.Drawing.Point(25, 15)
        Me.lblUbicacion.Size = New System.Drawing.Size(800, 26)
        Me.lblUbicacion.Text = "Ubicación geográfica"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.BackColor = System.Drawing.Color.White
        Me.txtUbicacion.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Multiline = True
        Me.txtUbicacion.Location = New System.Drawing.Point(25, 43)
        Me.txtUbicacion.Size = New System.Drawing.Size(800, 90)
        Me.txtUbicacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUbicacion.Text = "[Agregar información aquí]"
        '
        'lblPueblos
        '
        Me.lblPueblos.Name = "lblPueblos"
        Me.lblPueblos.AutoSize = False
        Me.lblPueblos.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPueblos.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblPueblos.Location = New System.Drawing.Point(25, 150)
        Me.lblPueblos.Size = New System.Drawing.Size(800, 26)
        Me.lblPueblos.Text = "Pueblo(s) originario(s)"
        '
        'txtPueblos
        '
        Me.txtPueblos.Name = "txtPueblos"
        Me.txtPueblos.BackColor = System.Drawing.Color.White
        Me.txtPueblos.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPueblos.Multiline = True
        Me.txtPueblos.Location = New System.Drawing.Point(25, 178)
        Me.txtPueblos.Size = New System.Drawing.Size(800, 90)
        Me.txtPueblos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPueblos.Text = "[Agregar información aquí]"
        '
        'lblIdiomas
        '
        Me.lblIdiomas.Name = "lblIdiomas"
        Me.lblIdiomas.AutoSize = False
        Me.lblIdiomas.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdiomas.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblIdiomas.Location = New System.Drawing.Point(25, 285)
        Me.lblIdiomas.Size = New System.Drawing.Size(800, 26)
        Me.lblIdiomas.Text = "Idioma(s)"
        '
        'txtIdiomas
        '
        Me.txtIdiomas.Name = "txtIdiomas"
        Me.txtIdiomas.BackColor = System.Drawing.Color.White
        Me.txtIdiomas.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdiomas.Multiline = True
        Me.txtIdiomas.Location = New System.Drawing.Point(25, 313)
        Me.txtIdiomas.Size = New System.Drawing.Size(800, 90)
        Me.txtIdiomas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtIdiomas.Text = "[Agregar información aquí]"
        '
        'lblHistoria
        '
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.AutoSize = False
        Me.lblHistoria.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblHistoria.Location = New System.Drawing.Point(25, 420)
        Me.lblHistoria.Size = New System.Drawing.Size(800, 26)
        Me.lblHistoria.Text = "Historia"
        '
        'txtHistoria
        '
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.BackColor = System.Drawing.Color.White
        Me.txtHistoria.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoria.Multiline = True
        Me.txtHistoria.Location = New System.Drawing.Point(25, 448)
        Me.txtHistoria.Size = New System.Drawing.Size(800, 90)
        Me.txtHistoria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHistoria.Text = "[Agregar información aquí]"
        '
        'lblCultura
        '
        Me.lblCultura.Name = "lblCultura"
        Me.lblCultura.AutoSize = False
        Me.lblCultura.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCultura.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblCultura.Location = New System.Drawing.Point(25, 555)
        Me.lblCultura.Size = New System.Drawing.Size(800, 26)
        Me.lblCultura.Text = "Cultura y tradiciones"
        '
        'txtCultura
        '
        Me.txtCultura.Name = "txtCultura"
        Me.txtCultura.BackColor = System.Drawing.Color.White
        Me.txtCultura.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCultura.Multiline = True
        Me.txtCultura.Location = New System.Drawing.Point(25, 583)
        Me.txtCultura.Size = New System.Drawing.Size(800, 90)
        Me.txtCultura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCultura.Text = "[Agregar información aquí]"
        '
        'lblGastronomia
        '
        Me.lblGastronomia.Name = "lblGastronomia"
        Me.lblGastronomia.AutoSize = False
        Me.lblGastronomia.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastronomia.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblGastronomia.Location = New System.Drawing.Point(25, 690)
        Me.lblGastronomia.Size = New System.Drawing.Size(800, 26)
        Me.lblGastronomia.Text = "Gastronomía"
        '
        'txtGastronomia
        '
        Me.txtGastronomia.Name = "txtGastronomia"
        Me.txtGastronomia.BackColor = System.Drawing.Color.White
        Me.txtGastronomia.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGastronomia.Multiline = True
        Me.txtGastronomia.Location = New System.Drawing.Point(25, 718)
        Me.txtGastronomia.Size = New System.Drawing.Size(800, 90)
        Me.txtGastronomia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGastronomia.Text = "[Agregar información aquí]"
        '
        'lblMedicina
        '
        Me.lblMedicina.Name = "lblMedicina"
        Me.lblMedicina.AutoSize = False
        Me.lblMedicina.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedicina.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblMedicina.Location = New System.Drawing.Point(25, 825)
        Me.lblMedicina.Size = New System.Drawing.Size(800, 26)
        Me.lblMedicina.Text = "Medicina tradicional"
        '
        'txtMedicina
        '
        Me.txtMedicina.Name = "txtMedicina"
        Me.txtMedicina.BackColor = System.Drawing.Color.White
        Me.txtMedicina.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedicina.Multiline = True
        Me.txtMedicina.Location = New System.Drawing.Point(25, 853)
        Me.txtMedicina.Size = New System.Drawing.Size(800, 90)
        Me.txtMedicina.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMedicina.Text = "[Agregar información aquí]"
        '
        'lblOrganizacion
        '
        Me.lblOrganizacion.Name = "lblOrganizacion"
        Me.lblOrganizacion.AutoSize = False
        Me.lblOrganizacion.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizacion.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblOrganizacion.Location = New System.Drawing.Point(25, 960)
        Me.lblOrganizacion.Size = New System.Drawing.Size(800, 26)
        Me.lblOrganizacion.Text = "Organización social y autoridades"
        '
        'txtOrganizacion
        '
        Me.txtOrganizacion.Name = "txtOrganizacion"
        Me.txtOrganizacion.BackColor = System.Drawing.Color.White
        Me.txtOrganizacion.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizacion.Multiline = True
        Me.txtOrganizacion.Location = New System.Drawing.Point(25, 988)
        Me.txtOrganizacion.Size = New System.Drawing.Size(800, 90)
        Me.txtOrganizacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOrganizacion.Text = "[Agregar información aquí]"
        '
        'lblResistencia
        '
        Me.lblResistencia.Name = "lblResistencia"
        Me.lblResistencia.AutoSize = False
        Me.lblResistencia.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResistencia.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblResistencia.Location = New System.Drawing.Point(25, 1095)
        Me.lblResistencia.Size = New System.Drawing.Size(800, 26)
        Me.lblResistencia.Text = "Resistencia y legado"
        '
        'txtResistencia
        '
        Me.txtResistencia.Name = "txtResistencia"
        Me.txtResistencia.BackColor = System.Drawing.Color.White
        Me.txtResistencia.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResistencia.Multiline = True
        Me.txtResistencia.Location = New System.Drawing.Point(25, 1123)
        Me.txtResistencia.Size = New System.Drawing.Size(800, 90)
        Me.txtResistencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResistencia.Text = "[Agregar información aquí]"
        '
        'lblDatos
        '
        Me.lblDatos.Name = "lblDatos"
        Me.lblDatos.AutoSize = False
        Me.lblDatos.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatos.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblDatos.Location = New System.Drawing.Point(25, 1230)
        Me.lblDatos.Size = New System.Drawing.Size(800, 26)
        Me.lblDatos.Text = "Datos importantes"
        '
        'txtDatos
        '
        Me.txtDatos.Name = "txtDatos"
        Me.txtDatos.BackColor = System.Drawing.Color.White
        Me.txtDatos.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatos.Multiline = True
        Me.txtDatos.Location = New System.Drawing.Point(25, 1258)
        Me.txtDatos.Size = New System.Drawing.Size(800, 90)
        Me.txtDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDatos.Text = "[Agregar información aquí]"
        '
        'lblFuentes
        '
        Me.lblFuentes.Name = "lblFuentes"
        Me.lblFuentes.AutoSize = False
        Me.lblFuentes.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuentes.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblFuentes.Location = New System.Drawing.Point(25, 1365)
        Me.lblFuentes.Size = New System.Drawing.Size(800, 26)
        Me.lblFuentes.Text = "Fuentes y referencias"
        '
        'txtFuentes
        '
        Me.txtFuentes.Name = "txtFuentes"
        Me.txtFuentes.BackColor = System.Drawing.Color.White
        Me.txtFuentes.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFuentes.Multiline = True
        Me.txtFuentes.Location = New System.Drawing.Point(25, 1393)
        Me.txtFuentes.Size = New System.Drawing.Size(800, 90)
        Me.txtFuentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFuentes.Text = "[Agregar información aquí]"
        '
        'lblQR
        '
        Me.lblQR.Name = "lblQR"
        Me.lblQR.AutoSize = False
        Me.lblQR.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQR.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblQR.Location = New System.Drawing.Point(25, 1500)
        Me.lblQR.Size = New System.Drawing.Size(800, 26)
        Me.lblQR.Text = "Código QR"
        Me.lblQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picQR
        '
        Me.picQR.Name = "picQR"
        Me.picQR.BackColor = System.Drawing.Color.White
        Me.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQR.Location = New System.Drawing.Point(325, 1532)
        Me.picQR.Size = New System.Drawing.Size(180, 180)
        Me.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQR.TabStop = False
        '
        'frmRegionXiu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(11, 60, 93)
        Me.ClientSize = New System.Drawing.Size(884, 700)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Xiu"
        Me.Controls.Add(Me.pnlScroll)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "frmRegionXiu"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlScroll.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents picRepresentacion As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents pnlScroll As System.Windows.Forms.Panel
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPueblos As System.Windows.Forms.Label
    Friend WithEvents txtPueblos As System.Windows.Forms.TextBox
    Friend WithEvents lblIdiomas As System.Windows.Forms.Label
    Friend WithEvents txtIdiomas As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents lblCultura As System.Windows.Forms.Label
    Friend WithEvents txtCultura As System.Windows.Forms.TextBox
    Friend WithEvents lblGastronomia As System.Windows.Forms.Label
    Friend WithEvents txtGastronomia As System.Windows.Forms.TextBox
    Friend WithEvents lblMedicina As System.Windows.Forms.Label
    Friend WithEvents txtMedicina As System.Windows.Forms.TextBox
    Friend WithEvents lblOrganizacion As System.Windows.Forms.Label
    Friend WithEvents txtOrganizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblResistencia As System.Windows.Forms.Label
    Friend WithEvents txtResistencia As System.Windows.Forms.TextBox
    Friend WithEvents lblDatos As System.Windows.Forms.Label
    Friend WithEvents txtDatos As System.Windows.Forms.TextBox
    Friend WithEvents lblFuentes As System.Windows.Forms.Label
    Friend WithEvents txtFuentes As System.Windows.Forms.TextBox
    Friend WithEvents lblQR As System.Windows.Forms.Label
    Friend WithEvents picQR As System.Windows.Forms.PictureBox
End Class
