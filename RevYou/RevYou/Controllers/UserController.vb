Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports RevYou.Models.Reviewer
Imports RevYou.ViewModels.User
Imports Microsoft.AspNet.Identity
Imports RevYou.DAL
Imports System.Data.Entity



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

            Dim currentUsername As String = User.Identity.Name
            ViewBag.UserForms = db.Form.Where(Function(m) m.UserDataID = db.UserData.Where(Function(n) n.Username = currentUsername).FirstOrDefault.UserDataID).ToList()
            ViewBag.UserData = db.UserData.Where(Function(m) m.Username = currentUsername).FirstOrDefault
            Return View()
        End Function

        Function CreateForm() As ActionResult
            ViewBag.Categories = db.Category.ToList
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("CreateForm")>
        Public Function SubmitFormDetails(model As ReviewerViewModel) As ActionResult

            If ModelState.IsValid Then
                Dim form As Form = New Form()
                form.Title = model.Title
                form.Description = model.Description
                form.DateCreated = DateTime.Now
                form.Questions = model.Questions

                Dim creator = db.UserData.Where(Function(u) u.Username = model.Username).FirstOrDefault()
                Dim category = db.Category.Where(Function(c) c.CategoryID = model.CategoryID).FirstOrDefault()

                'Iterating tag list to Tag object
                Dim tagList As IList(Of Tag) = New List(Of Tag)()
                For Each item In model.Tags
                    Dim tag As Tag = New Tag()
                    'Checks if the tag is defined in the database
                    Dim tagCheck As Tag = db.Tag.Where(Function(t) t.Name = item).FirstOrDefault()
                    If tagCheck Is Nothing Then
                        tag.Name = item
                        tag.Usage = 1
                        tagList.Add(tag)
                    Else
                        tagCheck.Usage = tagCheck.Usage + 1
                        db.Entry(tagCheck).State = EntityState.Modified
                    End If
                Next

                form.User = creator
                form.Category = category
                'I dont know if this can be nullable (if yes then this is good)
                form.Tags = tagList

                db.Form.Add(form)
                db.SaveChanges()
            End If

            'This should be a return url parameter but i would do that later
            Return RedirectToAction("/Reviewer")
        End Function


    End Class
End Namespace