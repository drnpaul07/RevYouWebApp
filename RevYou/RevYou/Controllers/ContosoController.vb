Imports System.Web.Mvc

Namespace Controllers
    Public Class ContosoController
        Inherits Controller

        ' GET: Contoso
        Function Index() As ActionResult
            Return View()
        End Function

        Function About() As ActionResult
            Return View()
        End Function

        Function Contact() As ActionResult
            Return View()
        End Function
    End Class
End Namespace