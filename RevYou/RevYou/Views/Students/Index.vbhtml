﻿@ModelType IEnumerable(Of RevYou.Models.Student)
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
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstMidName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EnrollmentDate)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    For Each enrollment In item.Enrollments
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstMidName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EnrollmentDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
        </td>
    </tr>
    Next
Next

</table>
