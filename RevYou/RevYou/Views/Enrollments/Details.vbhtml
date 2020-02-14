@ModelType RevYou.ContosoModels.Enrollment
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.EnrollmentID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
