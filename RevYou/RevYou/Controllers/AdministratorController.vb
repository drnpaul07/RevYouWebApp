Imports System.Web.Mvc

Namespace Controllers
    <Authorize(Roles:="ADMIN, SUPERADMIN")>
    Public Class AdministratorController
        Inherits Controller

        ' GET: Administrator
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace