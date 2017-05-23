Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Graphics.Glu

' 三维坐标系
Public Class clsCS3
    Private Const SphereRadius As Double = 0.02  ' 原点半径
    Private Const AxisRadius As Double = 0.005   ' 轴半径
    Private Const AxisHeight As Double = 0.5     ' 轴长度
    Private Const ArrowHeight As Double = 0.1    ' 箭头长度
    Private Const ArrowRadius As Double = 0.03   ' 箭头半径 
    Private _SphereRadius As Double   ' 原点半径
    Private _AxisRadius As Double     ' 轴半径
    Private _AxisHeight As Double     ' 轴长度
    Private _ArrowHeight As Double    ' 箭头长度
    Private _ArrowRadius As Double    ' 箭头半径 

    Public Sub New(ByVal Length As Integer)
        _SphereRadius = SphereRadius * Length
        _AxisRadius = AxisRadius * Length
        _AxisHeight = AxisHeight * Length
        _ArrowRadius = ArrowRadius * Length
        _ArrowHeight = ArrowHeight * Length
    End Sub

    Private Sub DrawAxis1(ByVal pObj As IntPtr, ByVal AxisRadius As Double, ByVal AxisHeight As Double, ByVal ArrowRadius As Double, ByVal ArrowHeight As Double)
        Cylinder(pObj, AxisRadius, AxisRadius, AxisHeight, 10, 1)
        GL.Translate(0, 0, AxisHeight)
        Cylinder(pObj, ArrowRadius, 0, ArrowHeight, 10, 1)
        Disk(pObj, AxisRadius, ArrowRadius, 10, 1)
    End Sub

    Public Sub Draw(ByVal Materials As clsMaterials)
        Dim pObj As IntPtr = NewQuadric()
        '画z轴，带有箭头
        GL.PushMatrix()
        Materials.SetMaterial(MaterialType.AxisZ)
        DrawAxis1(pObj, _AxisRadius, _AxisHeight, _ArrowRadius, _ArrowHeight)
        GL.PopMatrix()

        '画x轴，带有箭头
        GL.PushMatrix()
        Materials.SetMaterial(MaterialType.AxisX)
        GL.Rotate(90, 0, 1, 0)
        DrawAxis1(pObj, _AxisRadius, _AxisHeight, _ArrowRadius, _ArrowHeight)
        GL.PopMatrix()

        '画y轴，带有箭头
        GL.PushMatrix()
        Materials.SetMaterial(MaterialType.AxisY)
        GL.Rotate(-90, 1, 0, 0)
        DrawAxis1(pObj, _AxisRadius, _AxisHeight, _ArrowRadius, _ArrowHeight)
        GL.PopMatrix()

        '白色原点
        Materials.SetMaterial(MaterialType.AxisOrgin)
        Sphere(pObj, _SphereRadius, 10, 10)  '经向、纬向精度
        pObj = Nothing
    End Sub
End Class
