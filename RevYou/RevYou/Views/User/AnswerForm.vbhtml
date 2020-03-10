@ModelType RevYou.Models.Reviewer.Form 
@Code
    Layout = ""
    ViewBag.Title = "RevYou | View Form"
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
        .pager-nav{
            position:relative;
            width:100%;
        }
       

        
    </style>
</head>

<body class="theme-light-blue">
    <div class="container-fluid reviewer-body">
        <div class="">
           
            @Using Html.BeginForm("AnswerForm", "User", FormMethod.Post, New With {.role = "form", .id = "review_form"})
            @Html.AntiForgeryToken()
                @<!-- Align Links -->
                @<div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 reviewer-col">
                    <div class="card reviewer-content">
                        <div class="header">
                            <h2>
                                @Model.Title
                                <small>Created by @Model.User.Username, @Model.DateCreated</small>
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
                                <div class="col-lg-6">

                                </div>
                                <div class="col-lg-6">

                                </div>
                            </div>
                            @Code
                                Dim qIndex As Integer = 0
                            End Code
                            @For Each question In Model.Questions
                                qIndex = qIndex + 1
                                @<div class="row question-row" id="question_@qIndex" data-index="@qIndex">
                                    <div class="col-lg-12 question-col">
                                        <h4> @question.Statement</h4>
                                    </div>
                                    <div class="col-lg-5 col-sm-12 col-md-8 answer-col">
                                        <div class="form-group form-group-lg">
                                            <div class="form-line">
                                                <input type="text" class="form-control align-center" placeholder="Enter your answer here..">
                                            </div>
                                        </div>
                                    </div>
                            </div>
                            Next
                            
                        </div>
                        
                        <nav class="pager-nav">
                            <div class="progress reviewer-progress">
                                <div id="reviewProgressBar" class="progress-bar bg-cyan progress-bar-striped active" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="@Model.Questions.Count">
                                    TEXT
                                </div>
                            </div>
                            <ul class="pager">
                                <li class="previous pull-left p-l-20">
                                    <button  id="previousButton" onclick="navigateQuestion(this,'prev')" data-last="0"
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
                            </ul>
                        </nav>
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
                }
            });

            //disable previous button when initialized
            $("#previousButton").prop('disabled', true);

            //progress initialization
            $("#reviewProgressBar").css("width", (parseInt($("#reviewProgressBar").attr("aria-valuenow")) / parseInt($("#reviewProgressBar").attr("aria-valuemax")) * 100) + "%");
            $("#reviewProgressBar").text("Question " + $("#reviewProgressBar").attr("aria-valuenow") + " out of " + $("#reviewProgressBar").attr("aria-valuemax"));
        });
        
  
        function navigateQuestion(element, action) {
            var previousButton = $("#previousButton");
            var nextButton = $("#nextButton");
            var questionRows = $(".question-row");
            //alert(questionRows.length);
            if (action === 'next') {
                console.log("Next Question Button was clicked!");
                console.log("QUESTION ROWS NUMBER:" + $(questionRows).length);

                //Progress bar ( for testing only )
                var valueNow = $("#reviewProgressBar").attr("aria-valuenow");
                    valueNow = parseInt(valueNow) + 1;
                var valueMax = $("#reviewProgressBar").attr("aria-valuemax");
                $("#reviewProgressBar").attr("aria-valuenow",valueNow)
                var progress = (parseInt(valueNow) / parseInt(valueMax)) * 100;
                $("#reviewProgressBar").css("width", progress + "%")
                $("#reviewProgressBar").text("Question " + $("#reviewProgressBar").attr("aria-valuenow") + " out of " + $("#reviewProgressBar").attr("aria-valuemax"));
                //Progress bar ( for testing only )

                $(previousButton).prop("disabled", false);
                if ($(element).data("next") <= questionRows.length) {
                    $(questionRows).each(function (i, obj) {
                        //I added 1 since 0 is the DISABLED index, so the first question should have index of 1
                        if ($(obj).data("index") === $(element).data("next")) {
                            $(obj).show();
                        } else {
                            $(obj).hide();
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
                }

                //disabler of next button
                if ($(element).data("next") === questionRows.length + 1) {
                    $("#nextButton").prop('disabled', true);
                } else {
                    $("#nextButton").prop('disabled', false);
                }
                
            } else if (action === 'prev') {
                console.log("Previous Question Button was clicked!");
                 $(nextButton).prop("disabled", false);
                if ($(element).data("last") > 0) {

                    $(questionRows).each(function (i, obj) {
                        if ($(obj).data("index") === $(element).data("last")) {
                            $(obj).show();
                        } else {
                            $(obj).hide();
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
    </script>
</body>

</html>