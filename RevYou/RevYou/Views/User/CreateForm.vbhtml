@Code
    ViewData("Title") = "Create Form"
End Code
@section local_styles
    <style>
        .q-card .body{
            padding-bottom:0px !important;
            padding-top: 20px !important;
            padding-left: 20px !important;
            padding-right: 20px !important;

            border-top:solid 5px #03A9F4 !important;
        }
        .form-card .body{
             border-top: solid 5px #0380bc !important;
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
            <i class="material-icons">library_books</i> Create Form
        </a>
    </li>
</ol>
<div class="row clearfix">
    <!--FORM DETAILS-->
    <div class="col-lg-12">
        <div class="card form-card">
            <div class="body">
                <div class="row clearfix">
                    <div class="col-sm-12">
                        <div class="form-group form-group-lg">
                            <div class="form-line">
                                <input type="text" class="form-control" placeholder="Untitled Form" />
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <div class="form-line">
                                <input type="text" class="form-control" placeholder="Description" />
                                <div class="help-info">Enter the form description here.</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--QUESTIONS-->
    <div class="col-lg-12">
        <!--QUESTIONS ROW-->
        <div class="row" id="questions-row">
            <!--QUESTION COL-->
            <div class="col-lg-12 question-col">
                <div class="card q-card">
                    <div class="body">
                        <div class="row clearfix">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="form-line">
                                        <input type="text" class="form-control" placeholder="Question" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-line">
                                        <input type="text" class="form-control" placeholder="Answer" />
                                        <div class="help-info">Answer strings are not case sensitive</div>
                                    </div>
                                </div>
                                <div class="align-center">
                                    <button type="button" class="btn btn-danger btn-circle waves-effect waves-circle waves-float remove-question-btn">
                                        <i class="material-icons">close</i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> 
            </div>
        </div>     
    </div>
    <div class="col-lg-12 align-center">
        <button id="add-question-btn" type="button" class="btn btn-default btn-circle-lg waves-effect waves-circle waves-float"
                data-toggle="tooltip" data-placement="bottom" title="Click to add a Question">
            <i class="material-icons">add</i>
        </button>
    </div>
</div>

@section local_scripts
<script>
    $(function () {
        var max_questions = 4; //maximum input boxes allowed is 5
        var wrapper = $("#questions-row"); //Fields wrapper
        var add_button = $("#add-question-btn"); //Add button ID
        var x = 0; //initlal text box count
        $(add_button).click(
                    function (e) {
                        //on add input button click
                        e.preventDefault();
                        if (x >= max_questions) {
                            alert("Maximum question count has been Reached");
                        } else {
                            $(wrapper).append(
                               '<div class="col-lg-12 question-col">'+
                                    '<div class="card q-card">'+
                                        '<div class="body">'+
                                            '<div class="row clearfix">'+
                                                '<div class="col-lg-12">'+
                                                    '<div class="form-group">'+
                                                        '<div class="form-line">'+
                                                            '<input type="text" class="form-control" placeholder="Question" />'+
                                                        '</div>'+
                                                    '</div>'+
                                                    '<div class="form-group">'+
                                                        '<div class="form-line">'+
                                                            '<input type="text" class="form-control" placeholder="Answer" />'+
                                                            '<div class="help-info">Answer strings are not case sensitive</div>'+
                                                        '</div>'+
                                                    '</div>'+
                                                    '<div class="align-center">'+
                                                        '<button type="button" class="btn btn-danger btn-circle waves-effect waves-circle waves-float remove-question-btn">' +
                                                            '<i class="material-icons">close</i>'+
                                                        '</button>'+
                                                    '</div>'+
                                                '</div>'+
                                            '</div>'+
                                        '</div>'+
                                    '</div>'+
                                '</div>'
                            )
                            x++;
                        }
                    })

        $(wrapper).on("click", ".remove-question-btn", function (e) {
            //user click on remove field
            e.preventDefault();
            if (x <= 0) {
                alert("Cannot remove the last Question")
            } else {
                $(this).parent().parent().parent().parent().parent(".q-card").remove();
                x--;
            }
               
            });
    })
</script>
End Section

