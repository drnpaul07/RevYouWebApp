Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports RevYou.Models.Reviewer
Imports RevYou.ViewModels.User
Imports Microsoft.AspNet.Identity
Imports RevYou.DAL

Namespace Controllers
    <Authorize(Roles:="USER")>
    Public Class UserController
        Inherits Controller

        Private db As New RevYouContext

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

        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("CreateForm")>
        Public Function SubmitFormDetails(model As ReviewerViewModel) As ActionResult

            Debug.WriteLine(model.Title)
            Debug.WriteLine(model.Description)
            For Each item In model.Questions
                Debug.WriteLine(item.Statement)
                Debug.WriteLine(item.Answer)
            Next
            If ModelState.IsValid Then
                Dim form As Form = New Form()
                form.Title = model.Title
                form.Description = model.Description                form.Questions = model.Questions
                'form.User.UserID = User.Identity.GetUserId
                'form.User.Username = User.Identity.GetUserName

                db.Form.Add(form)
                'VALIDATION ERROR HERE!!! I THINK ITS ABOUT HOW I MADE THE DB SETS RELATED TO EACH OTHER 
                'in this instance im just using the FORM DBSET which is connected to 2 DBSET.
                db.SaveChanges()

            End If

            'This should be a return url parameter but i would do that later
            Return RedirectToAction("/Reviewer")
        End Function


    End Class
End Namespace