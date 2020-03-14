Imports Microsoft.Owin.Security
Imports RevYou.DAL
Imports RevYou.ViewModels.User

<Authorize>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New RevYouContext

    Function Index() As ActionResult
        'Should do identity checking and route to specific home page
        Return RedirectToAction("Dashboard")
    End Function

    Function Dashboard() As ActionResult

        Dim userActivities = db.UserActivity.OrderByDescending(Function(m) m.UserActivityID).ToList()
        Dim userActivityList As List(Of UserActivityViewModel) = New List(Of UserActivityViewModel)
        For Each item In userActivities
            Dim activity As UserActivityViewModel = New UserActivityViewModel
            activity.Action = item.Action
            activity.Activity = item
            activity.Form = item.Form
            activity.Result = db.Result.Where(Function(m) m.ResultID = item.ResultID).FirstOrDefault
            userActivityList.Add(activity)
        Next
        ViewBag.Activities = userActivityList


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
