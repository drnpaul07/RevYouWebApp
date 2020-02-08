Imports System.Web.Mvc

Namespace Controllers
    <Authorize(Roles:="USER")>
    Public Class UserController
        Inherits Controller

        ' GET: User
        'Function Index() As ActionResult
        '    Return View()
        'End Function

        Function Reviewer() As ActionResult
            Return View()
        End Function

        Function CreateForm() As ActionResult
            Return View()
        End Function

    End Class
End Namespace