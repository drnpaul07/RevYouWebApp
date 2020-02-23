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

        Private userTools As New UserTools
        Private db As New RevYouContext

        ' GET: User
        'Function Index() As ActionResult
        '    Return View()
        'End Function

        Function Reviewer(viewMode As String, Optional currentDisplayed As Integer = 2) As ActionResult

            Dim currentUsername As String = User.Identity.Name
            Dim userForms As IList(Of Form) = db.Form.Where(Function(m) m.UserDataID =
                                                  db.UserData.Where(Function(n) n.Username = currentUsername) _
                                                  .FirstOrDefault.UserDataID).ToList

            If viewMode = "offset" Then
                currentDisplayed = currentDisplayed + 5
            ElseIf viewMode = "all" Then
                currentDisplayed = userForms.Count
            End If

            ViewBag.UserForms = userForms.OrderByDescending(Function(m) m.DateCreated).Take(currentDisplayed).ToList
            ViewBag.UserData = db.UserData.Where(Function(m) m.Username = currentUsername).FirstOrDefault

            If currentDisplayed >= userForms.Count Then
                ViewBag.IsAllDisplayed = True
            Else
                ViewBag.IsAllDisplayed = False
            End If

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
            'Set the username here instead in the Frontend
            model.Username = User.Identity.Name
            If ModelState.IsValid Then
                Dim form As Form = New Form()

                form.Title = model.Title
                form.Description = model.Description
                form.DateCreated = DateTime.Now
                form.Questions = model.Questions

                Dim creator = db.UserData.Where(Function(u) u.Username = model.Username).FirstOrDefault()
                Dim category = db.Category.Where(Function(c) c.CategoryID = model.CategoryID).FirstOrDefault()
                Dim currentFormTags As IList(Of FormTag) = New List(Of FormTag)

                'Handles new and existing tag count / usage

                For Each item In model.Tags
                    Dim tag As Tag = New Tag()
                    Dim formTag As FormTag = New FormTag()
                    'Checks if the tag is defined in the database
                    Dim tagCheck As Tag = db.Tag.Where(Function(t) t.Name = item).FirstOrDefault()
                    If tagCheck Is Nothing Then
                        tag.Name = item
                        tag.Usage = 1

                        formTag.Tag = tag

                        db.Tag.Add(tag)

                    Else
                        tagCheck.Usage = tagCheck.Usage + 1

                        formTag.Tag = tagCheck

                        db.Entry(tagCheck).State = EntityState.Modified
                    End If
                    currentFormTags.Add(formTag)
                Next

                form.User = creator
                form.Category = category
                'I dont know if this can be nullable (if yes then this is good)
                'form.Tags = tagList
                form.FormTags = currentFormTags

                db.Form.Add(form)
                db.SaveChanges()
            End If

            'This should be a return url parameter but i would do that later
            Return RedirectToAction("/Reviewer")
        End Function


        Public Function EditForm(ByVal id As Integer) As ActionResult
            Dim form = db.Form.Where(Function(m) m.FormID = id).FirstOrDefault
            Dim viewModel As ReviewerViewModel = New ReviewerViewModel
            Dim tagList As IList(Of String) = New List(Of String)
            viewModel.Title = form.Title
            viewModel.Description = form.Description
            viewModel.CategoryID = form.CategoryID
            'For Each tag In form.Tags
            '    tagList.Add(tag.Name)
            'Next
            viewModel.Tags = tagList
            viewModel.Questions = form.Questions

            ViewBag.Categories = db.Category.ToList
            ViewBag.FormID = id

            Return View("EditForm", viewModel)
        End Function

        <HttpPost>
        <ActionName("EditForm")>
        <ValidateAntiForgeryToken>
        Public Function SubmitEditForm(model As ReviewerViewModel, FormID As Integer) As ActionResult
            Dim form As Form = New Form()
            form = db.Form.Where(Function(m) m.FormID = FormID).FirstOrDefault

            'Checks if the MODEL is VALID and if the USER really owns the form ( ref with form ID )
            If ModelState.IsValid And form.User.Username = User.Identity.Name Then
                form.Title = model.Title
                form.Description = model.Description
                form.CategoryID = model.CategoryID
                'form.Tags = userTools.getCheckedTagList(model, db)
                form.Questions = model.Questions

                db.Entry(form).State = EntityState.Modified
                db.SaveChanges()
            End If
            Return RedirectToAction("/Reviewer")
        End Function

        <HttpPost>
        <ActionName("DeleteForm")>
        <ValidateAntiForgeryToken>
        Public Function ConfirmedDelete(ByVal id As Integer) As ActionResult
            Dim form As Form = db.Form.Where(Function(m) m.FormID = id).FirstOrDefault
            db.Form.Remove(form)
            db.SaveChanges()
            Return RedirectToAction("/Reviewer")
        End Function

    End Class
End Namespace