Imports RevYou.Models.Reviewer

Namespace Models.Base
    Public Class UserData
        Public Property ID As Integer
        Public Property UserID As String
        Public Property Username As String

        'Collection Models
        Public Overridable Property Forms As ICollection(Of Form)

        'Profile Picture
        Public Property ImageContent As Byte()
        Public Property ImageType As String
        Public Property ImageSize As Integer
    End Class
End Namespace

