Imports RevYou.Models.Reviewer
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace Models.Base
    Public Class UserData
        Public Property UserDataID As Integer
        Public Property Username As String

        'Collection Models
        Public Overridable Property Forms As ICollection(Of Form)

        'Profile Picture
        'Public Property ImageContent As Byte()
        'Public Property ImageType As String
        'Public Property ImageSize As Integer
    End Class
End Namespace

