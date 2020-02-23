@ModelType IEnumerable(Of RevYou.ViewModels.User.ReviewerViewModel)

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Category.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.User.Username)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateCreated)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Category.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.User.Username)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateCreated)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.FormID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.FormID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.FormID })
        </td>
    </tr>
Next

</table>
