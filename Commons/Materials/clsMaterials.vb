Imports System.Xml

Public Enum MaterialType
    CommonBox        '盒子
    ActiveBox        '盒子（选中）
    BoundingBox      '盒子的包围盒
    GameBoxFrame
    GameBoxBed
    AxisOrgin
    AxisX
    AxisY
    AxisZ
End Enum

Public Class clsMaterials
    Private MaterialConfig As System.Xml.XmlElement  '材料配置集合

    Public Sub New()
        Dim XML As New XmlDocument
        XML.LoadXml(My.Resources.ConfigMaterial)
        Dim node As System.Xml.XmlElement
        node = XML.SelectSingleNode("Materials")
        Me.MaterialConfig = node
    End Sub

    Public Sub SetMaterial(ByVal mt As MaterialType)
        Dim MType As String = ""
        Select Case mt
            Case MaterialType.CommonBox
                MType = "CommonBox"
            Case MaterialType.ActiveBox
                MType = "ActiveBox"
            Case MaterialType.BoundingBox
                MType = "BoundingBox"
            Case MaterialType.GameBoxFrame
                MType = "GameBoxFrame"
            Case MaterialType.GameBoxBed
                MType = "GameBoxBed"
            Case MaterialType.AxisX
                MType = "AxisX"
            Case MaterialType.AxisY
                MType = "AxisY"
            Case MaterialType.AxisZ
                MType = "AxisZ"
            Case MaterialType.AxisOrgin
                MType = "AxisOrgin"
        End Select
        Dim node As System.Xml.XmlElement
        node = MaterialConfig.SelectSingleNode(MType)
        Dim ambient, diffuse, specular, emission, shininess As String
        With node
            ambient = .SelectSingleNode("ambient").InnerXml
            diffuse = .SelectSingleNode("diffuse").InnerXml
            specular = .SelectSingleNode("specular").InnerXml
            emission = .SelectSingleNode("emission").InnerXml
            shininess = .SelectSingleNode("shininess").InnerXml
        End With
        Dim objMT As New clsMaterial(ambient, diffuse, specular, emission, shininess)
        objMT.SetMaterial()
    End Sub

End Class
