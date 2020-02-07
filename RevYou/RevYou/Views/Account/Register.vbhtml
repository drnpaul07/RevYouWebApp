@ModelType RegisterViewModel
@Code
    Layout = ""
    ViewBag.Title = "Register"
End Code

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>Sign Up | Bootstrap Based Admin Template - Material Design</title>
    <!-- Favicon-->
    <link rel="icon" href="../../favicon.ico" type="image/x-icon">

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
        .signup-page {
            background-color: #03A9F4 !important;
        }
    </style>
</head>

<body class="signup-page">
    <div class="signup-box">
        <div class="logo">
            <a href="javascript:void(0);">Rev<b>You</b></a>
            <small>Enjoy Paperless and Personalized Reviewers</small>
        </div>
        <div class="card">
            <div class="body">
            @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form", .id = "sign_up"})
                @Html.AntiForgeryToken()
                    @<div Class="msg">Register a New membership</div>
                    @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">person</i>
                        </span>
                        <div Class="form-line">
                            <input type = "text" Class="form-control" name="Username" id="Username" placeholder="Username" required autofocus>
                        </div>
                    </div>
                    @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">email</i>
                        </span>
                        <div Class="form-line">
                            <input type = "email" Class="form-control" name="Email" id ="Email" placeholder="Email Address" required>
                        </div>
                    </div>
                    @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">lock</i>
                        </span>
                        <div Class="form-line">
                            <input type = "password" Class="form-control" name="Password" id="Password" minlength="6" placeholder="Password" required>
                        </div>
                    </div>
                    @<div Class="input-group">
                        <span Class="input-group-addon">
                            <i Class="material-icons">lock</i>
                        </span>
                        <div Class="form-line">
                            <input type = "password" Class="form-control" name="ConfirmPassword" id="ConfirmPassword" minlength="6" placeholder="Confirm Password" required>
                        </div>
                    </div>
                    @<div Class="input-group">
                        <input type = "checkbox" name="terms" id="terms" Class="filled-in chk-col-pink">
                        <Label for="terms">I read And agree to the <a href="javascript:void(0);">terms of usage</a>.</label>
                    </div>

                    @<Button Class="btn btn-block btn-lg bg-pink waves-effect" type="submit">SIGN UP</button>

                    @<div Class="m-t-25 m-b--5 align-center">
                        <a href = "/Account/Login" > You already have a membership?</a>
                    </div>
            End Using
            </div>
        </div>
    </div>

    <!-- Jquery Core Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/jquery/jquery.min.js")"></script>

    <!-- Bootstrap Core Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/bootstrap/js/bootstrap.js")"></script>

    <!-- Waves Effect Plugin Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/node-waves/waves.js")"></script>

    <!-- Validation Plugin Js -->
    <Script src = "@Url.Content("~/Content/Template/plugins/jquery-validation/jquery.validate.js")"></script>

    <!-- Custom Js -->
    <Script src = "@Url.Content("~/Content/Template/js/admin.js")"></script>
    <Script src = "@Url.Content("~/Content/Template/js/pages/examples/sign-up.js")"></script>
</body>

</html>