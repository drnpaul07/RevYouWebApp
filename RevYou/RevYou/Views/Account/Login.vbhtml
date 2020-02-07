@Code
    Layout = ""
    ViewBag.Title = "Log in"
End Code
@ModelType LoginViewModel
<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>RevYou | @ViewBag.Title</title>
    <!-- Favicon-->
    <link rel="icon" href="@Url.Content("~/Content/Template/favicon.ico")" type="image/x-icon">
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
    <style>
        .login-page{
            background-color: #03A9F4 !important;
        }
    </style>
</head>

<body class="login-page">
    <div class="login-box">
        <div class="logo">
            <a href="javascript:void(0);">Rev<b>You</b></a>
            <small>Enjoy Paperless and Personalized Reviewers</small>
        </div>
        <div class="card">
            <div class="body">
            @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.id = "sign_in", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @<div Class="msg">Sign in to start your session</div>
                @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">person</i>
                        </span>
                        <div Class="form-line">
                            <input type="text" class="form-control" name="Username" id="Username" placeholder="Username" required autofocus>
                        </div>
                    </div>
                    @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">lock</i>
                        </span>
                        <div Class="form-line">
                            <input type="Password" class="form-control" name="Password" id="Password" placeholder="Password" required>
                        </div>
                    </div>
                    @<div Class="row">
                        <div Class="col-xs-8 p-t-5">
                            <input type = "checkbox" name="RememberMe" id="RememberMe" Class="filled-in chk-col-pink">
                            <Label for="RememberMe">Remember Me</label>
                        </div>
                        <div Class="col-xs-4">
                            <Button Class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>
                        </div>
                    </div>
            End Using
                    <div Class="row m-t-15 m-b--20">
                        <div Class="col-xs-6">
                            <a href = "/Account/Register" > Register Now!</a>
                        </div>
                        <div Class="col-xs-6 align-right">
                            <a href = "forgot-password.html" > Forgot Password?</a>
                        </div>
                    </div>
            </div>
        </div>
    </div>

    <!-- Jquery Core Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/jquery/jquery.min.js")" ></script>
                                                                                                                                                                                                                                                                                                                                                                        
    <!-- Bootstrap Core Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/bootstrap/js/bootstrap.js")" ></script>
                                                                                                                                                                                                                                                                                                                                                                        
    <!-- Waves Effect Plugin Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/node-waves/waves.js")" ></script>
                                                                                                                                                                                                                                                                                                                                                                        
    <!-- Validation Plugin Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/jquery-validation/jquery.validate.js")" ></script>
                                                                                                                                                                                                                                                                                                                                                                        
    <!-- Custom Js -->
    <Script src = "@Url.Content("~/Content/Template/js/admin.js")" ></script>
    <Script src = "@Url.Content("~/Content/Template/js/pages/examples/sign-in.js")" ></script>
</body>

</html>