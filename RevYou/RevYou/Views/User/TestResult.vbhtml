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
        body{
            background-color:white;
        }
        .you-scored{
            font-size:50pt !important;
            margin-top:150px;
            margin-bottom:30px;
        }
        .score{
            font-size:25pt;
           
            border-radius:50px;
        }

        .peppy-image{
            position:fixed;
            bottom:-30px;
            left:10px;
        }
        .home-button{
            margin-top:50px;
            border-radius:20px;
            padding-right:100px;
            padding-left:100px;

        }
    </style>
</head>

<body class="theme-light-blue">
    <div class="container-fluid">
        <div class=" score-showcase align-center">
            <h1 class="you-scored"> YOU SCORED:</h1>
            @If ViewBag.Grade = "pass" Then
                @<Span Class="label bg-green score">@ViewBag.Score/@ViewBag.TotalQuestion</Span>
            ElseIf ViewBag.Grade = "fail" Then
                @<Span Class="label bg-red score">@ViewBag.Score/@ViewBag.TotalQuestion</Span>
            End If
        <div class="row home-button">
            <div class="col-lg-12">
                <button type="button" class="btn btn-block btn-lg bg-light-blue waves-effect" style="border-radius:50px;" onclick="goToProfile('/User/Profile/@User.Identity.Name')">HOME</button>
            </div>
        </div>
        </div>
    </div>
    @If ViewBag.Grade = "pass" Then
        @<img src="@Url.Content("~/Content/RevYou/images/celebrate-peppy.gif")" width="350" height="300" alt="Logo" class="peppy-image">
    ElseIf ViewBag.Grade = "fail" Then
        @<img src="@Url.Content("~/Content/RevYou/images/peppy-cry.gif")" width="320" height="300" alt="Logo" class="peppy-image">
    End If
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
        function goToProfile(link) {
            window.opener.location.href = link;
            window.close();
        }
    </script>
</body>

</html>