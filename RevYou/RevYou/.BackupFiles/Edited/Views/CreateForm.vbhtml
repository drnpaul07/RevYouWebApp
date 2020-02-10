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
        <link href="@Url.Content("~/Content/Template/plugins/bootstrap/css/bootstrap.min.css")" rel="stylesheet">

        <!-- Waves Effect Css -->
        <link href="@Url.Content("~/Content/Template/plugins/node-waves/waves.css")" rel="stylesheet" />

        <!-- Animation Css -->
        <link href="@Url.Content("~/Content/Template/plugins/animate-css/animate.css")" rel="stylesheet" />

        <!-- Custom Css -->
        <link href="@Url.Content("~/Content/Template/css/style.css")" rel="stylesheet">

        <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
        <link href="@Url.Content("~/Content/Template/css/themes/all-themes.css")" rel="stylesheet" />
        <!-- Bootstrap Select Css -->
        <link href="@Url.Content("~/Content/Template/plugins/bootstrap-select/css/bootstrap-select.css")" rel="stylesheet" />
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
        <div class="row">
            <section class="col-lg-12 connectedSortable ui-sortable">
                <div class="container-fluid">
                    <!-- Advanced Form Example With Validation -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>CREATE YOUR OWN FORM</h2>
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
                                        <h3>Form Details</h3>
                                        <fieldset>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <input type="text" class="form-control" name="username" required>
                                                    <label class="form-label">Form Title*</label>
                                                </div>
                                            </div>
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                    <input type="text" class="form-control" name="password" id="password" required>
                                                    <label class="form-label">Form Description*</label>
                                                </div>
                                            </div>
                                        </fieldset>

                                        <h3>Questions</h3>
                                        <fieldset id="question-fs">
                                            <!--THIS IS THE START OF QUESTION SERIES-->
                                            <div>
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <input type="text" name="name" class="form-control" required>
                                                        <label class="form-label">Question*</label>
                                                    </div>
                                                </div>

                                                <div class="input-group form-float">
                                                    <div class="row clearfix">
                                                        <div class="col-sm-12">
                                                            <select class="form-control show-tick form-line" id="question-type">
                                                                <option value="short">Short Answer</option>
                                                                <option value="">-- Please select Type --</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--SHOULD ENCAPSULATE THIS DIV BASED ON THE TYPE-->
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <input type="text" name="answer" class="form-control" required>
                                                        <label class="form-label">Answer*</label>
                                                        <div class="help-info">Answer string is not Case Sensitive</div>
                                                    </div>
                                                </div>
                                                <!--SHOULD ENCAPSULATE THIS DIV BASED ON THE TYPE-->
                                            </div>
                                            <!--THIS IS THE END OF QUESTION SERIES-->
                                        </fieldset>

                                        <h3>Preview of the Form</h3>
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
        </div>
    </section>
            <!-- Jquery Core Js -->
            <script src="@Url.Content("~/Content/Template/plugins/jquery/jquery.min.js")"></script>
            <!-- Bootstrap Core Js -->
            <script src="@Url.Content("~/Content/Template/plugins/bootstrap/js/bootstrap.js")"></script>
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

            <!-- Select Plugin Js -->
            <script src="@Url.Content("~/Content/Template/plugins/bootstrap-select/js/bootstrap-select.js")"></script>
            <!-- jQuery UI 1.11.4 -->
            <script src="@Url.Content("~/Content/RevYou/plugins/jquery-ui/jquery-ui.min.js")"></script>
            @*<script src="@Url.Content("~/Content/RevYou/plugins/jQueryUI/jquery-ui.min.js")"></script>*@
            <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
            <script>
                $.widget.bridge('uibutton', $.ui.button);
            </script>
            <!--FOR REFRESHING THE PARENT-->
            <script>
                window.onunload = refreshParent;
                function refreshParent() {
                    window.opener.location.reload();
                }
            </script>
            <script>
                $(function () {
                    $('#question-type').on('change', function () {
                        var choice = $("#question-type").val();
                    });
                });
            </script>
            <script>
                $(function () {
                    $(add_button).click(
                               function(e) { //on add input button click
                                   e.preventDefault();
                                   $(wrapper).append()
                               })
                })
            </script>
</body>
</html>

