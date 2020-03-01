<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Server
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.wsk = New Winsock_Orcas.Winsock()
        Me.upBytes = New System.Windows.Forms.Label()
        Me.downBytes = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.tData = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tGun = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'wsk
        '
        Me.wsk.BufferSize = 8192
        Me.wsk.LegacySupport = False
        Me.wsk.LocalPort = 8080
        Me.wsk.MaxPendingConnections = 25
        Me.wsk.Protocol = Winsock_Orcas.WinsockProtocol.Tcp
        Me.wsk.RemoteHost = "localhost"
        Me.wsk.RemotePort = 8080
        '
        'upBytes
        '
        Me.upBytes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.upBytes.Location = New System.Drawing.Point(286, 26)
        Me.upBytes.Name = "upBytes"
        Me.upBytes.Size = New System.Drawing.Size(84, 13)
        Me.upBytes.TabIndex = 23
        Me.upBytes.Text = "0 bytes/s"
        Me.upBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'downBytes
        '
        Me.downBytes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.downBytes.Location = New System.Drawing.Point(289, 44)
        Me.downBytes.Name = "downBytes"
        Me.downBytes.Size = New System.Drawing.Size(81, 13)
        Me.downBytes.TabIndex = 22
        Me.downBytes.Text = "0 bytes/s"
        Me.downBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(8, 3)
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(178, 50)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(60, 20)
        Me.LinkLabel1.TabIndex = 19
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Server: OFF"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel1.UseCompatibleTextRendering = True
        '
        'tData
        '
        Me.tData.Enabled = True
        Me.tData.Interval = 1000
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkArea = New System.Windows.Forms.LinkArea(4, 20)
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 11)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(110, 31)
        Me.LinkLabel2.TabIndex = 31
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "IP: localhost"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel2.UseCompatibleTextRendering = True
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.LinkArea = New System.Windows.Forms.LinkArea(8, 20)
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(12, 42)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(116, 31)
        Me.LinkLabel4.TabIndex = 32
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Puerto: 8080"
        Me.LinkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel4.UseCompatibleTextRendering = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.downBytes)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.upBytes)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(382, 83)
        Me.Panel1.TabIndex = 33
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(382, 0)
        Me.Panel2.TabIndex = 34
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.AutoScrollMargin = New System.Drawing.Size(0, 5)
        Me.Panel3.Location = New System.Drawing.Point(66, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 0)
        Me.Panel3.TabIndex = 31
        '
        'tGun
        '
        Me.tGun.Enabled = True
        Me.tGun.Interval = 5000
        '
        'Server
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(382, 81)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.MinimumSize = New System.Drawing.Size(398, 120)
        Me.Name = "Server"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server - IoGame"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wsk As Winsock_Orcas.Winsock
    Friend WithEvents upBytes As Label
    Friend WithEvents downBytes As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents tData As Timer
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tGun As Timer
End Class
