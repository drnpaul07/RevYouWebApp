@Code
    ViewData("Title") = "Reviewers"
End Code
@section local_styles
<!-- Sweetalert Css -->
<link href="@Url.Content("~/Content/Template/plugins/sweetalert/sweetalert.css")" rel="stylesheet" />
 <!-- Waves Effect Css -->
<link href="@Url.Content("~/Content/Template/plugins/node-waves/waves.css")" rel="stylesheet" />
<!-- Animation Css -->
<link href="@Url.Content("~/Content/Template/plugins/animate-css/animate.css")" rel="stylesheet" />
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

        .pager{
            margin-top: 30px !important
        }
        #create-form-container{
              width: 100%;
              /* Firefox */
              display: -moz-box;
              -moz-box-pack: center;
              -moz-box-align: center;
              /* Safari and Chrome */
              display: -webkit-box;
              -webkit-box-pack: center;
              -webkit-box-align: center;
              /* W3C */
              display: box;
              box-pack: center;
              box-align: center;
              

             
        }
        #create-form{
            width:70%;
            margin-top: 20vh;
        }
        .result-count {
           position:absolute;
           bottom:10px;
           right:20px;
           font-size:10pt
          
        }

    </style>
End Section

@section local_scripts
<!-- SweetAlert Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/sweetalert/sweetalert.min.js")"></script>
<!-- Waves Effect Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/node-waves/waves.js")"></script>
<Script src="@Url.Content("~/Content/RevYou/js/rev-popup.js")"></Script>
<script>
    $(function () {
        document.getElementById('bottom-element').scrollIntoView()
        

        if (@ViewBag.UserForms.count() <= 0) {
            swal({
                title: "MESSAGE",
                text:"Form collection is Empty"
            })
        }
    });

    function showAll(){
        alert("HATDOG")
        $("#viewMode").value= "all";

        $("#showmore_form").submit();
    }

    function deleteForm(formID) {
        var form = $(formID)
        swal({
            title: "REMOVE FORM",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Confirm",
            cancelButtonText: "Cancel",
            closeOnConfirm: false,
            closeOnCancel: false
        },
   		    function (isConfirm) {
   			    if (isConfirm) {
   				    form.submit();
   			    } else {
   				    swal({
   					    title: "ABORTED",
   					    type: "error",
   					    showConfirmButton: true,
   					    closeOnConfirm: false
   				    });
   			    }
   		    });
    }
    function backToTop() {
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    }
</script>
End Section
<div id="top-element"></div>
<ol class="breadcrumb pull-right">
    <li>
        <a href="javascript:void(0)">
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
                            <li><a href="/User/CreateForm">Create Form</a></li>
                            <li><a href="javascript:showAll();">Show All</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="body">
                
                @If ViewBag.UserForms.count() = 0 Then
                    @<div id="create-form-container">
                         <div id ="create-form">
                             <div class="info-box-3 bg-light-blue hover-zoom-effect" style="cursor:pointer" onclick="location.href = '/User/CreateForm';">
                                 <div class="icon">
                                     <i class="material-icons">library_books</i>
                                 </div>
                                 <div class="content">
                                     <div class="text">Click to add a new form</div>
                                     <div class="number">CREATE FORM</div>
                                 </div>
                             </div>
                         </div>
                    </div>


                End If
                @For Each form In ViewBag.UserForms

                @Code
                    Dim submitLink As String = "/DeleteForm/" & form.FormID
                    Dim formID As String = "deleteForm" & form.FormID
                End Code

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
                                        @For Each formTag In form.FormTags
                                            @<span Class="label bg-blue">@formTag.Tag.Name</span>
                                        Next
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div Class="panel-footer">
                            <ul>
                                <li>
                                                            <a href = "/User/AnswerForm/@form.FormID" >
                                        <i class="material-icons">visibility</i>
                                                            <span> Preview</span>
                                    </a>
                                </li>

                                <li>
                                                            <a href = "/User/EditForm/@form.FormID" >
                                        <i class="material-icons">mode_edit</i>
                                                            <span> Edit</span>
                                    </a>
                                </li>

                                <li>
                                    
                                    @Using Html.BeginForm(submitLink, "User", FormMethod.Post, New With {.role = "form", .id = formID})
                                        @Html.AntiForgeryToken()
                                        @<a href="javascript:deleteForm(@formId)">
                                            <i class="material-icons">delete</i>
                                            <span> Delete</span>
                                        </a>
                                    End Using
                                                            
                                </li>
                            
                                <li>
                                                            <a href = "#" >
                                        <i class="material-icons">question_answer</i>
                                                            <span>@form.Questions.count() Questions</span>
                                    </a>
                                </li>

                                <li>
                                                            <div Class="icon-container">
                                        <a href = "/User/ShareForm/@form.FormID" >
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
                    @If ViewBag.UserForms.count() > 0 Then

                        @If ViewBag.IsAllDisplayed Then
                            If ViewBag.UserForms.count() > 2 Then
                                @<ul Class="pager">
                                    <li> <a href="javascript:backToTop()" Class="waves-effect">Back to top</a></li>
                                </ul>
                            End If
                        Else
                            @Using Html.BeginForm("Reviewer", "User", FormMethod.Get, New With {.role = "form", .id = "showmore_form"})
                                @<input name="viewMode" id="viewMode" type="hidden" value="offset" />
                                @<input name="currentDisplayed" id="currentDisplayed" type="hidden" value="@ViewBag.UserForms.count()" />
                                @*@<a href="javascript:document.getElementById('showmore_form').submit()">Show more</a>*@

                                @<ul Class="pager">
                                    <li> <a href="javascript:document.getElementById('showmore_form').submit()" Class="waves-effect">Show More</a></li>
                                </ul>
                            End Using
                        End If

                    End If  

                
                <div id="bottom-element" class="pull-right result-count">
                    Showing @ViewBag.ViewedCount out of @ViewBag.TotalCount Forms
                </div>
            </div>
        </div>
    </div>
</div>
<!-- #END# Tabs With Icon Title -->