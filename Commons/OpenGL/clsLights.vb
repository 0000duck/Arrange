Imports System.Xml
Imports OpenTK.Graphics

Public Class clsLights
    Private Lights As List(Of clsLight)

    Public Sub New()
        Lights = New List(Of clsLight)
        Dim XML As New XmlDocument
        XML.LoadXml(My.Resources.ConfigLight)
        Dim node As System.Xml.XmlElement
        node = XML.SelectSingleNode("Lights")
        node = node.FirstChild
        While node IsNot Nothing
            Lights.Add(New clsLight(node))
            node = node.NextSibling
        End While
    End Sub

    '开所有的灯
    Public Sub SetLight()
        For i = 0 To Lights.Count - 1
            SetLight(i, True)
        Next
    End Sub
    '开指定的的灯
    Private Sub SetLight(ByVal index As Integer, ByVal open As Boolean)
        Dim Ln As EnableCap = EnableCap.Light0 + index  '灯号
        Lights(index).SetLight(Ln, open)
    End Sub
End Class
