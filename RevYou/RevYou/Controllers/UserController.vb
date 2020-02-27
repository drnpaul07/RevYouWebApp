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
            If userForms.Count > 1 Then
                If viewMode = "offset" Then
                    If userForms.Count >= 7 Then
                        currentDisplayed = currentDisplayed + 5
                    Else
                        currentDisplayed = userForms.Count
                    End If
                ElseIf viewMode = "all" Then
                        currentDisplayed = userForms.Count
                End If
            Else
                currentDisplayed = userForms.Count
            End If


            ViewBag.UserForms = userForms.OrderByDescending(Function(m) m.DateCreated).Take(currentDisplayed).ToList
            ViewBag.UserData = db.UserData.Where(Function(m) m.Username = currentUsername).FirstOrDefault

            If currentDisplayed >= userForms.Count Then
                ViewBag.IsAllDisplayed = True
            Else
                ViewBag.IsAllDisplayed = False
            End If

            ViewBag.ViewedCount = currentDisplayed
            ViewBag.TotalCount = userForms.Count()

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
                form.IsPosted = False

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
            For Each tag In form.FormTags
                tagList.Add(tag.Tag.Name)
            Next
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
            Dim newFormTags As IList(Of FormTag) = New List(Of FormTag)
            Dim reEnteredFormTags As IList(Of FormTag) = New List(Of FormTag)
            Dim tagList As IList(Of Tag) = New List(Of Tag)
            Dim tagIDs As IList(Of Integer) = New List(Of Integer)
            Dim tagsIDString As String = ""

            form = db.Form.Where(Function(m) m.FormID = FormID).FirstOrDefault

            'Checks if the MODEL is VALID and if the USER really owns the form ( ref with form ID )
            If ModelState.IsValid And form.User.Username = User.Identity.Name Then
                'form.Title = model.Title
                'form.Description = model.Description
                'form.CategoryID = model.CategoryID
                If (model.Tags IsNot Nothing Or model.Tags IsNot "") Then
                    For Each item In model.Tags
                        Debug.WriteLine("Current Tag: " + item)
                        Dim formTag = db.FormTag.Where(Function(formTagModel) formTagModel.Tag.Name = item And formTagModel.FormID = form.FormID).FirstOrDefault()
                        Dim tag = db.Tag.Where(Function(tagModel) tagModel.Name = item).FirstOrDefault()



                        'TAG CHECK
                        If (tag Is Nothing) Then
                            'New Instance of TAG in the EDIT MODE
                            db.Tag.Add(New Tag With {.Name = item, .Usage = 1})
                            db.SaveChanges()
                        End If

                        'FORMTAG CHECK
                        If (formTag IsNot Nothing) Then
                            Debug.WriteLine("FORMTAG exists")
                            reEnteredFormTags.Add(formTag)
                        ElseIf (formTag Is Nothing) Then
                            Debug.WriteLine("FORMTAG does not Exists")
                            'newFormTags.Add(New FormTag With {.Form = form, .Tag = db.Tag.Where(Function(x) x.Name = item).FirstOrDefault})
                            db.FormTag.Add(New FormTag With {.Form = form, .Tag = db.Tag.Where(Function(x) x.Name = item).FirstOrDefault})
                            db.SaveChanges()
                        End If

                        'Iterating for ID Conditional Statement
                        For Each tagName In model.Tags
                            Dim tagToRetain = db.Tag.Where(Function(tagModel) tagModel.Name = tagName).FirstOrDefault()
                            Dim tagIDtoRetain = tagToRetain.TagID

                            'All MODEL.TAGS was saved in the methods above so we can assume that all of the tags now is in the DB
                            If (tagIDtoRetain = 0 Or tagIDtoRetain = Nothing) Then
                                'do nothing if the supposed saved tag is not on the DB
                            Else
                                If (tagName Is model.Tags.Last) Then
                                    tagsIDString = tagsIDString & tagIDtoRetain
                                Else
                                    tagsIDString = tagsIDString & tagIDtoRetain & ","
                                End If

                                Debug.WriteLine("Current tagsIDString: " & tagsIDString)
                                tagList.Add(tagToRetain)
                            End If

                        Next

                        For Each tag_item In tagList

                        Next



                        'For Each tagToRetain In model.Tags
                        '    If (tagToRetain Is model.Tags.Last) Then
                        '        tagsString = tagsString & tagToRetain
                        '    Else
                        '        tagsString = tagsString & tagToRetain & ","
                        '    End If
                        '    Debug.WriteLine("Current tagsString: " & tagsString)
                        'Next

                    Next
                End If

                form.Questions = model.Questions
                db.FormTag.SqlQuery("DELETE FROM FormTag WHERE TagID NOT IN (" & tagsIDString & ") AND FormID = " & form.FormID & ";")
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