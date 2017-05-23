Imports OpenTK.Graphics.OpenGL

Public Class clsMaterial
    Private ambient As String    '设置环境光反射材质
    Private diffuse As String    '设置漫反射材质
    Private specular As String   '设置模型镜面光反射率属性
    Private emission As String   '材质的辐射颜色
    Private shininess As String  '镜面指数（光照度）
    Private A(), D(), S(), E(), SH As Single

    Public Sub New(ByVal sA As String, ByVal sD As String, ByVal sS As String, ByVal sE As String, ByVal sSH As String)
        ambient = sA
        diffuse = sD
        specular = sS
        emission = sE
        shininess = sSH
        If ambient <> "" Then A = SplitXML(ambient)
        If diffuse <> "" Then D = SplitXML(diffuse)
        If specular <> "" Then S = SplitXML(specular)
        If emission <> "" Then E = SplitXML(emission)
        If shininess <> "" Then SH = shininess
    End Sub

    Public Sub SetMaterial()
        If ambient <> "" Then GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, A)
        If diffuse <> "" Then GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, D)
        If specular <> "" Then GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, S)
        If emission <> "" Then GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, E)
        If shininess <> "" Then GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, SH)
    End Sub

    Private Function SplitXML(ByVal S As String) As Single()
        Dim stmp() As String = Split(S, ",")
        Dim val(3) As Single
        val(0) = stmp(0) / 255.0
        val(1) = stmp(1) / 255.0
        val(2) = stmp(2) / 255.0
        val(3) = stmp(3) / 255.0
        Return val
    End Function

End Class
