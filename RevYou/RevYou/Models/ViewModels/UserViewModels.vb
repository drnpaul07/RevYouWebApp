
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
    'Public Class AnsweringFormViewModelList
    '    Public Property AnsweringFormViewModels As List(Of AnsweringFormViewModel)
    'End Class
    Public Class AnsweringFormViewModel
        Public Property FormID As Integer
        Public Property QAList As List(Of QuestionAndAnswer)
    End Class
    Public Class QuestionAndAnswer
        Public Property QuestionID As Integer
        Public Property QuestionType As String
        Public Property ChoiceID As Integer
        Public Property AnswerString As String
    End Class

    Public Class UserActivityViewModel
        Public Property Action
        Public Property Form As Form
        Public Property Result As Result
        Public Property Activity As UserActivity
    End Class
End Namespace


