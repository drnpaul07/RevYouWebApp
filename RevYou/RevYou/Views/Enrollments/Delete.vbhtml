@ModelType RevYou.Models.Enrollment
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Enrollment</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Course.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Course.Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Student.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Student.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Grade)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Grade)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
