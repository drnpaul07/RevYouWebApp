@ModelType RevYou.ViewModels.User.AnsweringFormViewModel
@Code
    Layout = ""
    ViewBag.Title = "View Form"
End Code
<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>RevYou | @ViewBag.Title</title>
    <!-- Favicon-->
    @*<link rel="icon" href="@Url.Content("~/Content/Template/favicon.ico")" type="image/x-icon">*@

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

    <!-- Bootstrap Core Css -->
    <link href="@Url.Content("~/Content/Template/plugins/bootstrap/css/bootstrap.css")" rel="stylesheet">

    <!-- Waves Effect Css -->
    <link href="@Url.Content("~/Content/Template/plugins/node-waves/waves.css")" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="@Url.Content("~/Content/Template/plugins/animate-css/animate.css")" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="@Url.Content("~/Content/Template/css/style.css")" rel="stylesheet">

    <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
    <link href="@Url.Content("~/Content/Template/css/themes/all-themes.css")" rel="stylesheet" />
    <style>
        .reviewer-body{
           
        }
        .reviewer-content{
            height:100vh !important;
            margin-bottom: 0px;
            display: flex;
            flex-direction: column;
            justify-content: space-between;

        }
        .reviewer-col{
            padding:0px;
        }
        .reviewer-content .body{
            height:100%;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }
        .reviewer-content .body .reviewer-status{
            height:100px;
            border-bottom: 1px solid rgba(204, 204, 204, 0.35);
            margin-bottom:50px;
        }
        .reviewer-content .body .question-row{
            height:100%;

            display: flex;
            flex-direction: column;

        }
         .reviewer-progress{
            margin-left:10px;
            margin-right:10px;
           border-radius:10px;
        }
        .answer-col{
            height:100%;
            width:90%;
            display:flex;
            align-items:center;
            
            margin-left:auto;
            margin-right:auto;
        }
        .choices-col{
            height:100%;
            width:90%;
            align-items:center;
            margin-right:auto;
            margin-left:auto;
            padding-top:50px;
        }
        .pager-nav{
            /*position:relative;*/
            width:100%;
        }
    </style>
</head>

<body class="theme-light-blue">
    <div class="container-fluid reviewer-body">
        <div class="">

            @Using Html.BeginForm("AnswerForm", "User", FormMethod.Post, New With {.role = "form", .id = "review_form", .onsubmit = "closeThis(this)"})
                @Html.AntiForgeryToken()
                @<input type="hidden" id="FormID" name="FormID" value="@ViewBag.Form.FormID"/>
                @<!-- Align Links -->
                @<div class="row clearfix">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 reviewer-col">
                        <div class="card reviewer-content">
                            <div class="header">
                                <h2>
                                    @ViewBag.Form.Title
                                    <small>Created by @ViewBag.Form.User.Username, @ViewBag.Form.DateCreated</small>
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
                                <div class="row reviewer-status">
                                    <div class="col-sm-6">
                                        
                                    </div>
                                    <div class="col-sm-6">
                                        
                                    </div>
                                    <div class="col-sm-6">
                                        
                                    </div>
                                    <div class="col-sm-6">
                                        
                                    </div>
                                </div>
                                @Code
                                    Dim qIndex As Integer = 0
                                    Dim divIndex As Integer = 0
                                End Code
                                @For Each question In ViewBag.Form.Questions
                                    divIndex = qIndex + 1
                                    @<div class="row question-row" id="question_@divIndex" data-index="@divIndex">
                                        @*@Html.HiddenFor(Function(m) m.QAList(qIndex).QuestionID)*@
                                        <input type="hidden" id="QAList_@(qIndex)__QuestionID" name="QAList[@qIndex].QuestionID" value="@question.QuestionID" />
                                        @*@Html.HiddenFor(Function(m) m.QAList(qIndex).QuestionType)*@
                                        <input type="hidden" id="QAList_@(qIndex)__QuestionID" name="QAList[@qIndex].QuestionType" value="@question.Type" />
                                        <div class="col-lg-12 question-col">
                                            <h4> @question.Statement</h4>
                                        </div>
                                        @If question.Type = "short_answer" Then
                                            @<div Class="col-lg-5 col-sm-12 col-md-8 answer-col">
                                                <div Class="form-group form-group-lg">
                                                    <div Class="form-line">
                                                        @Html.TextBoxFor(Function(m) m.QAList(qIndex).AnswerString, New With {.class = "form-control align-center", .placeholder = "Enter your answer here.."})
                                                    </div>
                                                </div>
                                            </div>
                                        ElseIf question.Type = "multiple_choice" Then
                                            @Code
                                                Dim chIndex As String = 0
                                            End Code
                                            @<div Class="col-lg-5 col-sm-12 col-md-8 choices-col">
                                                @For Each choice In question.Choices
                                                    @Html.HiddenFor(Function(m) m.QAList(qIndex).ChoiceID, New With {.data_question_id = question.QuestionID, .class = "choice-field"})
                                                    @<div class="container">
                                                        <input type="checkbox" Class="chk-col-green choice-checkbox" id="checkbox-@(qIndex)@(chIndex)"
                                                               data-choice-id="@choice.ChoiceID" data-question-id="@question.QuestionID" />
                                                        <Label Class="choice-checkbox-label" for="checkbox-@(qIndex)@(chIndex)" onclick="checkBoxClicked(this)">@choice.Item</Label>
                                                    </div>
                                                    chIndex = chIndex + 1
                                                Next
                                            </div>
                                                End If
                                    </div>
                                                    qIndex = qIndex + 1
                                                Next

                                <nav class="pager-nav">
                                    <div class="progress reviewer-progress">
                                        <div id="reviewProgressBar" class="progress-bar bg-cyan progress-bar-striped active" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="@ViewBag.Form.Questions.Count">
                                            TEXT
                                        </div>
                                    </div>
                                    <ul class="pager">
                                        <li class="previous pull-left p-l-20">
                                            <button id="previousButton" onclick="navigateQuestion(this,'prev')" data-last="0"
                                                    type="button" class="btn bg-indigo waves-effect">
                                                <i class="material-icons">keyboard_arrow_left</i>
                                                <span>PREVIOUS</span>
                                            </button>
                                        </li>
                                        <li class="next pull-right p-r-20">
                                            <button id="nextButton" onclick="navigateQuestion(this,'next')" data-next="2"
                                                    type="button" class="btn bg-indigo waves-effect">
                                                <span>NEXT</span>
                                                <i class="material-icons">keyboard_arrow_right</i>
                                            </button>
                                        </li>

                                        <li class="next pull-right p-r-20" id="submitButtonLi">
                                            <button id="submitButton" type="submit" class="btn bg-light-blue waves-effect" form="review_form">
                                                <span>SUBMIT</span>
                                                <i class="material-icons">send</i>
                                            </button>
                                        </li>

                                    </ul>
                                </nav>
                            </div>

                            
                        </div>
                    </div>
                </div>
                @<!-- #END# Align Links -->
                                                End Using

        </div>

    </div>
    <!-- Jquery Core Js -->
    <script src="@Url.Content("~/Content/Template/plugins/jquery/jquery.min.js")"></script>
    <!-- Bootstrap Core Js -->
    <script src="@Url.Content("~/Content/Template/plugins/bootstrap/js/bootstrap.js")"></script>
    <!-- Select Plugin Js -->
    <script src="@Url.Content("~/Content/Template/plugins/bootstrap-select/js/bootstrap-select.js")"></script>
    <!-- Slimscroll Plugin Js -->
    <script src="@Url.Content("~/Content/Template/plugins/jquery-slimscroll/jquery.slimscroll.js")"></script>
    <!-- Waves Effect Plugin Js -->
    <script src="@Url.Content("~/Content/Template/plugins/node-waves/waves.js")"></script>
    <!-- Custom Js -->
    <script src="@Url.Content("~/Content/Template/js/admin.js")"></script>
    <!-- Demo Js -->
    <script src="@Url.Content("~/Content/Template/js/demo.js")"></script>
    <script>
        $(function () {
            $(".question-row").each(function (i, obj) {
                if ($(obj).data("index") !== 1) {
                    $(obj).hide();
                    //$(obj).css("display", "none");
                    
                }
            });

            //disable previous button when initialized
            $("#previousButton").prop('disabled', true);
            $("#submitButtonLi").hide();
            //disable next button if 1 question only
            if ($(".question-row").length <= 1) {
                $("#nextButton").prop('disabled', true);
                $("#nextButton").hide();
                $("#submitButtonLi").show();
            }

            //progress initialization
            $("#reviewProgressBar").css("width", (parseInt($("#reviewProgressBar").attr("aria-valuenow")) / parseInt($("#reviewProgressBar").attr("aria-valuemax")) * 100) + "%");
            $("#reviewProgressBar").text("Question " + $("#reviewProgressBar").attr("aria-valuenow") + " out of " + $("#reviewProgressBar").attr("aria-valuemax"));
        });
        function submitForm() {
            $("#review_form").submit();
        }
        function checkBoxClicked(element) {
            var sibCheckBox = $(element).prev();
            var checkBoxes = $(".choice-checkbox");
            console.log(checkBoxes.length);
            var sibCheckBoxes = $(element).parent().parent().find('input[type="checkbox"]')
            console.log(sibCheckBoxes.length)
            console.log($(sibCheckBox).data("questionId"))
            //immitating Radio Button Group
            //$(sibCheckBoxes).each(function (i, obj) {
            //    if ($(obj).data("questionId") === $(sibCheckBox).data("questionId")) {
            //        if ($(obj).data("choiceId") === $(sibCheckBox).data("choiceId")) {
            //            //console.log("OBJ is != to  $($(element).prev())")
            //            //$(obj).prop("checked", false);
            //            console.log("OBJ is == to  $($(element).prev())")
            //             $(obj).checked = true;
            //        } else {
            //            console.log("OBJ is != to  $($(element).prev())")
            //            console.log($(obj).data("choiceId"))
            //            console.log($(sibCheckBox).data("choiceId"))
            //            $(obj).checked  = false;   
            //        }
            //    }
            //});

            $(sibCheckBoxes).on('change', function() {
                $(sibCheckBoxes).not(this).prop('checked', false);
            });
            
            $(".choice-field").each(function (i, obj) {
                if ($(sibCheckBox).data("questionId") === $(obj).data("questionId")) {
                    $(obj).val($(element).prev().data("choiceId"))
                }
            })

        }
        function navigateQuestion(element, action) {
            var previousButton = $("#previousButton");
            var nextButton = $("#nextButton");
            var questionRows = $(".question-row");
            //alert(questionRows.length);
            if (action === 'next') {
                console.log("Next Question Button was clicked!");
                console.log("QUESTION ROWS NUMBER:" + $(questionRows).length);

                updateProgressBar("next");

                $(previousButton).prop("disabled", false);
                if ($(element).data("next") <= questionRows.length) {
                    $(questionRows).each(function (i, obj) {
                        //I added 1 since 0 is the DISABLED index, so the first question should have index of 1
                        if ($(obj).data("index") === $(element).data("next")) {
                            $(obj).show();
                            //$(obj).css("display", "block");
                        } else {
                            $(obj).hide();
                            //$(obj).css("display", "none");
                        }
                    });

                    $(element).data("next", $(element).data("next") + 1)
                    $(previousButton).data("last", $(previousButton).data("last") + 1)

                    console.log("NEXT CHANGED TO" + $(element).data("next"));
                    console.log("LAST CHANGED TO" + $(previousButton).data("last"));
                }
                //if max, no more increment
                else {
                    console.log("Cannot increment NEXT if Last Question")
                    $("#submitButtonLi").show();
                    $("#nextButton").hide();
                }

                //disabler of next button
                if ($(element).data("next") === questionRows.length + 1) {
                    $("#nextButton").prop('disabled', true);

                    //hides next, shows submit
                    $("#submitButtonLi").show();
                    $("#nextButton").hide();
                } else {
                    $("#nextButton").prop('disabled', false);

                    //shows next, hides submit
                    $("#submitButtonLi").hide();
                    $("#nextButton").show();
                }
                
            } else if (action === 'prev') {
                console.log("Previous Question Button was clicked!");
                $(nextButton).prop("disabled", false);
                //shows next, hides submit
                    $("#submitButtonLi").hide();
                    $("#nextButton").show();
                updateProgressBar(action)

                if ($(element).data("last") > 0) {

                    $(questionRows).each(function (i, obj) {
                        if ($(obj).data("index") === $(element).data("last")) {
                            $(obj).show();
                            //$(obj).css("display", "block");
                        } else {
                            $(obj).hide();
                            //$(obj).css("display", "none");
                        }
                    });
                    $(element).data("last", $(element).data("last") - 1)
                    $(nextButton).data("next", $(nextButton).data("next") - 1);

                    console.log("LAST CHANGED TO" + $(element).data("last"));
                    console.log("NEXT CHANGED TO" + $(nextButton).data("next"));
                } else {
                    console.log("Cannot decrement LAST if First Question");
                }
                //disabling PREV Button
                if ($(element).data("last") <= 0) {
                    $("#previousButton").prop('disabled', true);
                } else {
                    $("#previousButton").prop('disabled', false);
                }
                
            }
        }
        function updateProgressBar(action) {
            var valueNow = $("#reviewProgressBar").attr("aria-valuenow");
            var valueMax = $("#reviewProgressBar").attr("aria-valuemax");
            if (action === "next") {
                valueNow = parseInt(valueNow) + 1;
            } else {
                valueNow = parseInt(valueNow) - 1;
            }
            //draw progress bar
            $("#reviewProgressBar").attr("aria-valuenow",valueNow)
                var progress = (parseInt(valueNow) / parseInt(valueMax)) * 100;
            $("#reviewProgressBar").css("width", progress + "%")
            $("#reviewProgressBar").text("Question " + $("#reviewProgressBar").attr("aria-valuenow") + " out of " + $("#reviewProgressBar").attr("aria-valuemax"));  
        } 
        function closeThis(form) {
            form.submit();
        }
    </script>
</body>

</html>