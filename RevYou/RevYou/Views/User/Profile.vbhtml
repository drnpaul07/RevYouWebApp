@Code
    ViewData("Title") = "User Profile"
End Code
@section local_styles
    <!-- Animation Css -->
    <link href="@Url.Content("~/Content/Template/plugins/animate-css/animate.css")" rel="stylesheet" />
    <!-- Bootstrap Tagsinput Css -->
    <link href="@Url.Content("~/Content/Template/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css")" rel="stylesheet">
    <style>
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
        .nothing-to-show{
            margin-top:90px;
            margin-bottom:90px;
        }
    </style>
End Section

@*<ol class="breadcrumb pull-right">
    <li>
        <a href="javascript:void(0)">
            <i class="material-icons">home</i> User
        </a>
    </li>
    <li class="active">
        <a href="javascript:void(0);">
            <i class="material-icons">library_books</i> Profile
        </a>
    </li>
</ol>*@

<div class="container-fluid">
    <div class="row clearfix">
        <div class="col-xs-12 col-sm-3">
            <div class="card profile-card">
                <div class="profile-header">&nbsp;</div>
                <div class="profile-body">
                    <div class="image-area">
                        <img src="@Url.Content("~/Content/Template/images/user.png")" width="128" height="128" alt="User" />
                    </div>
                    <div class="content-area">
                        <h3>@ViewBag.UserData.Firstname  @ViewBag.UserData.Surname</h3>
                        @*<p>Web Software Developer</p>*@
                        <p>RevYou User</p>
                    </div>
                </div>
                <div class="profile-footer">
                    @*<ul>
                            <li>
                                <span>Followers</span>
                                <span>1.234</span>
                            </li>
                            <li>
                                <span>Following</span>
                                <span>1.201</span>
                            </li>
                            <li>
                                <span>Friends</span>
                                <span>14.252</span>
                            </li>
                        </ul>*@
                    <button class="btn btn-primary btn-lg waves-effect btn-block">Follow Reviewers</button>
                </div>
            </div>

            <div class="card card-about-me">
                <div class="header">
                    <h2>ABOUT ME</h2>
                </div>
                <div class="body">
                    <ul>
                        <li>
                            <div class="title">
                                <i class="material-icons">library_books</i>
                                Education
                            </div>
                            <div class="content">
                                B.S. in Computer Engineering from the Polytechnic University of the Philippines - Manila
                            </div>
                        </li>
                        <li>
                            <div class="title">
                                <i class="material-icons">location_on</i>
                                Location
                            </div>
                            <div class="content">
                                Sta. Mesa, Manila
                            </div>
                        </li>
                        <li>
                            <div class="title">
                                <i class="material-icons">edit</i>
                                Interests
                            </div>
                            <div class="content">
                                <span class="label bg-red">Engineering</span>
                                <span class="label bg-teal">Mathematics</span>
                                <span class="label bg-blue">Sciences</span>
                                <span class="label bg-amber">Arts</span>
                            </div>
                        </li>
                        <li>
                            <div class="title">
                                <i class="material-icons">notes</i>
                                Description
                            </div>
                            <div class="content">
                                I am here to review for my board examination.
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-9">
            <div class="card">
                <div class="body">
                    <div>
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Home</a></li>
                            <li role="presentation"><a href="#profile_settings" aria-controls="settings" role="tab" data-toggle="tab">Profile Settings</a></li>
                            <li role="presentation"><a href="#change_password_settings" aria-controls="settings" role="tab" data-toggle="tab">Change Password</a></li>
                        </ul>

                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="home">
                                @If ViewBag.UserActivities.Count = 0 Then
                                    @<div class="align-center nothing-to-show">
                                        <h2>Nothing to show here..</h2>
                                        <img src="@Url.Content("~/Content/RevYou/images/peppy-boring.gif")" width="318" height="300" alt="Logo" class="peppy-image">
                                    </div>
                                End If
                                @For Each activity In ViewBag.UserActivities
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
                                                        @<span>
                                                            Form Added - @activity.Activity.DateOfAction
                                                        </span>
                                                    Else
                                                        @<h4 Class="media-heading">
                                                            <a href="#"></a>
                                                        </h4>
                                                        @<span>
                                                            ANSWERED - @activity.Activity.DateOfAction
                                                        </span>
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
                                                    <li>
                                                        <a href="/User/EditForm/@activity.Form.FormID">
                                                            <i class="material-icons">edit</i>
                                                            <Span>Edit Reviewer</Span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                                                            <i class="material-icons">restore_page</i>
                                                            <Span> Review</Span>
                                                        </a>
                                                    </li>
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
                                            @<div Class="panel-footer">
                                                <ul>
                                                    <li>
                                                        <a href="javascript:popupCenter({url: '/User/AnswerForm/@activity.Form.FormID', title: '', w:900, h: 700});  ">
                                                            <i class="material-icons">restore_page</i>
                                                            <Span>Try Again</Span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="material-icons">note_add</i>
                                                            <Span> Add To My Reviewers</Span>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>

                                        End If
                                    </div>
                                Next
                            </div>
                            <div role="tabpanel" class="tab-pane fade in" id="profile_settings">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <label for="NameSurname" class="col-sm-2 control-label">Name Surname</label>
                                        <div class="col-sm-10">
                                            <div class="form-line">
                                                <input type="text" class="form-control" placeholder="Name Surname" value="@ViewBag.UserData.FirstName  @ViewBag.UserData.Surname" disabled>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="Email" class="col-sm-2 control-label">Email</label>
                                        <div class="col-sm-10">
                                            <div class="form-line">
                                                <input type="email" class="form-control" placeholder="Email" value="@User.Identity.AuthenticationType" disabled>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group demo-tagsinput-area">
                                        <label for="Tags" class="col-sm-2 control-label">Skills</label>
                                        <div class="col-sm-10">
                                            <div class="form-line">
                                                <select id="Tags" name="Tags" multiple="" data-role="tagsinput" style="display:none !important;" required>
                                                </select>
                                            </div>
                                        </div>
                                        <div Class="help-info">Enter tags you're currently interested in.</div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <input type="checkbox" id="terms_condition_check" class="chk-col-red filled-in" />
                                            <label for="terms_condition_check">I agree to the <a href="#">terms and conditions</a></label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <button type="submit" class="btn btn-danger">SUBMIT</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div role="tabpanel" class="tab-pane fade in" id="change_password_settings">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <label for="OldPassword" class="col-sm-3 control-label">Old Password</label>
                                        <div class="col-sm-9">
                                            <div class="form-line">
                                                <input type="password" class="form-control" id="OldPassword" name="OldPassword" placeholder="Old Password" required>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="NewPassword" class="col-sm-3 control-label">New Password</label>
                                        <div class="col-sm-9">
                                            <div class="form-line">
                                                <input type="password" class="form-control" id="NewPassword" name="NewPassword" placeholder="New Password" required>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="NewPasswordConfirm" class="col-sm-3 control-label">New Password (Confirm)</label>
                                        <div class="col-sm-9">
                                            <div class="form-line">
                                                <input type="password" class="form-control" id="NewPasswordConfirm" name="NewPasswordConfirm" placeholder="New Password (Confirm)" required>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-3 col-sm-9">
                                            <button type="submit" class="btn btn-danger">SUBMIT</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

@section local_scripts
    <!-- Bootstrap Tags Input Plugin Js -->
    <script src="@Url.Content("~/Content/Template/plugins/bootstrap-tagsinput/bootstrap-tagsinput.js")"></script>
    <Script src="@Url.Content("~/Content/RevYou/js/rev-popup.js")"></Script>
End Section
