<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Panel2D
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.glCanvas = New OpenTK.GLControl()
        Me.SuspendLayout()
        '
        'GlControl1
        '
        Me.glCanvas.BackColor = System.Drawing.Color.Black
        Me.glCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.glCanvas.Location = New System.Drawing.Point(0, 0)
        Me.glCanvas.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.glCanvas.Name = "GlControl1"
        Me.glCanvas.Size = New System.Drawing.Size(150, 150)
        Me.glCanvas.TabIndex = 0
        Me.glCanvas.VSync = False
        '
        'Panel2D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.glCanvas)
        Me.Name = "Panel2D"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents glCanvas As OpenTK.GLControl
End Class
