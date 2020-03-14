@Code
    ViewData("Title") = "Recent Activities"
End Code

@section local_styles
    <style>
        body {
            background-color: white;
        }

        .nothing-to-show {
            margin-top: 90px;
            margin-bottom: 90px;
        }

        .post-div {
            width: 100%;
            height: 150px;
        }

        .post-col {
            margin: 0px;
            padding: 0px;
        }

            .post-col .info-box-3 {
                box-shadow: 0 0px 0px rgba(0, 0, 0, 0.0) !important;
                margin: 0px;
                height: 150px;
            }

                .post-col .info-box-3 .icon {
                    bottom: -10px;
                    right: 20px;
                }

                    .post-col .info-box-3 .icon i {
                        font-size: 120pt !important;
                    }

                .post-col .info-box-3 .content {
                    margin-top: 33px;
                }

                .post-col .info-box-3 .number {
                    font-size: 25pt;
                }

        .demo-tagsinput-area {
            margin-bottom: 10px !important;
        }

        .nothing-to-show {
            margin-top: 90px;
            margin-bottom: 90px;
        }
    </style>
End Section

@section local_scripts
    <Script src="@Url.Content("~/Content/RevYou/js/rev-popup.js")"></Script>
End Section

<h3>@ViewData("Title").</h3>

<div class="container-fluid">
    <div class="row">
        @If ViewBag.Activities.Count = 0 Then
            @<div class="align-center nothing-to-show">
                <h2>Nothing to show here..</h2>
                <img src="@Url.Content("~/Content/RevYou/images/peppy-boring.gif")" width="318" height="300" alt="Logo" class="peppy-image">
            </div>
        Else
            @For Each activity In ViewBag.Activities
                @<div Class="panel panel-default panel-post">
    <div Class="panel-heading">
        <div Class="media">
            <div Class="media-left">
                <a href="#">
                    <img src="/Content/Template/images/user.png" alt="User" />
                </a>
            </div>
            <div Class="media-body">

                @If activity.Action = "ADDED" Then
                    @<h4 Class="media-heading">
                        <a href="#"></a>
                    </h4>
                    @If activity.Activity.UserData.Username = User.Identity.Name Then
                        @<span>
                            YOU added a Form - @activity.Activity.DateOfAction
                        </span>
                    Else
                        @<span>
                            @activity.Activity.UserData.Username added a Form - @activity.Activity.DateOfAction
                        </span>
                    End If

                Else
                    @<h4 Class="media-heading">
                        <a href="#"></a>
                    </h4>
                    @If activity.Activity.UserData.Username = User.Identity.Name Then
                        @<span>
                            YOU answered a Form - @activity.Activity.DateOfAction
                        </span>
                    Else
                        @<span>
                            @activity.Activity.UserData.Username answered a Form - @activity.Activity.DateOfAction
                        </span>
                    End If
                End If
            </div>
        </div>
    </div>

    @If activity.Action = "ADDED" Then
        @<div Class="panel-body">
            <div Class="post">
                <div Class="post-heading">
                    <p>@activity.Form.Description</p>
                </div>
                <div Class="post-content">
                    <div Class="col-lg-12 post-col">
                        <div Class="info-box-3 bg-light-blue hover-zoom-effect">
                            <div Class="icon">
                                <i Class="material-icons">note_add</i>
                            </div>
                            <div Class="content">
                                <div Class="text">REVIEWER ADDED</div>
                                <div Class="number">@activity.Form.Title</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        @<div Class="panel-footer">
             <ul>
                 @If activity.Activity.UserData.Username = User.Identity.Name Then
                     @<li>
                         <a href="/User/EditForm/@activity.Form.FormID">
                             <i class="material-icons">edit</i>
                             <Span>Edit Reviewer</Span>
                         </a>
                     </li>
                     @<li>
                         <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                             <i class="material-icons">restore_page</i>
                             <Span> Review</Span>
                         </a>
                     </li>
                 Else
                     @<li>
                         <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                             <i class="material-icons">restore_page</i>
                             <Span> Review @activity.Activity.UserData.Username  's Form</Span>
                         </a>
                     </li>
                     @<li>
                         @*<a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                             <i class="material-icons">restore_page</i>
                             <Span> Review @activity.Activity.UserData.Username  's Form</Span>
                         </a>*@
                     </li>
                 End If


             </ul>
        </div>
    ElseIf activity.Action = "ANSWERED" Then
        @<div Class="panel-body">
            <div Class="post">
                <div Class="post-heading">
                    <p>@activity.Form.Description</p>
                </div>
                @If activity.Result.Grade = "PASS" Then
                    @<div Class="post-content">
                        <div Class="col-lg-12 post-col">
                            <div Class="info-box-3 bg-green hover-zoom-effect">
                                <div Class="icon">
                                    <i Class="material-icons">mood</i>
                                </div>
                                <div Class="content">
                                    <div Class="text">YOU SCORED</div>
                                    <div Class="number">@activity.Result.Score  / @activity.Form.Questions.Count</div>
                                </div>
                            </div>
                        </div>
                    </div>
                ElseIf activity.Result.Grade = "FAIL" Then
                    @<div Class="post-content">
                        <div Class="col-lg-12 post-col">
                            <div Class="info-box-3 bg-red hover-zoom-effect">
                                <div Class="icon">
                                    <!--FOR ADDED FORM-->
                                    <i Class="material-icons">mood_bad</i>
                                </div>
                                <div Class="content">
                                    <div Class="text">YOU SCORED</div>
                                    <div Class="number">@activity.Result.Score  / @activity.Form.Questions.Count</div>
                                </div>
                            </div>
                        </div>
                    </div>
                End If
            </div>
        </div>
        @If activity.Activity.UserData.Username = User.Identity.Name Then
            @<div Class="panel-footer">
                <ul>
                    <li>
                        <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                            <i class="material-icons">restore_page</i>
                            <Span>Try Again</Span>
                        </a>
                    </li>
                    <li>
                        @*<a href="#">
                            <i class="material-icons">note_add</i>
                            <Span> Add To My Reviewers</Span>
                        </a>*@
                    </li>
                </ul>
            </div>
        Else
            @<div Class="panel-footer">
                <ul>
                    <li>
                        <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                            <i class="material-icons">restore_page</i>
                            <Span>Review This Form</Span>
                        </a>
                    </li>
                    <li>
                        @*<a href="#">
                            <i class="material-icons">note_add</i>
                            <Span> Add To My Reviewers</Span>
                        </a>*@
                    </li>
                </ul>
            </div>

        End If


    End If
</div>
            Next
            End If

</div>
</div>
