Imports OpenTK.Graphics.OpenGL
Imports OpenTK
Imports Controls
Imports Commons
Imports Models

'设计理念：数据在哪，代码就在哪
Public Class frmPMArrange
    Dim Model As clsModel
    Private Sub mnu_File_Append_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_File_Append.Click
        Model = New clsModel
        Canvas3D.Draw()
    End Sub

    Private Sub Canvas3D_DrawGame() Handles Canvas3D.DrawGame
        If Model IsNot Nothing Then
            Model.Draw(Canvas3D.Materials)
        End If
    End Sub


End Class
