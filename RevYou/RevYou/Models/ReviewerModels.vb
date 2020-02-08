Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.AspNet.Identity.EntityFramework
Imports RevYou.Models.Base

Namespace Models.Reviewer
    Public Class Form
        Public Property FormID As String
        Public Property Title As String
        Public Property Description As String

        'This is the connected DbSet for this DbSet.
        Public Overridable Property Questions As ICollection(Of Question)
        'This is the creator
        Public Overridable Property User As UserData
    End Class

    Public Class Question
        Public Property QuestionID As Integer
        Public Property Index As String
        Public Property Statement As String
        Public Property Answer As String

        'If there is an Image that needs to be viewed
        'Public Property ImageData As Byte()
        'Public Property ImageType As String
        'Public Property ImageSize As Integer

        'Parent Form
        Public Overridable Property Form As Form
    End Class

End Namespace
