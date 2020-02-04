Imports Microsoft.Owin.Security

<Authorize>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        'Should do identity checking and route to specific home page
        Return RedirectToAction("Dashboard")
    End Function

    Function Dashboard() As ActionResult
        Return View()
    End Function


    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
