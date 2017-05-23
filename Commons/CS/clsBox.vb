Imports OpenTK

' 包围盒的类：表示各种子类对象的包围盒
Public Class clsBox
    Public Xmin, Ymin, Zmin As Single
    Public XMax, YMax, ZMax As Single
    Public Wx, Wy, Wz As Single

    Public Sub New(ByVal base As Vector3, ByVal wx As Integer, ByVal wy As Integer, ByVal wz As Integer)
        ' base是左下后角
        Me.Xmin = base.X : Me.Ymin = base.Y : Me.Zmin = base.Z
        Me.Wx = wx : Me.Wy = wy : Me.Wz = wz
        Me.XMax = Me.Xmin + Me.Wx : Me.YMax = Me.Ymin + Me.Wy : Me.ZMax = Me.Zmin + Me.Wz
    End Sub
    Public Sub New(ByVal xmin As Integer, ByVal ymin As Integer, ByVal zmin As Integer, ByVal wx As Integer, ByVal wy As Integer, ByVal wz As Integer)
        Me.Xmin = xmin : Me.Ymin = ymin : Me.Zmin = zmin
        Me.Wx = wx : Me.Wy = wy : Me.Wz = wz
        Me.XMax = Me.Xmin + Me.Wx : Me.YMax = Me.Ymin + Me.Wy : Me.ZMax = Me.Zmin + Me.Wz
    End Sub
    Sub New(ByVal box As clsBox)
        Me.Xmin = box.Xmin : Me.Ymin = box.Ymin : Me.Zmin = box.Zmin
        Me.Wx = box.Wx : Me.Wy = box.Wy : Me.Wz = box.Wz
        Me.XMax = Me.Xmin + Me.Wx : Me.YMax = Me.Ymin + Me.Wy : Me.ZMax = Me.Zmin + Me.Wz
    End Sub

    Public Function Base() As Vector3        '左下后角
        Return New Vector3(Xmin, Ymin, Zmin)
    End Function

    ' 移动量是offset
    Public Sub Move(ByVal offset As Vector3)
        Xmin += offset.X
        Ymin += offset.Y
        Zmin += offset.Z
    End Sub

    Public Function CX() As Single
        Return Xmin + Wx / 2
    End Function
    Public Function CY() As Single
        Return Ymin + Wy / 2
    End Function
    Public Function CZ() As Single
        Return Zmin + Wz / 2
    End Function
    Public Function CP() As Vector3
        Return New Vector3(CX, CY, CZ)
    End Function

    Public Function Volume() As Single
        Return Wx * Wy * Wz
    End Function
    Public Function BaseString() As String
        Return Xmin.ToString("0.0") & "," & Ymin.ToString("0.0") & "," & Zmin.ToString("0.0")
    End Function
    Public Function SizeString() As String
        Return Wx.ToString("0.0") & "," & Wy.ToString("0.0") & "," & Wz.ToString("0.0")
    End Function
    Public Overrides Function ToString() As String
        Return BaseString() & vbTab & SizeString()
    End Function

End Class
