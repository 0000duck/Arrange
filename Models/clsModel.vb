Imports OpenTK.Graphics.OpenGL
Imports Commons

Public Class clsModel

    Public Sub Draw(ByVal Materials As clsMaterials)
        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)
        Materials.SetMaterial(MaterialType.ActiveBox)
        GL.Begin(PrimitiveType.Triangles)
        GL.Vertex3(0, 0, 50)
        GL.Vertex3(50, 0, 0)
        GL.Vertex3(0, 50, 0)
        GL.End()

        Materials.SetMaterial(MaterialType.CommonBox)
        GL.Begin(PrimitiveType.Triangles)
        GL.Vertex3(0, 0, 50)
        GL.Vertex3(0, 50, 0)
        GL.Vertex3(50, 0, 0)
        GL.End()

    End Sub

End Class
