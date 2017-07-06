Imports OpenTK.Graphics.OpenGL
Imports OpenTK
Imports Commons
Imports System.Drawing
Imports Microsoft.VisualBasic.Devices

Public Class Panel2D
    Public Opengl As clsOpenGL         ' 封装了OpenGL的设置和显示流程
    Public ViewCS As clsVCS3           ' 观察坐标系对象
    Public Materials As clsMaterials  ' 材料库的引用
    Private point As Vector2

    Private MousePressed As Boolean, sp As Point  '交互数据

    Public Property MouseLocation As Vector2
        Get
            Return point
        End Get
        Set(value As Vector2)
            point = value
        End Set
    End Property

    Public Event DrawGame()
    Public Event Pick(ByVal x As Integer, ByVal y As Integer)

    Private Sub glCanvas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles glCanvas.Load
        If DesignMode = True Then Exit Sub
        Opengl = New clsOpenGL
        Opengl.Init()
        Materials = New clsMaterials
        Dim GameWidth As Integer = 100   ' 工作空间
        ViewCS = New clsVCS3(New clsBox(-GameWidth / 2, -GameWidth / 2, -GameWidth / 2, GameWidth, GameWidth, GameWidth))
    End Sub

    Private Sub glCanvas_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles glCanvas.MouseDown
        ' 右键：选择
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            RaiseEvent Pick(e.X, e.Y) : Return
        End If

        ' 左键：平移 或 旋转
        Dim kb As New Keyboard
        If kb.ShiftKeyDown = True Then
            MousePressed = True : sp = e.Location
        Else
            MousePressed = True : sp = e.Location
        End If
    End Sub
    Private Sub glCanvas_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles glCanvas.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Right Then Return
        MousePressed = False
    End Sub
    Private Sub glCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles glCanvas.MouseMove
        ' 按住的左键：平移 或 旋转
        Draw()
        point.X = e.X
        point.Y = e.Y
        DrawOnePoint(MouseLocation.X, MouseLocation.Y)
        sp.X = e.X : sp.Y = e.Y
    End Sub
    Private Sub glCanvas_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles glCanvas.MouseWheel
        If Opengl Is Nothing Then Exit Sub
        ViewCS.Zoom(e.Delta / 20)
        Draw()
    End Sub
    Private Sub glCanvas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles glCanvas.Paint
        Draw()
        DrawOnePoint(MouseLocation.X, MouseLocation.Y)
    End Sub
    Private Sub glCanvas_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles glCanvas.SizeChanged
        If Opengl Is Nothing Then Exit Sub
        GL.Viewport(0, 0, glCanvas.Width, glCanvas.Height)      '定义视区
        Draw()
    End Sub

    Public Sub Draw()
        If Opengl Is Nothing Then Return
        Opengl.Clear(Color.Gray) '灰色背景
        Opengl.SetSCS()
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Flush()
        RaiseEvent DrawGame()
        GL.Flush()
        glCanvas.SwapBuffers()
    End Sub

    Public Sub DrawOnePoint(x As Integer, y As Integer)
        If Opengl Is Nothing Then Return
        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill)
        Materials.SetMaterial(MaterialType.ActiveBox)
        GL.Begin(PrimitiveType.LineStrip)
        GL.Vertex2(0, 0)
        GL.Vertex2(50, 50)
        GL.Vertex2(50, 100)
        GL.End()
        ' GL.Flush()
    End Sub

    Public Sub SwapBuffers()
        glCanvas.SwapBuffers()
    End Sub

    Public Sub SetSCS()
        Opengl.SetSCS(ViewCS)
    End Sub
    '根据二维像素坐标，及当前矩阵设置，计算对应的三维坐标点near->far
    Sub SelectbyPoint(ByVal point As Point, ByRef near As Vector3, ByRef far As Vector3)
        Dim viewport(3) As Integer
        Dim MvMatrix(15), ProjMatrix(15) As Double
        GL.GetInteger(GetPName.Viewport, viewport)
        GL.GetDouble(GetPName.ModelviewMatrix, MvMatrix)
        GL.GetDouble(GetPName.ProjectionMatrix, ProjMatrix)
        Dim realy As Integer = viewport(3) - point.Y - 1 ' 左下角为坐标原点
        OpenTK.Graphics.Glu.UnProject(point.X, realy, 0.0, MvMatrix(0), ProjMatrix(0), viewport(0), near.X, near.Y, near.Z)
        OpenTK.Graphics.Glu.UnProject(point.X, realy, 1.0, MvMatrix(0), ProjMatrix(0), viewport(0), far.X, far.Y, far.Z)
    End Sub
End Class
