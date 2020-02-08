Namespace ContosoModels
    Public Enum Grade
        A
        B
        C
        D
        E
        F
    End Enum
    Public Class Enrollment
        Public Property EnrollmentID As Integer
        Public Property CourseID As Integer
        Public Property StudentID As Integer
        Public Property Grade As Grade?

        Public Overridable Property Course As Course
        Public Overridable Property Student As Student
    End Class
End Namespace