@Code
    ViewData("Title") = "CreateForm"
    Layout = ""
End Code
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
        <title>RevYou| @ViewBag.Title</title>
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
            .clearfix{
                padding-top:15px;
            }
            .card{
                padding-bottom:15px !important;
            }
        </style>
    </head>
<body class="theme-red">
    <section class="container">
        <div class="container-fluid">
            <!-- Advanced Form Example With Validation -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>ADVANCED FORM EXAMPLE WITH VALIDATION</h2>
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
                            <form id="wizard_with_validation" method="POST">
                                <h3>Account Information</h3>
                                <fieldset>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="text" class="form-control" name="username" required>
                                            <label class="form-label">Username*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="password" class="form-control" name="password" id="password" required>
                                            <label class="form-label">Password*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="password" class="form-control" name="confirm" required>
                                            <label class="form-label">Confirm Password*</label>
                                        </div>
                                    </div>
                                </fieldset>

                                <h3>Profile Information</h3>
                                <fieldset>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="text" name="name" class="form-control" required>
                                            <label class="form-label">First Name*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="text" name="surname" class="form-control" required>
                                            <label class="form-label">Last Name*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input type="email" name="email" class="form-control" required>
                                            <label class="form-label">Email*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <textarea name="address" cols="30" rows="3" class="form-control no-resize" required></textarea>
                                            <label class="form-label">Address*</label>
                                        </div>
                                    </div>
                                    <div class="form-group form-float">
                                        <div class="form-line">
                                            <input min="18" type="number" name="age" class="form-control" required>
                                            <label class="form-label">Age*</label>
                                        </div>
                                        <div class="help-info">The warning step will show up if age is less than 18</div>
                                    </div>
                                </fieldset>

                                <h3>Terms & Conditions - Finish</h3>
                                <fieldset>
                                    <input id="acceptTerms-2" name="acceptTerms" type="checkbox" required>
                                    <label for="acceptTerms-2">I agree with the Terms and Conditions.</label>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Advanced Form Example With Validation -->
        </div>
    </section>
            
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


            <script src="@Url.Content("~/Content/Template/js/pages/forms/form-wizard.js")"></script>
            <!-- Jquery Validation Plugin Css -->
            <script src="@Url.Content("~/Content/Template/plugins/jquery-validation/jquery.validate.js")"></script>

            <!-- JQuery Steps Plugin Js -->
            <script src="@Url.Content("~/Content/Template/plugins/jquery-steps/jquery.steps.js")"></script>

            <!-- Sweet Alert Plugin Js -->
            <script src="@Url.Content("~/Content/Template/plugins/sweetalert/sweetalert.min.js")"></script>
            
            <!--FOR REFRESHING THE PARENT-->
            <script>
                window.onunload = refreshParent;
                function refreshParent() {
                    window.opener.location.reload();
                }
            </script>
</body>
</html>

