@ModelType RevYou.ViewModels.User.ReviewerViewModel
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
        .q-card .body {
            padding-bottom: 0px !important;
            padding-top: 20px !important;
            padding-left: 20px !important;
            padding-right: 20px !important;
            border-top: solid 5px #03A9F4 !important;
        }

        .form-card .body {
            border-top: solid 5px #0380bc !important;
        }
        /*Some Live Search UI Positioning Problem*/
        .category-select-ls .bs-searchbox {
            margin-left: 30px !important;
        }

        .category-select-ls .dropdown-menu .inner {
            margin-left: 30px !important;
        }

        .category-select-ls .glyphicon {
            margin-top: 11px !important;
        }

        .bootstrap-tagsinput {
            display: block !important;
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
            <i class="material-icons">library_books</i> Edit Form
        </a>
    </li>
</ol>

@Using Html.BeginForm("EditForm", "User", FormMethod.Post, New With {.role = "form", .id = "edit_form"})
    @Html.AntiForgeryToken()
    @<input type="hidden" name="FormID" id="FormID" value="@ViewBag.FormID"/> 
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
                                </div>
                            </div>
                            <div Class="form-group form-group-sm">
                                <div Class="form-line">
                                    @Html.TextBoxFor(Function(m) m.Description, New With {.class = "form-control", .placeholder = "Description"})
                                    <div Class="help-info">Enter the form description here.</div>
                                </div>
                            </div>
                        </div>
                        <div class="row p-r-10 p-l-10">
                            <div class="col-sm-12 col-md-12">
                                <div class="form-group">
                                    <div class="category-select-ls">
                                        <select id="CategoryID" name="CategoryID" class="form-control show-tick" data-live-search="true" required>
                                            @If Model.CategoryID = Nothing Then
                                                @<option value = "" selected>-- Please Select Category --</Option>
                                            Else
                                                @<option value="">-- Please Select Category --</option>
                                            End If
                                            @For Each item In ViewBag.Categories
                                                If item.CategoryID = Model.CategoryID Then
                                                    @<option value="@item.CategoryID" selected>@item.Name</option>
                                                Else
                                                     @<option value="@item.CategoryID">@item.Name</option>
                                                End If
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
                                            @For Each tag In Model.Tags
                                                @<option selected value="@tag">@tag</Option>
                                            Next
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
                @Code   
                    Dim qIndex As Integer = 0
                End Code
                @For Each question In Model.Questions
                    @<div Class="col-lg-12 question-col">
                        <input type="hidden" id="Questions_{@qIndex}__QuestionID" name="Questions[{@qIndex}].QuestionID" class="question-id-field" value="@question.QuestionID" />
                        <div Class="card q-card">
                            <div Class="body">
                                <div Class="row clearfix">
                                    <div Class="col-lg-12">
                                        <div class="row">
                                            <div class="col-lg-9">
                                                <div Class="form-group">
                                                    <div Class="form-line">
                                                        <input class="form-control question-field" id="Questions_{@qIndex}__Statement" name="Questions[{@qIndex}].Statement" value = "@question.Statement" placeholder="Question" type="text" data-index="0" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!--QUESTION TYPE-->
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <input type="hidden" class="question-type-field" id="Questions_0__Type" name="Questions[0].Type" value="@question.Type" />
                                                    <select class="form-control show-tick question-type-select" onchange="typeChanged(this)" required>
                                                        @If question.Type = "short_answer" Then
                                                            @<option value = "short_answer" selected>
                                                                Short Answer
                                                            </option>
                                                            @<option value = "multiple_choice" >
                                                                Multiple Choice
                                                            </option>
                                                        ElseIf question.Type = "multiple_choice" Then
                                                            @<option value = "short_answer">
                                                                Short Answer
                                                            </option>
                                                            @<option value = "multiple_choice" selected>
                                                                Multiple Choice
                                                            </option>
                                                        End If
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div id = "answerContainer" Class="answer-container">
                                        @If question.Type = "short_answer" Then
                                            @<!--SHORT ANSWER-->
                                            @<div Class="form-group">
                                                <div Class="form-line">
                                                    <input Class="form-control answer-field" id="Questions_{@qIndex}__Answer" name="Questions[{@qIndex}].Answer" value = "@question.Answer" placeholder="Answer" type="text" data-index="0" />
                                                    <div Class="help-info">Answer strings are Not case sensitive</div>
                                                </div>
                                            </div>
                                        ElseIf question.Type = "multiple_choice" Then
                                            
                                            @Code
                                                Dim choiceIndex As Integer = 0
                                            End Code
                                                @<!--MULTIPLE CHOICE-->
                                                @<div class="row clearfix choices-wrapper">
                                                @For Each choice In question.Choices
                                                    @<div class="col-md-12" style="margin-bottom:0px;">
                                                        <div class="input-group input-group-sm choice-input-group" style="margin-bottom:0px;">
                                                            <span class="input-group-addon">
                                                                @If choice.isAnswer = True Then
                                                                    @<input type = "hidden" Class="isAnswer-field" value="true" />
                                                                    @<input type = "checkbox" onclick="checkBoxClicked(this)" Class="chk-col-green isAnswer-checkbox" checked/>
                                                                ElseIf choice.isAnswer = False Then
                                                                    @<input type = "hidden" Class="isAnswer-field" value="false" />
                                                                    @<input type = "checkbox" onclick="checkBoxClicked(this)" Class="chk-col-green isAnswer-checkbox"/>
                                                                End If
                                                                <Label Class="isAnswer-checkbox-label"></label>
                                                            </span>
                                                            <div Class="form-line">
                                                                <input type = "text" Class="form-control choice-field" value="@choice.Item">
                                                            </div>
                                                            <span Class="input-group-addon remove-choice-span" onclick="choiceAction(this,2)" style="cursor:pointer;">
                                                                <i Class="material-icons col-red">delete_forever</i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    choiceIndex = choiceIndex + 1
                                                Next
                                                </div>
                                                @<div class="row clearfix" id="add-choice-wrapper">
                                                    <span data-count="@question.Choices.Count" class="pull-right p-r-15 add-choice-button" style="cursor:pointer;" onclick="choiceAction(this,1)">
                                                        <small>Add another Choice</small>
                                                        <i class="material-icons font-18 col-green" style="position:relative;top:5px;">add_circle</i>
                                                    </span>
                                                </div>
                                                End If
                                        </div>
                                        <div Class="align-center">
                                            <Button type="button" Class="btn btn-danger btn-circle waves-effect waves-circle waves-float remove-question-btn">
                                                <i Class="material-icons">close</i>
                                            </Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                                                    qIndex = qIndex + 1
                                                Next
            </div>
        </div>
        <div Class="col-lg-12 align-center p-b-10">
            <!--ADD QUESTION BUTTON-->
            <Button id="add-question-btn" type="button" Class="btn btn-primary btn-circle-lg waves-effect waves-circle waves-float"
                    data-toggle="tooltip" data-placement="bottom" title="Click to add a Question">
                <i Class="material-icons">add</i>
            </Button>
            <!--SUBMIT BUTTON-->
            <Button id="add-question-btn" type="submit" Class="btn btn-success btn-circle-lg waves-effect waves-circle waves-float"
                    data-toggle="tooltip" data-placement="bottom" title="Click to submit form">
                <i Class="material-icons">save</i>
            </Button>
        </div>
    </div>  End Using


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
        $('.question-type-select').selectpicker();

        arrangeModelBinding(); //arranging model binding
        var max_questions = 4; //maximum input boxes allowed is 5
        var wrapper = $("#questions-row"); //Fields wrapper
        var answerContainer = $("#answerContainer"); //Answer Container
        var add_button = $("#add-question-btn"); //Add button ID
        var x = $('.question-field').length; //initlal text box count
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
                                                    '<div class="row">' +
                                                        '<div class="col-lg-9">' +
                                                            '<div class="form-group">' +
                                                                '<div class="form-line">' +
                                                                    '<input class="form-control question-field" placeholder="Question" type="text" value="" />' +
                                                                '</div>' +
                                                             '</div>' +
                                                        '</div>' +
                                                        '<div class="col-lg-3">' +
                                                            '<div class="form-group">' +
                                                                '<input type="hidden" class="question-type-field" value="short_answer" />' +
                                                                '<select class="form-control show-tick question-type-select" onchange="typeChanged(this)" required>' +
                                                                    '<option value="short_answer" selected>' +
                                                                        'Short Answer' +
                                                                    '</option>' +
                                                                    '<option value="multiple_choice">' +
                                                                        'Multiple Choice' +
                                                                    '</option>' +
                                                                '</select>' +
                                                            '</div>' +
                                                        '</div>' +
                                                    '</div>' +
                                                    '<div class="answer-container">' +
                                                        '<div class="form-group">' +
                                                            '<div class="form-line">' +
                                                                '<input class="form-control answer-field" placeholder="Answer" type="text" value="" />' +
                                                                '<div class="help-info">Answer strings are not case sensitive</div>' +
                                                            '</div>' +
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
        var shortAnswerFields
        var choicesInputGroup
        $('.question-field').each(function (i, obj) {
            //For the Question Field
            obj.id = "Questions_"+ (i) +"__Statement"
            obj.name = "Questions[" + (i) + "].Statement"

            //Arragning short answers by the QUESTION OBJECT they are in.
            shortAnswerFields = $(this).parent().parent().parent().parent().parent().find(".answer-field")
            shortAnswerFields.each(function (j, obj) {
                obj.id = "Questions_" + (i) + "__Answer"
                obj.name = "Questions[" + (i) + "].Answer"
            });

            choicesInputGroup = $(this).parent().parent().parent().parent().parent().find(".choice-input-group");
            arrangeChoiceModelBinding(choicesInputGroup, i);

        });
        $('.question-type-field').each(function (i, obj) {
            //For the Question Field
            obj.id = "Questions_" + (i) + "__Type"
            obj.name = "Questions[" + (i) + "].Type"

        });
        //FOR EDIT FORM ONLY SINCE THE ADD DOES NOT HAVE QUESTION ID YET
        $('.question-id-field').each(function (i, obj) {
            obj.id = "Questions_" + (i) + "__QuestionID"
            obj.name = "Questions[" + (i) + "].QuestionID"
        });

        $('.question-type-select').selectpicker();
    }

    function arrangeChoiceModelBinding(inputGroup,ctr) {
        //alert(inputGroup.length)
        //$(inputGroup).each(function (j, iGroup) {
        //    iGroup.id = "HATDOG";
        //})

        //arranging checkboxes ( isAnswer )
        inputGroup.find(".isAnswer-field").each(function (i, obj) {
            obj.id = "Questions_" + ctr + "__Choices_" + i + "__isAnswer"
            obj.name = "Questions[" + ctr + "].Choices[" + i + "].isAnswer"
        });
        inputGroup.find(".isAnswer-checkbox").each(function (i, obj) {
            obj.id = "Questions[" + ctr + "]Checkboxes[" + i + "]"
        });
        inputGroup.find("label").each(function (j, label) {
            label.setAttribute("for", "Questions[" + ctr + "]Checkboxes[" + j + "]");
        });

        //arranging Choices item field
        inputGroup.find(".choice-field").each(function (k, obj) {
            obj.id = "Questions_" + ctr + "__Choices_" + k + "__Item"
            obj.name = "Questions[" + ctr + "].Choices[" + k + "].Item"
        });
    }

    function checkBoxClicked(element) {
        //IMMITATE RADIO GROUP FOR CHECKBOXES
        //alert($(element).parent().parent().parent().parent().find('input[type="checkbox"]').length);
        var checkboxes = $(element).parent().parent().parent().parent().find('input[type="checkbox"]');
        checkboxes.each(function (i, cb) {
            if (cb === element) {
                cb.checked = true;
                //$(element).prev().val(true);
            } else {
                cb.checked = false;
                //$(element).prev().val(false);
            }

            if ($(this).is(":checked")) {
                //alert("Checkbox is checked.");
                $(this).prev().val(true)
            } else {
                //alert("Checkbox is NOT checked.");
                $(this).prev().val(false)
            }
        });

        //TO apply the TRUE FALSE value of the CHECKBOXES
        arrangeModelBinding();
    }
    function typeChanged(element) {
        //$(element).parent().parent().children("input").first().val($(element).val())
        var memberId = $(element).data("memberId");
        var memberName = $(element).data("memberName");
        var answerContainer = $(element).parent().parent().parent().parent().parent().find(".answer-container");

        if ($(element).val() === "short_answer") {
            //alert("SHORT ANSWER")
            answerContainer.children().remove();
            answerContainer.append(
                    '<div Class="form-group">' +
                        '<div Class="form-line">' +
                            '<input class="form-control answer-field" placeholder="Answer" type="text" data-index="0" />' +
                            '<div Class="help-info">Answer strings are Not case sensitive</div>' +
                        '</div>' +
                    '</div>'
                )
            $(element).parent().parent().find(".question-type-field").val("short_answer");
        } else if ($(element).val() === "multiple_choice") {
            //alert("MULTIPLE CHOICE")

            answerContainer.children().remove();
            answerContainer.append(
                   '<div class="row clearfix choices-wrapper">' +
                        '<div class="col-md-12" style="margin-bottom:0px;">' +
                            '<div class="input-group input-group-sm choice-input-group" style="margin-bottom:0px;">' +
                                '<span class="input-group-addon">' +
                                    '<input type="hidden" class="isAnswer-field" value="false" />' +
                                    '<input type="checkbox" onclick="checkBoxClicked(this)" class="chk-col-green isAnswer-checkbox"/>' +
                                    '<label class="isAnswer-checkbox-label"></label>' +
                                '</span>' +
                                '<div class="form-line">' +
                                    '<input type="text" class="form-control choice-field">' +
                                '</div>' +
                                '<span class="input-group-addon remove-choice-span" onclick="choiceAction(this,2)" style="cursor:pointer;">' +
                                        '<i class="material-icons col-red">delete_forever</i>' +
                                '</span>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                    '<div class="row clearfix" id="add-choice-wrapper">' +
                        '<span data-count="1" class="pull-right p-r-15 add-choice-button" style="cursor:pointer;" onclick="choiceAction(this,1)">' +
                            '<small>Add another Choice</small>' +
                            '<i class="material-icons font-18 col-green" style="position:relative;top:5px;">add_circle</i>' +
                        '</span>' +
                    '</div>'
               );
            $(element).parent().parent().find(".question-type-field").val("multiple_choice");
        }
        arrangeModelBinding();
    }
    function choiceAction(element, mode) {
        var maxChoices = 4;
        var choicesWrapper = $(element).parent().parent().find(".choices-wrapper");

        if (mode === 1) {
            //do the additions here
            var count = parseInt($(element).data("count"));
            if (count <= maxChoices) {
                var choiceNode = $(
                    '<div class="col-md-12" style="margin-bottom:0px;">' +
                        '<div class="input-group input-group-sm choice-input-group" style="margin-bottom:0px;">' +
                             '<span class="input-group-addon">' +
                                    '<input type="hidden" class="isAnswer-field" value="false" />' +
                                    '<input type="checkbox" onclick="checkBoxClicked(this)" class="chk-col-green isAnswer-checkbox"/>' +
                                    '<label class="isAnswer-checkbox-label"></label>' +
                                '</span>' +
                            '<div class="form-line">' +
                                '<input type="text" class="form-control choice-field">' +
                            '</div>' +
                            '<span class="input-group-addon remove-choice-span" onclick="choiceAction(this,2)" style="cursor:pointer;">' +
                                    '<i class="material-icons col-red">delete_forever</i>' +
                            '</span>' +
                        '</div>' +
                    '</div>'
                    );
                choiceNode.prependTo($(choicesWrapper));
                $(element).data("count", count+1);
            } else {
                swal("MAXIMUM CHOICES REACHED");
            }
        } else {
            var addChoiceBtn = $(element).parent().parent().parent().parent().find(".add-choice-button");
            count = parseInt(addChoiceBtn.data("count"));
            if (count > 1) {
                $(element).parent().remove();
                addChoiceBtn.data("count", count - 1);
            } else {
                swal("CANNOT REMOVE LAST ENTRY");
            }

        }
        arrangeModelBinding();
    }
    function choiceActionViewBuilder() {
        $('.question-field').each(function (i, obj) {
            //var choiceInputGroup = $(this).parent().parent().parent().parent().parent().find(".choice-input-group");
            var choiceInputGroup = $(this)

            var removeChoice = $('<span class="input-group-addon remove-choice-span">' +
                                    '<a onclick="choiceAction(this,2)" class="choice-action-remove">' +
                                        '<i class="material-icons col-red">delete_forever</i>' +
                                    '</a>' +
                                '</span>');
            var addChoice = $('<span class="input-group-addon add-choice-span">' +
                                '<a id="addChoiceBtn" onclick="choiceAction(this,1)" class="choice-action add" data-count=' + (choiceInputGroup.length - 1) + '>' +
                                    '<i class="material-icons col-green">add_circle_outline</i>' +
                                '</a>' +
                            '</span>');

            alert($(choiceInputGroup).className)
            choiceInputGroup.find('.add-choice-span').remove();
            choiceInputGroup.find(".remove-choice-span").each(function (j, remSpan) {
                remSpan.remove();
            });

            choiceInputGroup.each(function (k, iGroup) {
                if (k === (choiceInputGroup.length - 1)) {
                    addChoice.appendTo(iGroup);
                } else if(k < (choiceInputGroup.length - 1)) {
                    removeChoice.appendTo(iGroup);
                }
            });
        });
    }
</script>
End Section

