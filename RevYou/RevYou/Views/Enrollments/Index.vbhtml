@ModelType IEnumerable(Of RevYou.ContosoModels.Enrollment)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Course.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Student.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Grade)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Course.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Student.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Grade)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.EnrollmentID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.EnrollmentID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.EnrollmentID })
        </td>
    </tr>
Next

</table>
