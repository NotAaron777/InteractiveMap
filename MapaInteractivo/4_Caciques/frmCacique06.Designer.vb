<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCacique06
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblPueblo = New System.Windows.Forms.Label()
        Me.txtPueblo = New System.Windows.Forms.TextBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.lblTerritorio = New System.Windows.Forms.Label()
        Me.txtTerritorio = New System.Windows.Forms.TextBox()
        Me.lblBiografia = New System.Windows.Forms.Label()
        Me.txtBiografia = New System.Windows.Forms.TextBox()
        Me.lblRol = New System.Windows.Forms.Label()
        Me.txtRol = New System.Windows.Forms.TextBox()
        Me.lblHechos = New System.Windows.Forms.Label()
        Me.txtHechos = New System.Windows.Forms.TextBox()
        Me.lblLegado = New System.Windows.Forms.Label()
        Me.txtLegado = New System.Windows.Forms.TextBox()
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
        Me.lblTitulo.Text = "Nombre del cacique"
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
        Me.lblSubtitulo.Text = "Pueblo / período histórico"
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
        Me.pnlScroll.Controls.Add(Me.lblNombre)
        Me.pnlScroll.Controls.Add(Me.txtNombre)
        Me.pnlScroll.Controls.Add(Me.lblPueblo)
        Me.pnlScroll.Controls.Add(Me.txtPueblo)
        Me.pnlScroll.Controls.Add(Me.lblPeriodo)
        Me.pnlScroll.Controls.Add(Me.txtPeriodo)
        Me.pnlScroll.Controls.Add(Me.lblTerritorio)
        Me.pnlScroll.Controls.Add(Me.txtTerritorio)
        Me.pnlScroll.Controls.Add(Me.lblBiografia)
        Me.pnlScroll.Controls.Add(Me.txtBiografia)
        Me.pnlScroll.Controls.Add(Me.lblRol)
        Me.pnlScroll.Controls.Add(Me.txtRol)
        Me.pnlScroll.Controls.Add(Me.lblHechos)
        Me.pnlScroll.Controls.Add(Me.txtHechos)
        Me.pnlScroll.Controls.Add(Me.lblLegado)
        Me.pnlScroll.Controls.Add(Me.txtLegado)
        Me.pnlScroll.Controls.Add(Me.lblFuentes)
        Me.pnlScroll.Controls.Add(Me.txtFuentes)
        Me.pnlScroll.Controls.Add(Me.lblQR)
        Me.pnlScroll.Controls.Add(Me.picQR)
        '
        'lblNombre
        '
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.AutoSize = False
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblNombre.Location = New System.Drawing.Point(25, 15)
        Me.lblNombre.Size = New System.Drawing.Size(800, 26)
        Me.lblNombre.Text = "Nombre completo y títulos"
        '
        'txtNombre
        '
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Multiline = True
        Me.txtNombre.Location = New System.Drawing.Point(25, 43)
        Me.txtNombre.Size = New System.Drawing.Size(800, 90)
        Me.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombre.Text = "[Agregar información aquí]"
        '
        'lblPueblo
        '
        Me.lblPueblo.Name = "lblPueblo"
        Me.lblPueblo.AutoSize = False
        Me.lblPueblo.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPueblo.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblPueblo.Location = New System.Drawing.Point(25, 150)
        Me.lblPueblo.Size = New System.Drawing.Size(800, 26)
        Me.lblPueblo.Text = "Pueblo al que pertenecía"
        '
        'txtPueblo
        '
        Me.txtPueblo.Name = "txtPueblo"
        Me.txtPueblo.BackColor = System.Drawing.Color.White
        Me.txtPueblo.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPueblo.Multiline = True
        Me.txtPueblo.Location = New System.Drawing.Point(25, 178)
        Me.txtPueblo.Size = New System.Drawing.Size(800, 90)
        Me.txtPueblo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPueblo.Text = "[Agregar información aquí]"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.AutoSize = False
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblPeriodo.Location = New System.Drawing.Point(25, 285)
        Me.lblPeriodo.Size = New System.Drawing.Size(800, 26)
        Me.lblPeriodo.Text = "Período histórico"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.BackColor = System.Drawing.Color.White
        Me.txtPeriodo.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Multiline = True
        Me.txtPeriodo.Location = New System.Drawing.Point(25, 313)
        Me.txtPeriodo.Size = New System.Drawing.Size(800, 90)
        Me.txtPeriodo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPeriodo.Text = "[Agregar información aquí]"
        '
        'lblTerritorio
        '
        Me.lblTerritorio.Name = "lblTerritorio"
        Me.lblTerritorio.AutoSize = False
        Me.lblTerritorio.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerritorio.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblTerritorio.Location = New System.Drawing.Point(25, 420)
        Me.lblTerritorio.Size = New System.Drawing.Size(800, 26)
        Me.lblTerritorio.Text = "Territorio"
        '
        'txtTerritorio
        '
        Me.txtTerritorio.Name = "txtTerritorio"
        Me.txtTerritorio.BackColor = System.Drawing.Color.White
        Me.txtTerritorio.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerritorio.Multiline = True
        Me.txtTerritorio.Location = New System.Drawing.Point(25, 448)
        Me.txtTerritorio.Size = New System.Drawing.Size(800, 90)
        Me.txtTerritorio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTerritorio.Text = "[Agregar información aquí]"
        '
        'lblBiografia
        '
        Me.lblBiografia.Name = "lblBiografia"
        Me.lblBiografia.AutoSize = False
        Me.lblBiografia.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBiografia.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblBiografia.Location = New System.Drawing.Point(25, 555)
        Me.lblBiografia.Size = New System.Drawing.Size(800, 26)
        Me.lblBiografia.Text = "Biografía"
        '
        'txtBiografia
        '
        Me.txtBiografia.Name = "txtBiografia"
        Me.txtBiografia.BackColor = System.Drawing.Color.White
        Me.txtBiografia.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBiografia.Multiline = True
        Me.txtBiografia.Location = New System.Drawing.Point(25, 583)
        Me.txtBiografia.Size = New System.Drawing.Size(800, 90)
        Me.txtBiografia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBiografia.Text = "[Agregar información aquí]"
        '
        'lblRol
        '
        Me.lblRol.Name = "lblRol"
        Me.lblRol.AutoSize = False
        Me.lblRol.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRol.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblRol.Location = New System.Drawing.Point(25, 690)
        Me.lblRol.Size = New System.Drawing.Size(800, 26)
        Me.lblRol.Text = "Rol y liderazgo"
        '
        'txtRol
        '
        Me.txtRol.Name = "txtRol"
        Me.txtRol.BackColor = System.Drawing.Color.White
        Me.txtRol.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRol.Multiline = True
        Me.txtRol.Location = New System.Drawing.Point(25, 718)
        Me.txtRol.Size = New System.Drawing.Size(800, 90)
        Me.txtRol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRol.Text = "[Agregar información aquí]"
        '
        'lblHechos
        '
        Me.lblHechos.Name = "lblHechos"
        Me.lblHechos.AutoSize = False
        Me.lblHechos.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHechos.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblHechos.Location = New System.Drawing.Point(25, 825)
        Me.lblHechos.Size = New System.Drawing.Size(800, 26)
        Me.lblHechos.Text = "Hechos destacados y resistencia"
        '
        'txtHechos
        '
        Me.txtHechos.Name = "txtHechos"
        Me.txtHechos.BackColor = System.Drawing.Color.White
        Me.txtHechos.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHechos.Multiline = True
        Me.txtHechos.Location = New System.Drawing.Point(25, 853)
        Me.txtHechos.Size = New System.Drawing.Size(800, 90)
        Me.txtHechos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHechos.Text = "[Agregar información aquí]"
        '
        'lblLegado
        '
        Me.lblLegado.Name = "lblLegado"
        Me.lblLegado.AutoSize = False
        Me.lblLegado.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegado.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblLegado.Location = New System.Drawing.Point(25, 960)
        Me.lblLegado.Size = New System.Drawing.Size(800, 26)
        Me.lblLegado.Text = "Legado y memoria"
        '
        'txtLegado
        '
        Me.txtLegado.Name = "txtLegado"
        Me.txtLegado.BackColor = System.Drawing.Color.White
        Me.txtLegado.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLegado.Multiline = True
        Me.txtLegado.Location = New System.Drawing.Point(25, 988)
        Me.txtLegado.Size = New System.Drawing.Size(800, 90)
        Me.txtLegado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLegado.Text = "[Agregar información aquí]"
        '
        'lblFuentes
        '
        Me.lblFuentes.Name = "lblFuentes"
        Me.lblFuentes.AutoSize = False
        Me.lblFuentes.Font = New System.Drawing.Font("Segoe UI", 13!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuentes.ForeColor = System.Drawing.Color.FromArgb(244, 196, 48)
        Me.lblFuentes.Location = New System.Drawing.Point(25, 1095)
        Me.lblFuentes.Size = New System.Drawing.Size(800, 26)
        Me.lblFuentes.Text = "Fuentes y referencias"
        '
        'txtFuentes
        '
        Me.txtFuentes.Name = "txtFuentes"
        Me.txtFuentes.BackColor = System.Drawing.Color.White
        Me.txtFuentes.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFuentes.Multiline = True
        Me.txtFuentes.Location = New System.Drawing.Point(25, 1123)
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
        Me.lblQR.Location = New System.Drawing.Point(25, 1230)
        Me.lblQR.Size = New System.Drawing.Size(800, 26)
        Me.lblQR.Text = "Código QR"
        Me.lblQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picQR
        '
        Me.picQR.Name = "picQR"
        Me.picQR.BackColor = System.Drawing.Color.White
        Me.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQR.Location = New System.Drawing.Point(325, 1262)
        Me.picQR.Size = New System.Drawing.Size(180, 180)
        Me.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQR.TabStop = False
        '
        'frmCacique06
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(11, 60, 93)
        Me.ClientSize = New System.Drawing.Size(884, 700)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nombre del cacique"
        Me.Controls.Add(Me.pnlScroll)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "frmCacique06"
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
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblPueblo As System.Windows.Forms.Label
    Friend WithEvents txtPueblo As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents lblTerritorio As System.Windows.Forms.Label
    Friend WithEvents txtTerritorio As System.Windows.Forms.TextBox
    Friend WithEvents lblBiografia As System.Windows.Forms.Label
    Friend WithEvents txtBiografia As System.Windows.Forms.TextBox
    Friend WithEvents lblRol As System.Windows.Forms.Label
    Friend WithEvents txtRol As System.Windows.Forms.TextBox
    Friend WithEvents lblHechos As System.Windows.Forms.Label
    Friend WithEvents txtHechos As System.Windows.Forms.TextBox
    Friend WithEvents lblLegado As System.Windows.Forms.Label
    Friend WithEvents txtLegado As System.Windows.Forms.TextBox
    Friend WithEvents lblFuentes As System.Windows.Forms.Label
    Friend WithEvents txtFuentes As System.Windows.Forms.TextBox
    Friend WithEvents lblQR As System.Windows.Forms.Label
    Friend WithEvents picQR As System.Windows.Forms.PictureBox
End Class
