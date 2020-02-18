Imports System.Data.Entity
Imports RevYou.DAL
Imports RevYou.Models.Reviewer
Imports RevYou.ViewModels.User

Namespace Controllers
    Public Class UserTools
        Function getCheckedTagList(model As ReviewerViewModel, db As RevYouContext) As IList(Of Tag)

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
            Return tagList
        End Function
    End Class
End Namespace
