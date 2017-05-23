<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPMArrange
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerLeft = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerLeftButtom = New System.Windows.Forms.SplitContainer()
        Me.Canvas3D = New Controls.UcCanvas3D()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_File_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_File_Append = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_File_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_File_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_File_Exit = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.SplitContainerLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerLeft.Panel2.SuspendLayout()
        Me.SplitContainerLeft.SuspendLayout()
        CType(Me.SplitContainerLeftButtom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerLeftButtom.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(616, 472)
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.SplitContainerLeft)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.Canvas3D)
        Me.SplitContainerMain.Size = New System.Drawing.Size(745, 504)
        Me.SplitContainerMain.SplitterDistance = 329
        Me.SplitContainerMain.TabIndex = 5
        '
        'SplitContainerLeft
        '
        Me.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLeft.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLeft.Name = "SplitContainerLeft"
        Me.SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLeft.Panel2
        '
        Me.SplitContainerLeft.Panel2.Controls.Add(Me.SplitContainerLeftButtom)
        Me.SplitContainerLeft.Size = New System.Drawing.Size(329, 504)
        Me.SplitContainerLeft.SplitterDistance = 142
        Me.SplitContainerLeft.TabIndex = 2
        '
        'SplitContainerLeftButtom
        '
        Me.SplitContainerLeftButtom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLeftButtom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLeftButtom.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLeftButtom.Name = "SplitContainerLeftButtom"
        Me.SplitContainerLeftButtom.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainerLeftButtom.Size = New System.Drawing.Size(329, 358)
        Me.SplitContainerLeftButtom.SplitterDistance = 114
        Me.SplitContainerLeftButtom.TabIndex = 4
        '
        'Canvas3D
        '
        Me.Canvas3D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas3D.Location = New System.Drawing.Point(0, 0)
        Me.Canvas3D.Name = "Canvas3D"
        Me.Canvas3D.Size = New System.Drawing.Size(412, 504)
        Me.Canvas3D.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_File})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(745, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnu_File
        '
        Me.mnu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_File_Clear, Me.mnu_File_Append, Me.ToolStripSeparator1, Me.mnu_File_Remove, Me.mnu_File_Save, Me.ToolStripSeparator2, Me.mnu_File_Exit})
        Me.mnu_File.Name = "mnu_File"
        Me.mnu_File.Size = New System.Drawing.Size(41, 20)
        Me.mnu_File.Text = "文件"
        '
        'mnu_File_Clear
        '
        Me.mnu_File_Clear.Name = "mnu_File_Clear"
        Me.mnu_File_Clear.Size = New System.Drawing.Size(152, 22)
        Me.mnu_File_Clear.Text = "清空"
        '
        'mnu_File_Append
        '
        Me.mnu_File_Append.Name = "mnu_File_Append"
        Me.mnu_File_Append.Size = New System.Drawing.Size(152, 22)
        Me.mnu_File_Append.Text = "添加"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'mnu_File_Remove
        '
        Me.mnu_File_Remove.Name = "mnu_File_Remove"
        Me.mnu_File_Remove.Size = New System.Drawing.Size(152, 22)
        Me.mnu_File_Remove.Text = "删除"
        '
        'mnu_File_Save
        '
        Me.mnu_File_Save.Name = "mnu_File_Save"
        Me.mnu_File_Save.Size = New System.Drawing.Size(152, 22)
        Me.mnu_File_Save.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'mnu_File_Exit
        '
        Me.mnu_File_Exit.Name = "mnu_File_Exit"
        Me.mnu_File_Exit.Size = New System.Drawing.Size(152, 22)
        Me.mnu_File_Exit.Text = "退出"
        '
        'frmPMArrange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 528)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPMArrange"
        Me.Text = "njnuArrange"
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.SplitContainerLeft.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLeft.ResumeLayout(False)
        CType(Me.SplitContainerLeftButtom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLeftButtom.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLeft As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLeftButtom As System.Windows.Forms.SplitContainer
    Friend WithEvents Canvas3D As Controls.UcCanvas3D
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnu_File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_File_Clear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_File_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_File_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_File_Append As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_File_Remove As System.Windows.Forms.ToolStripMenuItem

End Class
