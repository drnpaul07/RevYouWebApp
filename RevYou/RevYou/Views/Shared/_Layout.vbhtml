@Imports Microsoft.AspNet.Identity
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="@Url.Content("~/Content/Template/assets/images/favicon.png")">
    <!-- Custom CSS -->
    <link href="@Url.Content("~/Content/Template/assets/extra-libs/c3/c3.min.css")" rel="stylesheet">
    <link href="@Url.Content("~/Content/Template/assets/libs/chartist/dist/chartist.min.css")" rel="stylesheet">
    <link href="@Url.Content("~/Content/Template/assets/extra-libs/jvector/jquery-jvectormap-2.0.2.css")" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="@Url.Content("~/Content/Template/dist/css/style.min.css")" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    @If Request.IsAuthenticated Then
        @<title>RevYou (Auth) | @ViewBag.Title</title>
    Else
        @<title>RevYou (Anon)  | @ViewBag.Title</title>
    End If
    <!--Styles.Render("~/Content/css")-->
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <!--TEMPLATE LAYOUT CONTENTS-->
    <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <div class="preloader">
        <div class="lds-ripple">
            <div class="lds-pos"></div>
            <div class="lds-pos"></div>
        </div>
    </div>
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->
    <div id="main-wrapper" data-theme="light" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
         data-sidebar-position="fixed" data-header-position="fixed" data-boxed-layout="full">
        <!-- ============================================================== -->
        <!-- Topbar header - style you can find in pages.scss -->
        <!-- ============================================================== -->
        <header class="topbar" data-navbarbg="skin6">
            <nav class="navbar top-navbar navbar-expand-md">
                <div class="navbar-header" data-logobg="skin6">
                    <!-- This is for the sidebar toggle which is visible on mobile only -->
                    <a class="nav-toggler waves-effect waves-light d-block d-md-none" href="javascript:void(0)">
                        <i class="ti-menu ti-close"></i>
                    </a>
                    <!-- ============================================================== -->
                    <!-- Logo -->
                    <!-- ============================================================== -->
                    <div class="navbar-brand">
                        <!-- Logo icon -->
                        <a href="/Home/Dashboard">
                            <b class="logo-icon">
                                <!-- Dark Logo icon -->
                                <img width ="50" height="50" src="@Url.Content("~/Content/Template/assets/images/logo-icon.png")" alt="homepage" class="dark-logo">
                                <!-- Light Logo icon -->
                                <img width ="50" height="50" src="@Url.Content("~/Content/Template/assets/images/logo-icon.png")" alt="homepage" class="light-logo">
                            </b>
                            <!--End Logo icon -->
                            <!-- Logo text -->
                            <span class="logo-text">
                                <!-- dark Logo text -->
                                <img  width ="110" height="25" src="@Url.Content("~/Content/RevYou/img/revyou-title.png")" alt="homepage" class="dark-logo">
                                <!-- Light Logo text -->
                                <img  width ="110" height="25"src="@Url.Content("~/Content/RevYou/img/revyou-title.png")" class="light-logo" alt="homepage">
                            </span>
                        </a>
                    </div>
                    <!-- ============================================================== -->
                    <!-- End Logo -->
                    <!-- ============================================================== -->
                    <!-- ============================================================== -->
                    <!-- Toggle which is visible on mobile only -->
                    <!-- ============================================================== -->
                    <a class="topbartoggler d-block d-md-none waves-effect waves-light" href="javascript:void(0)"
                       data-toggle="collapse" data-target="#navbarSupportedContent"
                       aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <i class="ti-more"></i>
                    </a>
                </div>
                <!-- ============================================================== -->
                <!-- End Logo -->
                <!-- ============================================================== -->
                <div class="navbar-collapse collapse" id="navbarSupportedContent">
                    <!-- ============================================================== -->
                    <!-- toggle and nav items -->
                    <!-- ============================================================== -->
                    <ul class="navbar-nav float-left mr-auto ml-3 pl-1">
                        <!-- Notification -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle pl-md-3 position-relative" href="javascript:void(0)"
                               id="bell" role="button" data-toggle="dropdown" aria-haspopup="true"
                               aria-expanded="false">
                                <span><i data-feather="bell" class="svg-icon"></i></span>
                                <span class="badge badge-primary notify-no rounded-circle">5</span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-left mailbox animated bounceInDown">
                                <ul class="list-style-none">
                                    <li>
                                        <div class="message-center notifications position-relative">
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                               class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <div class="btn btn-danger rounded-circle btn-circle">
                                                    <i data-feather="airplay" class="text-white"></i>
                                                </div>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Luanch Admin</h6>
                                                    <span class="font-12 text-nowrap d-block text-muted">
                                                        Just see
                                                        the my new
                                                        admin!
                                                    </span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:30 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                               class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-success text-white rounded-circle btn-circle">
                                                    <i data-feather="calendar" class="text-white"></i>
                                                </span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Event today</h6>
                                                    <span class="font-12 text-nowrap d-block text-muted text-truncate">
                                                        Just
                                                        a reminder that you have event
                                                    </span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:10 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                               class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-info rounded-circle btn-circle">
                                                    <i data-feather="settings" class="text-white"></i>
                                                </span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Settings</h6>
                                                    <span class="font-12 text-nowrap d-block text-muted text-truncate">
                                                        You
                                                        can customize this template
                                                        as you want
                                                    </span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:08 AM</span>
                                                </div>
                                            </a>
                                            <!-- Message -->
                                            <a href="javascript:void(0)"
                                               class="message-item d-flex align-items-center border-bottom px-3 py-2">
                                                <span class="btn btn-primary rounded-circle btn-circle">
                                                    <i data-feather="box" class="text-white"></i>
                                                </span>
                                                <div class="w-75 d-inline-block v-middle pl-2">
                                                    <h6 class="message-title mb-0 mt-1">Pavan kumar</h6> <span class="font-12 text-nowrap d-block text-muted">
                                                        Just
                                                        see the my admin!
                                                    </span>
                                                    <span class="font-12 text-nowrap d-block text-muted">9:02 AM</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <a class="nav-link pt-3 text-center text-dark" href="javascript:void(0);">
                                            <strong>Check all notifications</strong>
                                            <i class="fa fa-angle-right"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <!-- End Notification -->
                        <!-- ============================================================== -->
                        <!-- create new -->
                        <!-- ============================================================== -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button"
                               data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i data-feather="settings" class="svg-icon"></i>
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Something else here</a>
                            </div>
                        </li>
                    </ul>
                    <!-- ============================================================== -->
                    <!-- Right side toggle and nav items -->
                    <!-- ============================================================== -->
                    <ul class="navbar-nav float-right">
                        @If Request.IsAuthenticated Then
                            @<!-- ============================================================== -->
                            @<!-- User profile And search -->
                            @<!-- ============================================================== -->
                            @<li Class="nav-item dropdown">
                                <a Class="nav-link dropdown-toggle" href="javascript:void(0)" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                    <img src = "@Url.Content("~/Content/Template/assets/images/users/profile-pic.jpg")" alt="user" Class="rounded-circle"
                                         width="40">
                                    <span Class="ml-2 d-none d-lg-inline-block">
                                        <span Class="text-dark">
                                        @User.Identity.GetUserName()
                                        </span> <i data-feather="chevron-down" class="svg-icon"></i>
                                    </span>
                                </a>
                                <div Class="dropdown-menu dropdown-menu-right user-dd animated flipInY">
                                    <a Class="dropdown-item" href="javascript:void(0)">
                                        <i data-feather="user"
                                           Class="svg-icon mr-2 ml-1"></i>
                                        My Profile
                                    </a>
                                    <a Class="dropdown-item" href="javascript:void(0)">
                                        <i data-feather="credit-card"
                                           Class="svg-icon mr-2 ml-1"></i>
                                        My Balance
                                    </a>
                                    <a Class="dropdown-item" href="javascript:void(0)">
                                        <i data-feather="mail"
                                           Class="svg-icon mr-2 ml-1"></i>
                                        Inbox
                                    </a>
                                    <div Class="dropdown-divider"></div>
                                    <a Class="dropdown-item" href="javascript:void(0)">
                                        <i data-feather="settings"
                                           Class="svg-icon mr-2 ml-1"></i>
                                        Account Setting
                                    </a>
                                    <div Class="dropdown-divider"></div>

                                    <!--LOGOUT FORM-->
                                    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm"})
                                        @Html.AntiForgeryToken()
                                        @<a Class="dropdown-item" href="javascript:document.getElementById('logoutForm').submit()">
                                            <i data-feather="power"
                                               Class="svg-icon mr-2 ml-1"></i>
                                            Logout
                                        </a>
                                    End Using
                                    @*<div class="dropdown-divider"></div>*@
                                </div>
                            </li>
                            @<!-- ============================================================== -->
                            @<!-- User profile And search -->
                            @<!-- ============================================================== -->
                        Else
                            @<li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
                            @<li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
                        End If
                        
                    </ul>
                </div>
            </nav>
        </header>
        <!-- ============================================================== -->
        <!-- End Topbar header -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        <aside class="left-sidebar" data-sidebarbg="skin6">
            <!-- Sidebar scroll-->
            <div class="scroll-sidebar" data-sidebarbg="skin6">
                <!-- Sidebar navigation-->
                <nav class="sidebar-nav">
                    <ul id="sidebarnav">
                        <!--CHECKS FOR THE URI - HOME-->
                        @Code
                            Dim classString As String

                            If HttpContext.Current.Request.Url.AbsolutePath = "/Home/Dashboard" Then
                                classString = "sidebar-item selected"
                            Else
                                classString = "sidebar-item"
                            End If
                        End Code

                        <li Class="list-divider"></li>
                        @*<li Class="nav-small-cap"><span class="hide-menu">Default Navigation</span></li>*@
                        <li Class="@classString">
                            <a Class="sidebar-link sidebar-link" href="/Home/Dashboard"
                               aria-expanded="false">
                                <i data-feather="home" Class="feather-icon"></i><span Class="hide-menu">Dashboard</span>
                            </a>
                        </li>

                        <li Class="sidebar-item">
                            <a Class="sidebar-link sidebar-link" href="app-chat.html"
                               aria-expanded="false">
                                <i data-feather="message-square" Class="feather-icon"></i><span Class="hide-menu">Chat Bot</span>
                            </a>
                        </li>

                        <li class="sidebar-item">
                            <a class="sidebar-link has-arrow" href="javascript:void(0)"
                               aria-expanded="false">
                                <i data-feather="file-text" class="feather-icon"></i><span class="hide-menu">RevYou</span>
                            </a>
                            <ul aria-expanded="false" class="collapse  first-level base-level-line">
                                <li class="sidebar-item">
                                    <a href="/Home/Index" class="sidebar-link">
                                        <span class="hide-menu">
                                            Index
                                        </span>
                                    </a>
                                </li>
                                <li class="sidebar-item">
                                    <a href="/Home/About" class="sidebar-link">
                                        <span class="hide-menu">
                                            About
                                        </span>
                                    </a>
                                </li>
                                <li class="sidebar-item">
                                    <a href="/Home/Contact" class="sidebar-link">
                                        <span class="hide-menu">
                                            Contact
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </li>

                        <li Class="list-divider"></li>

                        <li Class="nav-small-cap"><span class="hide-menu">Community</span></li>

                        <li Class="sidebar-item">
                            <a Class="sidebar-link" href="ticket-list.html"
                               aria-expanded="false">
                                <i data-feather="tag" Class="feather-icon"></i><span Class="hide-menu">
                                    Ticket List
                                </span>
                            </a>
                        </li>
                        <li Class="sidebar-item">
                            <a Class="sidebar-link sidebar-link" href="app-chat.html"
                               aria-expanded="false">
                                <i data-feather="message-square" Class="feather-icon"></i><span Class="hide-menu">Chat</span>
                            </a>
                        </li>
                        <li Class="sidebar-item">
                            <a Class="sidebar-link sidebar-link" href="app-calendar.html"
                               aria-expanded="false">
                                <i data-feather="calendar" Class="feather-icon"></i><span Class="hide-menu">Calendar</span>
                            </a>
                        </li>

                        <li Class="list-divider"></li>
                       
                    </ul>
                </nav>
                <!-- End Sidebar navigation -->
            </div>
            <!-- End Sidebar scroll-->
        </aside>
        <!-- ============================================================== -->
        <!-- End Left Sidebar - style you can find in sidebar.scss  -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Page wrapper  -->
        <!-- ============================================================== -->
        <div Class="page-wrapper">
            <!-- ============================================================== -->
            <!-- Container fluid  -->
            <!-- ============================================================== -->
            <div Class="container-fluid">
                <!--BODY WOULD START HERE-->
                @RenderBody()
                <!--END OF BODY HERE-->
            </div>
            <!-- ============================================================== -->
            <!-- End Container fluid  -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- footer -->
            <!-- ============================================================== -->
            <footer class="footer text-center text-muted">
                All Rights Reserved by RevYou
            </footer>
            <!-- ============================================================== -->
            <!-- End footer -->
            <!-- ============================================================== -->
        </div>
        <!-- ============================================================== -->
        <!-- End Page wrapper  -->
        <!-- ============================================================== -->
    </div>
    <!--END OF TEMPLATE LAYOUT CONTENTS-->
    <!--Scripts.Render("~/bundles/jquery")-->
    <!--Scripts.Render("~/bundles/bootstrap")-->
    @RenderSection("scripts", required:=False)

    <!--DEFAULT SCRIPTS FROM THE TEMPLATE-->
    <script src="@Url.Content("~/Content/Template/assets/libs/jquery/dist/jquery.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/libs/popper.js/dist/umd/popper.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/libs/bootstrap/dist/js/bootstrap.min.js")"></script>
    <!-- apps -->
    <!-- apps -->
    <script src="@Url.Content("~/Content/Template/dist/js/app-style-switcher.js")"></script>
    <script src="@Url.Content("~/Content/Template/dist/js/feather.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/dist/js/sidebarmenu.js")"></script>
    <!--Custom JavaScript -->
    <script src="@Url.Content("~/Content/Template/dist/js/custom.min.js")"></script>
    <!--This page JavaScript -->
    <script src="@Url.Content("~/Content/Template/assets/extra-libs/c3/d3.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/extra-libs/c3/c3.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/libs/chartist/dist/chartist.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/libs/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/extra-libs/jvector/jquery-jvectormap-2.0.2.min.js")"></script>
    <script src="@Url.Content("~/Content/Template/assets/extra-libs/jvector/jquery-jvectormap-world-mill-en.js")"></script>
    <script src="@Url.Content("~/Content/Template/dist/js/pages/dashboards/dashboard1.min.js")"></script>
</body>
</html>
