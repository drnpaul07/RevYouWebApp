Imports RevYou.Models.Reviewer
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace Models.Base
    Public Class UserData
        Public Property UserDataID As Integer
        Public Property Username As String
        Public Property Firstname As String
        Public Property Surname As String

        'Collection Models
        Public Overridable Property Forms As ICollection(Of Form)
        Public Overridable Property UserTags As IList(Of UserTag)

        'LATEST LISTS
        Public Overridable Property UserActivities As IList(Of UserActivity)
        Public Overridable Property Results As IList(Of Result)
        'Profile Picture
        'Public Property ImageContent As Byte()
        'Public Property ImageType As String
        'Public Property ImageSize As Integer
    End Class


    Public Class UserTag
        Public Property UserTagID As Integer

        Public Property UserDataID As Integer
        Public Overridable Property UserData As UserData

        Public Property TagID As Integer
        Public Overridable Property Tag As Tag
    End Class

End Namespace

