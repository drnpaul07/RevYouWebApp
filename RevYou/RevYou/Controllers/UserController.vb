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
        <ActionName("EditFormTest")>
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

        <HttpPost()>
        <ActionName("EditForm")>
        <ValidateAntiForgeryToken()>
        Function Edit(model As ReviewerViewModel, FormID As Integer) As ActionResult
            Dim form = db.Form.Where(Function(m) m.FormID = FormID).FirstOrDefault

            Dim unusedFormTags As List(Of FormTag) = New List(Of FormTag)
            Dim formTagNames As List(Of String) = New List(Of String)
            Dim unsavedNewFormTags As List(Of FormTag) = New List(Of FormTag)

            If ModelState.IsValid And form.User.Username = User.Identity.Name Then
                'Compare muna natin kung ano yung mga tag ( na naka save sa form ) na wala sa current submitted na tags
                For Each item In form.FormTags
                    If model.Tags.Contains(item.Tag.Name) Then
                        Debug.WriteLine("NEW TAGS CONTAINS:" + item.Tag.Name)
                    Else
                        Debug.WriteLine("NEW TAGS DOES NOT CONTAINS:" + item.Tag.Name)
                        unusedFormTags.Add(item)                        'If db.Tag.Where(Function(a) a.Name = item.Tag.Name).FirstOrDefault IsNot Nothing Then
                        '    Debug.Write("THE NEW FORM TAG IS IN THE TAG TABLE")
                        'Else
                        '    Debug.WriteLine("THE NEW FORM TAG IS NOT IN THE TAG TABLE")
                        'End If
                    End If
                Next

                'ngayon, reremove na natin agad yung mga current saved FormTags na wala sa newly submitted na mga Form Tags
                For Each item In unusedFormTags
                    Debug.WriteLine("The UNUSED TAG WILL BE REMOVED: " + item.Tag.Name)
                    db.FormTag.Remove(item)
                    db.SaveChanges()
                Next
                'so nadelete na lahat ng unused sa FORMTAG TABLE, ngayon isasave naman natin yung mga bagong Tags.
                'check muna kung nasa TAG table yun then pag andun. + 1 usage, pag wala. Create ng bagong TAG AT FORM TAG OBJECT
                'lalagay ko muna sa String list yung lahat ng formtagName ng current form

                For Each item In form.FormTags
                    formTagNames.Add(item.Tag.Name)
                Next
                For Each item In model.Tags
                    If formTagNames.Contains(item) Then
                        Debug.WriteLine("THE NEW SUBMITTED TAG: " + item + "IS NOT NEW TAG")
                    Else
                        Debug.WriteLine("THE NEW SUBMITTED TAG: " + item + "IS A NEW TAG")
                        Dim toCheckTag = db.Tag.Where(Function(a) a.Name = item).FirstOrDefault
                        If toCheckTag IsNot Nothing Then
                            Debug.WriteLine(item + "IS IN TAG TABLE SO INCREMENT THE USAGE")
                            toCheckTag.Usage = toCheckTag.Usage + 1
                            db.Entry(toCheckTag).State = EntityState.Modified
                            db.SaveChanges()

                            'will add existing TAG but not on this form
                            unsavedNewFormTags.Add(New FormTag With {.FormID = FormID, .Tag = toCheckTag})
                        Else
                            Debug.WriteLine(item + "IS NOT IN TAG TABLE SO CREATE NEW")
                            Dim newTag As Tag = New Tag()
                            newTag.Name = item
                            newTag.Usage = 1
                            db.Tag.Add(newTag)
                            db.SaveChanges()

                            'will add all of this new tags later.
                            unsavedNewFormTags.Add(New FormTag With {.FormID = FormID, .Tag = newTag})
                        End If
                    End If
                Next

                'QUESTION PROCESSING HERE
                'move the QUESTION ids from form to a List of String
                Dim questionIdList As List(Of String) = New List(Of String)
                Dim newQuestionIdList As List(Of String) = New List(Of String)
                'will delete all of the question with ID later so that i will save all the remaining content (NEW QUESTION)
                Dim newQuestionList As List(Of Question) = New List(Of Question)
                For Each item In form.Questions
                    questionIdList.Add(item.QuestionID)
                Next
                For Each item In model.Questions
                    newQuestionIdList.Add(item.QuestionID)

                Next

                'identify all of the REMOVED questions based on the newly submitted QUESTIONS and REMOVE IT
                'ALAM KO NA YUNG ERROR!!! KASE PAG NAG SAVE AKO, SAME ID PERO DI KO PA DINEDELETE! AYOSS YES!!!
                'so ang gagawin ko ngayon is indi ko na iiequal yung new question. update ko nalang sa loop yung QUESTIONS
                For Each item In questionIdList
                    If newQuestionIdList.Contains(item) Then
                        Debug.WriteLine("THE QUESTION ID:" + item + " IS STILL USED")
                        Dim q = db.Question.Where(Function(a) a.QuestionID = item).FirstOrDefault
                        Dim nq = model.Questions.Where(Function(a) a.QuestionID = item).FirstOrDefault
                        'Since need din maalis yung mga choices na nakasave tapos nabago ( naduduplicate ) delete
                        'ko nalang lahat ng choices under ng question then save nalang yung bagong set.
                        db.Choice.RemoveRange(db.Choice.Where(Function(a) a.QuestionID = item))
                        db.SaveChanges()
                        Debug.WriteLine(q.QuestionID)
                        Debug.WriteLine(nq.QuestionID)

                        q.Answer = nq.Answer
                        q.Choices = nq.Choices
                        q.Statement = nq.Statement
                        q.Type = nq.Type

                        db.Entry(q).State = EntityState.Modified
                        db.SaveChanges()
                        Debug.WriteLine("THE QUESTION ID:" + item + " WAS SAVED")
                    Else
                        Debug.WriteLine("THE QUESTION ID:" + item + " IS NOT USED ANYMORE")
                        Dim uq As Question = db.Question.Where(Function(a) a.QuestionID = item).FirstOrDefault
                        db.Question.Remove(uq)
                        db.SaveChanges()
                        Debug.WriteLine("THE QUESTION ID:" + item + " WAS REMOVED")
                    End If
                Next
                'DELETE KO LANG YUNG MGA question na ginagamit parin pero updated na sa taas para matira yung
                'mga BAGO pero di pa saved.
                For Each item In model.Questions
                    If item.QuestionID = 0 Then
                        Debug.WriteLine("FOUND A NEW QUESTION ON UPDATE")
                        item.FormID = FormID
                        db.Question.Add(item)
                        db.SaveChanges()
                        Debug.WriteLine("SAVED NEW QUESTION ON UPDATE")
                    End If
                Next

                Dim toSaveForm = db.Form.Where(Function(a) a.FormID = FormID).FirstOrDefault
                'Checking for TAG PROCESSING RESULTS
                For Each item In toSaveForm.FormTags
                    Debug.WriteLine("THE CURRENT SAVED TAG AFTER TAG PROCCESSING:" + item.Tag.Name)
                Next
                For Each item In unsavedNewFormTags
                    Debug.WriteLine("THE NEW TAG TO BE ADDED: " + item.Tag.Name)
                Next


                'SAVING unsavedTags to the form to be saved
                For Each item In unsavedNewFormTags
                    toSaveForm.FormTags.Add(item)
                Next
                'SAVING other fields to the form to be saved
                toSaveForm.Title = model.Title
                toSaveForm.Description = model.Description
                toSaveForm.CategoryID = model.CategoryID

                'to save the question we can add formID on the view or here to make it easier.
                'iterate through all the questions and set the formID using the passed FormID
                For i As Integer = 0 To model.Questions.Count - 1 Step 1
                    Debug.WriteLine("QUESTION:" & model.Questions(i).QuestionID)
                    model.Questions(i).FormID = FormID
                    Debug.WriteLine(model.Questions(i).FormID)
                Next

                'toSaveForm.Questions = model.Questions


                db.Entry(toSaveForm).State = EntityState.Modified
                db.SaveChanges()
                Debug.WriteLine("THE FORM HAS BEEN SAVED SUCCESSFULLY")
            Else
                Debug.WriteLine("MODEL IS NOT VALID!")
                'Do some 505 error handling here
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

        Public Function AnswerForm(id As Integer) As ActionResult

            'else RETURN a ANSWERING PAGE
            'Debug.WriteLine("The form id is : " & id)
            Dim form = db.Form.Where(Function(m) m.FormID = id).FirstOrDefault

            'Validate if the current user is the creator or not. If the Creator, then, Return preview Page
            If form.User.Username = User.Identity.Name Then
                'DO SOME PREVIEWING HERE ( same user and creator is same )
                'Return RedirectToAction("/Reviewer")
                'Return View("AnswerForm", form)
                ViewBag.Form = form
                Return View()
            Else
                ViewBag.Form = form
                Return View()
            End If
        End Function

        <HttpPost>
        <ActionName("AnswerForm")>
        <ValidateAntiForgeryToken>
        Public Function AnsweringFormPOST(model As AnsweringFormViewModel) As ActionResult
            Dim score As Integer = 0
            If ModelState.IsValid Then
                Debug.WriteLine("FORM ID: " & model.FormID)
                Debug.WriteLine("QA List Size: " & model.QAList.Count)
                For Each item In model.QAList
                    Debug.WriteLine("QUESTION ID: " & item.QuestionID)
                    Debug.WriteLine("QUESTION TYPE: " & item.QuestionType)
                    Debug.WriteLine("QUESTION SH_ANSWER: " & item.AnswerString)
                    Debug.WriteLine("QUESTION CHOICE: " & item.ChoiceID)
                    'Counting Scores
                    Dim currentQuestion = db.Question.Where(Function(m) m.QuestionID = item.QuestionID).FirstOrDefault
                    If item.QuestionType = "short_answer" Then
                        If item.AnswerString = currentQuestion.Answer Then
                            score = score + 1
                        End If
                    ElseIf item.QuestionType = "multiple_choice" Then
                        If item.ChoiceID = currentQuestion.Choices.Where(Function(m) m.isAnswer = True).FirstOrDefault().ChoiceID Then
                            score = score + 1
                        End If
                    End If
                Next
                Debug.WriteLine("=========================================")
                Debug.WriteLine("YOU SCORED: " & score)
                Debug.WriteLine("=========================================")
                'return for model valid
                Return RedirectToAction("/Reviewer")
            Else
                'return for model invalid
                Return RedirectToAction("/Reviewer")
            End If

        End Function

    End Class
End Namespace