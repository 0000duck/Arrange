Imports System.Math
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports System.Drawing

Public Class clsOpenGL
    Private Lights As clsLights

    Public Sub New()
        Lights = New clsLights
        Lights.SetLight()
    End Sub

    Public Sub Init()
        GL.Enable(EnableCap.DepthTest)   '打开深度比较开关
        GL.DepthFunc(DepthFunction.Less) 'z值小者可见，解决多个实体之间的遮挡问题

        GL.Enable(EnableCap.Normalize)
        GL.Enable(EnableCap.CullFace)   '剔除与视线方向背离的面，解决单个实体的消隐问题

        GL.Enable(EnableCap.Blend)     '色彩混合开关
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)  '解决透明面的色彩混合

        GL.LineWidth(1)
        GL.Enable(EnableCap.LineSmooth)  '线平滑
        GL.Enable(EnableCap.PolygonSmooth)

        GL.FrontFace(FrontFaceDirection.Ccw)
        GL.Enable(EnableCap.AutoNormal)
        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)

        GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest)

        GL.Enable(EnableCap.Lighting)
        GL.ShadeModel(ShadingModel.Smooth)
        GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest)

        SetProjection3()
    End Sub

    Public Sub Clear(ByVal clrBackground As Color)
        GL.ClearColor(clrBackground) '设置绘图背景色
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.AccumBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)
    End Sub

    Public Sub SetProjection3()
        '透视投影
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()
        Dim nearDist As Single = 0.1, farDist As Single = 10000
        Dim fovy As Single = 16 / 180.0 * PI, aspect As Single = 1
        Dim persp As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(fovy, aspect, nearDist, farDist)
        GL.LoadMatrix(persp)
    End Sub
    Public Sub SetSCS(ByVal SCS As clsVCS3)
        '观察变换
        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
        Dim lookat As Matrix4 = Matrix4.LookAt(SCS.Vp, SCS.Origin, SCS.Up)
        GL.LoadMatrix(lookat)
    End Sub

End Class
