Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports RevYou.DAL
Imports RevYou.ContosoModels

Namespace Controllers
    Public Class EnrollmentsController
        Inherits System.Web.Mvc.Controller

        Private db As New SchoolContext

        ' GET: Enrollments
        Function Index() As ActionResult
            Dim enrollments = db.Enrollments.Include(Function(e) e.Course).Include(Function(e) e.Student)
            Return View(enrollments.ToList())
        End Function

        ' GET: Enrollments/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollments.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            Return View(enrollment)
        End Function

        ' GET: Enrollments/Create
        Function Create() As ActionResult
            ViewBag.CourseID = New SelectList(db.Courses, "CourseID", "Title")
            ViewBag.StudentID = New SelectList(db.Students, "ID", "LastName")
            Return View()
        End Function

        ' POST: Enrollments/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="EnrollmentID,CourseID,StudentID,Grade")> ByVal enrollment As Enrollment) As ActionResult
            If ModelState.IsValid Then
                db.Enrollments.Add(enrollment)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Students, "ID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' GET: Enrollments/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollments.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Students, "ID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' POST: Enrollments/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="EnrollmentID,CourseID,StudentID,Grade")> ByVal enrollment As Enrollment) As ActionResult
            If ModelState.IsValid Then
                db.Entry(enrollment).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CourseID = New SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Students, "ID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' GET: Enrollments/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollments.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            Return View(enrollment)
        End Function

        ' POST: Enrollments/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim enrollment As Enrollment = db.Enrollments.Find(id)
            db.Enrollments.Remove(enrollment)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
