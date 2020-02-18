Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.AspNet.Identity.EntityFramework
Imports RevYou.Models.Base

Namespace Models.Reviewer
    Public Class Form
        Public Property FormID As Integer
        Public Property Title As String
        Public Property Description As String
        Public Property DateCreated As DateTime

        'This is the connected DbSet for this DbSet.
        Public Overridable Property Questions As IList(Of Question)
        Public Overridable Property Tags As IList(Of Tag)

        'This is the creator
        Public Property UserDataID As Integer
        Public Overridable Property User As UserData
        'This is the category
        Public Property CategoryID As Integer
        Public Overridable Property Category As Category

    End Class

    Public Class Question
        Public Property QuestionID As Integer
        Public Property Index As String
        Public Property Statement As String
        Public Property Answer As String
        Public Property FormID As Integer

        'If there is an Image that needs to be viewed
        'Public Property ImageData As Byte()
        'Public Property ImageType As String
        'Public Property ImageSize As Integer

        'Parent Form
        Public Overridable Property Form As Form
    End Class

    Public Class Category
        Public Property CategoryID As Integer
        Public Property Name As String
        Public Property Code As String

        Public Overridable Property Forms As IList(Of Form)

    End Class

    Public Class Tag
        Public Property TagID As Integer
        Public Property Name As String
        Public Property Usage As Integer
    End Class

    'Public Class FormTag
    '    Public Property FormTagID As Integer

    '    Public Property FormID As Integer
    '    Public Overridable Property Form As Form

    '    Public Property TagID As Integer
    '    Public Overridable Property Tag As Tag
    'End Class

End Namespace
