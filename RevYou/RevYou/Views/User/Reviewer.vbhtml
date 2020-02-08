@Code
    ViewData("Title") = "Reviewers"
End Code
@section local_styles
    <style>
        #reviewer-container{
            min-height: 75vh  !important;
        }
    </style>
End Section

@section local_scripts
<script>
    function openFormWizardA() {
        'use strict';
        let params = `scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,width=1000,height=1000,left=0,top=0`;
        window.open('/User/CreateForm', 'test', params);
        
    }
</script>
<Script src="@Url.Content("~/Content/RevYou/js/rev-popup.js")"></Script>
End Section

<ol class="breadcrumb pull-right">
    <li>
        <a href="javascript:popupCenter({url: '/User/CreateForm', title: 'Create Form', w: 1100, h: 550});;">
            <i class="material-icons">home</i> User
        </a>
    </li>
    <li  class="active">
        <a href="javascript:void(0);">
            <i class="material-icons">library_books</i> Reviewers
        </a>
    </li>
</ol>

<!-- Tabs With Icon Title -->
<div class="row clearfix">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div class="card" id="reviewer-container">
            <div class="header">
                <h2>
                    YOUR REVIEWERS
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
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active">
                        <a href="#home_with_icon_title" data-toggle="tab">
                            <i class="material-icons">home</i> HOME
                        </a>
                    </li>
                    <li role="presentation">
                        <a href="#profile_with_icon_title" data-toggle="tab">
                            <i class="material-icons">face</i> PROFILE
                        </a>
                    </li>
                    <li role="presentation">
                        <a href="#messages_with_icon_title" data-toggle="tab">
                            <i class="material-icons">email</i> MESSAGES
                        </a>
                    </li>
                    <li role="presentation">
                        <a href="#settings_with_icon_title" data-toggle="tab">
                            <i class="material-icons">settings</i> SETTINGS
                        </a>
                    </li>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="home_with_icon_title">
                        <b>Home Content</b>
                        <p>
                            Lorem ipsum dolor sit amet, ut duo atqui exerci dicunt, ius impedit mediocritatem an. Pri ut tation electram moderatius.
                            Per te suavitate democritum. Duis nemore probatus ne quo, ad liber essent aliquid
                            pro. Et eos nusquam accumsan, vide mentitum fabellas ne est, eu munere gubergren
                            sadipscing mel.
                        </p>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="profile_with_icon_title">
                        <b>Profile Content</b>
                        <p>
                            Lorem ipsum dolor sit amet, ut duo atqui exerci dicunt, ius impedit mediocritatem an. Pri ut tation electram moderatius.
                            Per te suavitate democritum. Duis nemore probatus ne quo, ad liber essent aliquid
                            pro. Et eos nusquam accumsan, vide mentitum fabellas ne est, eu munere gubergren
                            sadipscing mel.
                        </p>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="messages_with_icon_title">
                        <b>Message Content</b>
                        <p>
                            Lorem ipsum dolor sit amet, ut duo atqui exerci dicunt, ius impedit mediocritatem an. Pri ut tation electram moderatius.
                            Per te suavitate democritum. Duis nemore probatus ne quo, ad liber essent aliquid
                            pro. Et eos nusquam accumsan, vide mentitum fabellas ne est, eu munere gubergren
                            sadipscing mel.
                        </p>
                    </div>
                    <div role="tabpanel" class="tab-pane fade" id="settings_with_icon_title">
                        <b>Settings Content</b>
                        <p>
                            Lorem ipsum dolor sit amet, ut duo atqui exerci dicunt, ius impedit mediocritatem an. Pri ut tation electram moderatius.
                            Per te suavitate democritum. Duis nemore probatus ne quo, ad liber essent aliquid
                            pro. Et eos nusquam accumsan, vide mentitum fabellas ne est, eu munere gubergren
                            sadipscing mel.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- #END# Tabs With Icon Title -->


