<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        lblTitulo = New Label()
        picMapa = New PictureBox()
        ctlTerritorios = New MapaTerritorios()
        btnCacique01 = New Button()
        btnCacique02 = New Button()
        btnCacique03 = New Button()
        btnCacique04 = New Button()
        btnCacique05 = New Button()
        btnCacique06 = New Button()
        btnCacique07 = New Button()
        btnCacique08 = New Button()
        btnFuentes = New Button()
        lblHover = New Label()
        CType(picMapa, ComponentModel.ISupportInitialize).BeginInit()
        picMapa.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Font = New Font("Tempus Sans ITC", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.ForeColor = Color.White
        lblTitulo.Image = CType(resources.GetObject("lblTitulo.Image"), Image)
        lblTitulo.ImageAlign = ContentAlignment.MiddleRight
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(1250, 70)
        lblTitulo.TabIndex = 2
        lblTitulo.Text = "Pueblos Originarios y Afrodescendientes de Nicaragua"
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picMapa
        ' 
        picMapa.BackColor = Color.Transparent
        picMapa.Controls.Add(ctlTerritorios)
        picMapa.Location = New Point(265, 80)
        picMapa.Name = "picMapa"
        picMapa.Size = New Size(720, 657)
        picMapa.SizeMode = PictureBoxSizeMode.StretchImage
        picMapa.TabIndex = 1
        picMapa.TabStop = False
        ' 
        ' ctlTerritorios
        ' 
        ctlTerritorios.BackColor = Color.Transparent
        ctlTerritorios.CarpetaMascaras = ""
        ctlTerritorios.Dock = DockStyle.Fill
        ctlTerritorios.Location = New Point(0, 0)
        ctlTerritorios.Name = "ctlTerritorios"
        ctlTerritorios.Size = New Size(720, 657)
        ctlTerritorios.TabIndex = 19
        ctlTerritorios.TabStop = False
        ' 
        ' btnCacique01
        ' 
        btnCacique01.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique01.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique01.Cursor = Cursors.Hand
        btnCacique01.FlatAppearance.BorderColor = Color.White
        btnCacique01.FlatAppearance.BorderSize = 2
        btnCacique01.FlatStyle = FlatStyle.Flat
        btnCacique01.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique01.ForeColor = Color.White
        btnCacique01.Location = New Point(277, 90)
        btnCacique01.Name = "btnCacique01"
        btnCacique01.Size = New Size(63, 58)
        btnCacique01.TabIndex = 0
        btnCacique01.Tag = "1"
        btnCacique01.Text = "1"
        btnCacique01.UseVisualStyleBackColor = False
        ' 
        ' btnCacique02
        ' 
        btnCacique02.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique02.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique02.Cursor = Cursors.Hand
        btnCacique02.FlatAppearance.BorderColor = Color.White
        btnCacique02.FlatAppearance.BorderSize = 2
        btnCacique02.FlatStyle = FlatStyle.Flat
        btnCacique02.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique02.ForeColor = Color.White
        btnCacique02.Location = New Point(277, 154)
        btnCacique02.Name = "btnCacique02"
        btnCacique02.Size = New Size(63, 58)
        btnCacique02.TabIndex = 1
        btnCacique02.Tag = "2"
        btnCacique02.Text = "2"
        btnCacique02.UseVisualStyleBackColor = False
        ' 
        ' btnCacique03
        ' 
        btnCacique03.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique03.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique03.Cursor = Cursors.Hand
        btnCacique03.FlatAppearance.BorderColor = Color.White
        btnCacique03.FlatAppearance.BorderSize = 2
        btnCacique03.FlatStyle = FlatStyle.Flat
        btnCacique03.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique03.ForeColor = Color.White
        btnCacique03.Location = New Point(346, 90)
        btnCacique03.Name = "btnCacique03"
        btnCacique03.Size = New Size(63, 58)
        btnCacique03.TabIndex = 2
        btnCacique03.Tag = "3"
        btnCacique03.Text = "3"
        btnCacique03.UseVisualStyleBackColor = False
        ' 
        ' btnCacique04
        ' 
        btnCacique04.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique04.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique04.Cursor = Cursors.Hand
        btnCacique04.FlatAppearance.BorderColor = Color.White
        btnCacique04.FlatAppearance.BorderSize = 2
        btnCacique04.FlatStyle = FlatStyle.Flat
        btnCacique04.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique04.ForeColor = Color.White
        btnCacique04.Location = New Point(346, 154)
        btnCacique04.Name = "btnCacique04"
        btnCacique04.Size = New Size(63, 58)
        btnCacique04.TabIndex = 3
        btnCacique04.Tag = "4"
        btnCacique04.Text = "4"
        btnCacique04.UseVisualStyleBackColor = False
        ' 
        ' btnCacique05
        ' 
        btnCacique05.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique05.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique05.Cursor = Cursors.Hand
        btnCacique05.FlatAppearance.BorderColor = Color.White
        btnCacique05.FlatAppearance.BorderSize = 2
        btnCacique05.FlatStyle = FlatStyle.Flat
        btnCacique05.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique05.ForeColor = Color.White
        btnCacique05.Location = New Point(415, 90)
        btnCacique05.Name = "btnCacique05"
        btnCacique05.Size = New Size(63, 58)
        btnCacique05.TabIndex = 4
        btnCacique05.Tag = "5"
        btnCacique05.Text = "5"
        btnCacique05.UseVisualStyleBackColor = False
        ' 
        ' btnCacique06
        ' 
        btnCacique06.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique06.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique06.Cursor = Cursors.Hand
        btnCacique06.FlatAppearance.BorderColor = Color.White
        btnCacique06.FlatAppearance.BorderSize = 2
        btnCacique06.FlatStyle = FlatStyle.Flat
        btnCacique06.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique06.ForeColor = Color.White
        btnCacique06.Location = New Point(415, 154)
        btnCacique06.Name = "btnCacique06"
        btnCacique06.Size = New Size(63, 58)
        btnCacique06.TabIndex = 5
        btnCacique06.Tag = "6"
        btnCacique06.Text = "6"
        btnCacique06.UseVisualStyleBackColor = False
        ' 
        ' btnCacique07
        ' 
        btnCacique07.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique07.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique07.Cursor = Cursors.Hand
        btnCacique07.FlatAppearance.BorderColor = Color.White
        btnCacique07.FlatAppearance.BorderSize = 2
        btnCacique07.FlatStyle = FlatStyle.Flat
        btnCacique07.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique07.ForeColor = Color.White
        btnCacique07.Location = New Point(484, 90)
        btnCacique07.Name = "btnCacique07"
        btnCacique07.Size = New Size(63, 58)
        btnCacique07.TabIndex = 6
        btnCacique07.Tag = "7"
        btnCacique07.Text = "7"
        btnCacique07.UseVisualStyleBackColor = False
        ' 
        ' btnCacique08
        ' 
        btnCacique08.BackColor = Color.FromArgb(CByte(46), CByte(134), CByte(222))
        btnCacique08.BackgroundImageLayout = ImageLayout.Zoom
        btnCacique08.Cursor = Cursors.Hand
        btnCacique08.FlatAppearance.BorderColor = Color.White
        btnCacique08.FlatAppearance.BorderSize = 2
        btnCacique08.FlatStyle = FlatStyle.Flat
        btnCacique08.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCacique08.ForeColor = Color.White
        btnCacique08.Location = New Point(484, 154)
        btnCacique08.Name = "btnCacique08"
        btnCacique08.Size = New Size(63, 58)
        btnCacique08.TabIndex = 7
        btnCacique08.Tag = "8"
        btnCacique08.Text = "8"
        btnCacique08.UseVisualStyleBackColor = False
        ' 
        ' btnFuentes
        ' 
        btnFuentes.BackColor = Color.FromArgb(CByte(242), CByte(140), CByte(40))
        btnFuentes.Cursor = Cursors.Hand
        btnFuentes.FlatAppearance.BorderSize = 0
        btnFuentes.FlatStyle = FlatStyle.Flat
        btnFuentes.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFuentes.ForeColor = Color.White
        btnFuentes.Location = New Point(12, 12)
        btnFuentes.Name = "btnFuentes"
        btnFuentes.Size = New Size(149, 45)
        btnFuentes.TabIndex = 2
        btnFuentes.Text = "Fuentes"
        btnFuentes.UseVisualStyleBackColor = False
        ' 
        ' lblHover
        ' 
        lblHover.Font = New Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHover.ForeColor = Color.White
        lblHover.Location = New Point(0, 264)
        lblHover.Name = "lblHover"
        lblHover.Size = New Size(233, 176)
        lblHover.TabIndex = 1
        lblHover.Text = "Pase el mouse sobre el mapa para ver los pueblos de cada territorio."
        lblHover.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(11), CByte(60), CByte(93))
        ClientSize = New Size(1250, 780)
        Controls.Add(btnCacique06)
        Controls.Add(btnCacique05)
        Controls.Add(btnCacique04)
        Controls.Add(btnCacique03)
        Controls.Add(btnCacique07)
        Controls.Add(btnCacique02)
        Controls.Add(btnCacique08)
        Controls.Add(btnCacique01)
        Controls.Add(picMapa)
        Controls.Add(lblHover)
        Controls.Add(btnFuentes)
        Controls.Add(lblTitulo)
        Name = "frmPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Mapa de Pueblos Originarios y Afrodescendientes"
        CType(picMapa, ComponentModel.ISupportInitialize).EndInit()
        picMapa.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents picMapa As System.Windows.Forms.PictureBox
    Friend WithEvents btnCacique01 As System.Windows.Forms.Button
    Friend WithEvents btnCacique02 As System.Windows.Forms.Button
    Friend WithEvents btnCacique03 As System.Windows.Forms.Button
    Friend WithEvents btnCacique04 As System.Windows.Forms.Button
    Friend WithEvents btnCacique05 As System.Windows.Forms.Button
    Friend WithEvents btnCacique06 As System.Windows.Forms.Button
    Friend WithEvents btnCacique07 As System.Windows.Forms.Button
    Friend WithEvents btnCacique08 As System.Windows.Forms.Button
    Friend WithEvents ctlTerritorios As MapaTerritorios
    Friend WithEvents btnFuentes As Button
    Friend WithEvents lblHover As Label
End Class
