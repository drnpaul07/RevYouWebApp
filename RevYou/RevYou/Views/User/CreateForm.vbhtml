﻿@ModelType RevYou.ViewModels.User.ReviewerViewModel
@Code
    ViewData("Title") = "Create Form"

End Code
@section local_styles
<!-- Sweetalert Css -->
<link href="@Url.Content("~/Content/Template/plugins/sweetalert/sweetalert.css")" rel="stylesheet" />
<!-- Bootstrap Tagsinput Css -->
<link href="@Url.Content("~/Content/Template/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css")" rel="stylesheet">
<!-- Bootstrap Select Css -->
<link href="@Url.Content("~/Content/Template/plugins/bootstrap-select/css/bootstrap-select.css")" rel="stylesheet" />
<!-- Multi Select Css -->
<link href="@Url.Content("~/Content/Template/plugins/multi-select/css/multi-select.css")" rel="stylesheet">



    <style>
        .q-card .body{
            padding-bottom:0px !important;
            padding-top: 20px !important;
            padding-left: 20px !important;
            padding-right: 20px !important;

            border-top:solid 5px #03A9F4 !important;
        }
        .form-card .body{
             border-top: solid 5px #0380bc !important;
        }
        /*Some Live Search UI Positioning Problem*/
        .category-select-ls .bs-searchbox{
            margin-left: 30px !important;
        }
        .category-select-ls .dropdown-menu .inner{
            margin-left: 30px !important;
        }
        .category-select-ls .glyphicon{
            margin-top: 11px !important;
        }

        .bootstrap-tagsinput{
            display:block !important;
        }
    </style>
End Section



<ol class="breadcrumb pull-right">
    <li>
        <a href="javascript:void(0);">
            <i class="material-icons">home</i> User
        </a>
    </li>
    <li class="active">
        <a href="javascript:void(0);">
            <i class="material-icons">library_books</i> Create Form
        </a>
    </li>
</ol>

@*@Using Html.BeginForm("CreateForm", "User", FormMethod.Post, New With {.role = "form", .id = "create_form"})*@
@Using (Html.BeginForm())
@Html.AntiForgeryToken()
    @*@<input id = "Username" name="Username" type="hidden" value="@User.Identity.Name">*@
@<div Class="row clearfix">
    <!--FORM DETAILS-->
    <div Class="col-lg-12">
        <div Class="card form-card">
            <div Class="body">
                <div Class="row clearfix">
                    <div Class="col-sm-12">
                        <div Class="form-group form-group-lg">
                            <div Class="form-line">
                                @Html.TextBoxFor(Function(m) m.Title, New With {.class = "form-control", .placeholder = "Untitled Form"})
                                @*<input type = "text" Class="form-control" placeholder="Untitled Form"
                                       id="Title" name="Title"/>*@
                            </div>
                        </div>
                        <div Class="form-group form-group-sm">
                            <div Class="form-line">
                                @Html.TextBoxFor(Function(m) m.Description, New With {.class = "form-control", .placeholder = "Description"})
                                @*<input type = "text" Class="form-control" placeholder="Description"
                                       id="Description" name="Description"/>*@
                                <div Class="help-info">Enter the form description here.</div>
                            </div>
                        </div>
                    </div>
                    <div class="row p-r-10 p-l-10">
                        <div class="col-sm-12 col-md-12">
                            <div class="form-group">
                                <div class="category-select-ls">
                                    <select id="CategoryID" name="CategoryID" class="form-control show-tick" data-live-search="true" required>
                                        <option value="" selected>-- Please Select Category --</option>
                                        @For Each item In ViewBag.Categories
                                            @<option value = "@item.CategoryID">@item.Name</Option>
                                        Next
                                    </select>
                                    <div Class="help-info">Select the form category.</div>
                                </div>
                            </div>
                        </div>
                        <div Class="col-sm-12 col-md-12">   
                            <div class="form-group demo-tagsinput-area">
                                <div class="form-line">
                                    @*<input type="text" class="form-control" data-role="tagsinput">*@
                                    <select id="Tags" name="Tags" multiple="" data-role="tagsinput" style="display:none !important;" required>
                                    </select>
                                </div>
                                <div Class="help-info">Enter tags related for this form.</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--QUESTIONS-->
    <div Class="col-lg-12">
        <!--QUESTIONS ROW-->
        <div Class="row" id="questions-row">
            <!--QUESTION COL-->
            
            <div Class="col-lg-12 question-col">
                <div Class="card q-card">
                    <div Class="body">
                        <div Class="row clearfix">
                            <div Class="col-lg-12">
                                <div Class="form-group">
                                    <div Class="form-line">
                                        @*@Html.TextBoxFor(Function(m) m.Questions(0).Statement, New With {.class = "form-control", .placeholder = "Question"})*@
                                        <input class="form-control question-field" id="Questions_0__Statement" name="Questions[0].Statement" placeholder="Question" type="text" data-index="0"/>
                                    </div>
                                </div>
                                <div Class="form-group">
                                    <div Class="form-line">
                                        @*@Html.TextBoxFor(Function(m) m.Questions(0).Answer, New With {.class = "form-control", .placeholder = "Answer"})*@
                                        <input class="form-control answer-field" id="Questions_0__Answer" name="Questions[0].Answer" placeholder="Answer" type="text" data-index="0"/>
                                        <div Class="help-info">Answer strings are Not case sensitive</div>
                                    </div>
                                </div>
                                <div Class="align-center">
                                    <Button type = "button" Class="btn btn-danger btn-circle waves-effect waves-circle waves-float remove-question-btn">
                                        <i Class="material-icons">close</i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div Class="col-lg-12 align-center p-b-10">
        <!--ADD QUESTION BUTTON-->
        <Button id = "add-question-btn" type="button" Class="btn btn-primary btn-circle-lg waves-effect waves-circle waves-float"
                data-toggle="tooltip" data-placement="bottom" title="Click to add a Question">
            <i Class="material-icons">add</i>
        </button>
        <!--SUBMIT BUTTON-->
        <Button id = "add-question-btn" type="submit" Class="btn btn-success btn-circle-lg waves-effect waves-circle waves-float"
                data-toggle="tooltip" data-placement="bottom" title="Click to submit form">
            <i Class="material-icons">save</i>
        </button>
    </div>
</div>
End Using


@section local_scripts
<!-- SweetAlert Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/sweetalert/sweetalert.min.js")"></script>
<!-- Bootstrap Tags Input Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/bootstrap-tagsinput/bootstrap-tagsinput.js")"></script>
<!-- Select Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/bootstrap-select/js/bootstrap-select.js")"></script>  
<!-- Multi Select Plugin Js -->
<script src="@Url.Content("~/Content/Template/plugins/multi-select/js/jquery.multi-select.js")"></script> 

<script>
    $(function () {
        $('#CategoryID').selectpicker();

        arrangeModelBinding(); //arranging model binding
        var max_questions = 4; //maximum input boxes allowed is 5
        var wrapper = $("#questions-row"); //Fields wrapper
        var add_button = $("#add-question-btn"); //Add button ID
        var x = 1; //initlal text box count
        var removedIndex = []
        var removedCount = 0
        $(add_button).click(
                    function (e) {
                        //on add input button click

                        e.preventDefault();
                        if (x >= max_questions) {
                            swal("Maximum entries has been reached!");
                        } else {
                            $(wrapper).append(
                               '<div class="col-lg-12 question-col">' +
                                    '<div class="card q-card">' +
                                        '<div class="body">' +
                                            '<div class="row clearfix">' +
                                                '<div class="col-lg-12">' +
                                                    '<div class="form-group">' +
                                                        '<div class="form-line">' +
                                                            '<input class="form-control question-field" placeholder="Question" type="text" value="" />' +
                                                        '</div>' +
                                                    '</div>' +
                                                    '<div class="form-group">' +
                                                        '<div class="form-line">' +
                                                            '<input class="form-control answer-field" placeholder="Answer" type="text" value="" />' +
                                                            '<div class="help-info">Answer strings are not case sensitive</div>' +
                                                        '</div>' +
                                                    '</div>' +
                                                    '<div class="align-center">' +
                                                        '<button type="button" class="btn btn-danger btn-circle waves-effect waves-circle waves-float remove-question-btn">' +
                                                            '<i class="material-icons">close</i>' +
                                                        '</button>' +
                                                    '</div>' +
                                                '</div>' +
                                            '</div>' +
                                        '</div>' +
                                    '</div>' +
                                '</div>'
                            )
                            x++;
                            arrangeModelBinding();
                            var pixelFromTop = $(document).height();
                            $('html,body').animate({ scrollTop: pixelFromTop }, 'slow');
                        }
                    })

        $(wrapper).on("click", ".remove-question-btn", function (e) {
            //user click on remove field
            e.preventDefault();
            if (x <= 1) {
                swal("You cannot remove the Last Entry");
            } else {
                $(this).parent().parent().parent().parent().parent().parent(".question-col").remove();
                x--;
                arrangeModelBinding();
            }

        });
    });

    function arrangeModelBinding() {
        var current = 0;
        $('.question-field').each(function (i, obj) {
            //For the Question Field
            obj.id = "Questions_"+ (current) +"__Statement"
            obj.name = "Questions[" + (current) + "].Statement"
            current++;
        });
        current = 0
        $('.answer-field').each(function (i, obj) {
            //For the Question Field
            obj.id = "Questions_" + (current) + "__Answer"
            obj.name = "Questions[" + (current) + "].Answer"
            current++;
        });

    }
</script>
End Section

