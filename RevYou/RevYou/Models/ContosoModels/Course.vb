Imports System.ComponentModel.DataAnnotations.Schema
Namespace ContosoModels
    Public Class Course
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property CourseID As Integer
        Public Property Title As String
        Public Property Credits As Integer

        Public Overridable Property Enrollments As ICollection(Of Enrollment)
    End Class
End Namespace
