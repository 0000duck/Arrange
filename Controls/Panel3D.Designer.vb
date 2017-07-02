<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Panel3D
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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
        Me.glCanvas = New OpenTK.GLControl()
        Me.SuspendLayout()
        '
        'glCanvas
        '
        Me.glCanvas.BackColor = System.Drawing.Color.Black
        Me.glCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.glCanvas.Location = New System.Drawing.Point(0, 0)
        Me.glCanvas.Name = "glCanvas"
        Me.glCanvas.Size = New System.Drawing.Size(150, 150)
        Me.glCanvas.TabIndex = 1
        Me.glCanvas.VSync = False
        '
        'UcCanvas3D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.glCanvas)
        Me.Name = "UcCanvas3D"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents glCanvas As OpenTK.GLControl

End Class
