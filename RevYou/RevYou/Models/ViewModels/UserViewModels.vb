
Imports RevYou.Models.Reviewer

Namespace ViewModels.User
    Public Class ReviewerViewModel

        Public Property Title As String
        Public Property Description As String
        'List of questions
        Public Property Questions As IList(Of Question)


    End Class
End Namespace

