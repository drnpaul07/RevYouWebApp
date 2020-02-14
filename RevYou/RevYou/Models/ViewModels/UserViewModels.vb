
Imports RevYou.Models.Reviewer

Namespace ViewModels.User
    Public Class ReviewerViewModel
        Public Property Title As String
        Public Property Description As String
        Public Property Username As String
        Public Property CategoryID As Integer
        Public Property Tags As IList(Of String)
        'List of questions
        Public Property Questions As IList(Of Question)
    End Class
End Namespace

