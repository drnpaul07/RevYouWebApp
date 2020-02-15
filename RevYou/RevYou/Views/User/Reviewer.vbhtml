﻿@Code
    ViewData("Title") = "Reviewers"
End Code
@section local_styles
<!-- JQuery DataTable Css -->
<link href="@Url.Content("~/Content/Template/plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css")" rel="stylesheet">
    <style>
        #reviewer-container{
            min-height: 75vh  !important;
        }
        .media{
            margin-bottom:5px !important;
        }
        .post-tags{
            margin-bottom:10px !important;
        }
        /* icons */
        .icon-container {
            flex-basis: calc(100% * (1/3));
        }
    </style>
End Section

@section local_scripts
@Scripts.Render("~/bundles/script/jquery-datatables")
<Script src="@Url.Content("~/Content/RevYou/js/rev-popup.js")"></Script>
<script>
    $(function () {
        $('#reviewer-table').DataTable({
            responsive: true
        });
    })
</script>
End Section

<ol class="breadcrumb pull-right">
    <li>
        <a href="/User/CreateForm">
            <i class="material-icons">home</i> User
        </a>
    </li>
    <li  class="active">
        <a href="javascript:void(0);">
            <i class="material-icons">library_books</i> Reviewers
        </a>
    </li>
</ol>

<!-- Tabs With Icon Title -->
<div class="row clearfix">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div class="card" id="reviewer-container">
            <div class="header">
                <h2>
                    YOUR REVIEWERS
                </h2>
                <ul class="header-dropdown m-r--5">
                    <li class="dropdown">
                        <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                            <i class="material-icons">more_vert</i>
                        </a>
                        <ul class="dropdown-menu pull-right">
                            <li><a href="javascript:void(0);">Action</a></li>
                            <li><a href="javascript:void(0);">Another action</a></li>
                            <li><a href="javascript:void(0);">Something else here</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="body">
                @If ViewBag.UserForms.count() = 0 Then
                    @<h1>THIS IS EMPTY</h1>
                End If
                @For Each form In ViewBag.UserForms
                @<!--START OF POST-->
                    @<div Class="panel panel-default panel-post">
                        <div Class="panel-heading">
                            <div Class="media">
                                <div Class="media-left">
                                    <a href = "#" >
                                        <img src="/Content/Template/images/user-lg.jpg" />                                                                                                             </a>
                                </div>
                                <div Class="media-body">
                                    <h4 Class="media-heading">
                                        <a href = "#" >@ViewBag.UserData.Firstname @ViewBag.UserData.Surname</a>
                                    </h4>
                                   Form Created -  @form.DateCreated
                                </div>
                            </div>
                        </div>
                        <div Class="panel-body">
                            <div Class="post">
                                <div Class="post-content p-l-20 p-r-20 p-t-30">
                                    <div Class="media">
                                        <div Class="media-body">
                                            <h4 Class="media-heading">@form.Title</h4>
                                            <p>
                                                @form.Description
                                            </p>
                                        </div>
                                    </div>
                                    <div Class="post-tags">
                                        @For Each tag In form.Tags
                                            @<span Class="label bg-blue">@tag.Name</span>
                                        Next
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div Class="panel-footer">
                            <ul>
                                                            <li>
                                                            <a href = "#" >
                                        <i class="material-icons">visibility</i>
                                                            <span> View</span>
                                    </a>
                                </li>

                                <li>
                                                            <a href = "#" >
                                        <i class="material-icons">mode_edit</i>
                                                            <span> Edit</span>
                                    </a>
                                </li>

                                <li>
                                                            <a href = "#" >
                                        <i class="material-icons">delete</i>
                                                            <span> Delete</span>
                                    </a>
                                </li>
                            
                                <li>
                                                            <a href = "#" >
                                        <i class="material-icons">question_answer</i>
                                                            <span>@form.Questions.count() Questions</span>
                                    </a>
                                </li>

                                <li>
                                                            <div Class="icon-container">
                                        <a href = "#" >
                                            <i class="material-icons">share</i>
                                                                <span> Share</span>
                                        </a>
                                    </div>
                                
                                </li>
                            </ul>

                                @*<div class="form-group">
                            <div class="form-line">
                                <input type="text" class="form-control" placeholder="Type a comment" />
                            </div>
                        </div>*@
                        </div>
                    </div>
                    @<!--END OF POST-->
                Next
            </div>
        </div>
    </div>
</div>
<!-- #END# Tabs With Icon Title -->


