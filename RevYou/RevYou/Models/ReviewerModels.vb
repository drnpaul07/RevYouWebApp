﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.AspNet.Identity.EntityFramework
Imports RevYou.Models.Base

Namespace Models.Reviewer
    Public Enum QuestionType
        multiple_choice
        short_answer
    End Enum
    Public Class Form
        Public Property FormID As Integer
        Public Property Title As String
        Public Property Description As String
        Public Property DateCreated As DateTime
        Public Property IsPosted As Boolean

        'This is the connected DbSet for this DbSet.
        Public Overridable Property Questions As IList(Of Question)
        'Public Overridable Property Tags As IList(Of Tag)
        Public Overridable Property FormTags As IList(Of FormTag)

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
        Public Property Type As String

        Public Property FormID As Integer

        Public Property Answer As String

        'If there is an Image that needs to be viewed
        'Public Property ImageData As Byte()
        'Public Property ImageType As String
        'Public Property ImageSize As Integer

        'Related DBSets
        Public Overridable Property Choices As IList(Of Choice)

        'Parent Form
        Public Overridable Property Form As Form
    End Class

    Public Class Choice
        Public Property ChoiceID As Integer
        Public Property Item As String
        Public Property isAnswer As Boolean

        Public Property QuestionID As Integer

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

        'Public Property FormID As Integer
        'Public Overridable Property Form As Form

        Public Overridable Property UserTags As IList(Of UserTag)
        Public Overridable Property FormTags As IList(Of FormTag)
    End Class

    Public Class FormTag
        Public Property FormTagID As Integer

        Public Property FormID As Integer
        Public Overridable Property Form As Form

        Public Property TagID As Integer
        Public Overridable Property Tag As Tag
    End Class

End Namespace
