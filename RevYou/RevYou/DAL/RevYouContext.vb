Imports RevYou.Models.Reviewer
Imports RevYou.Models.Base
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Namespace DAL
    Public Class RevYouContext
        Inherits DbContext


        Public Sub New()
            MyBase.New("RevYouContext")
        End Sub

        Public Property Form As DbSet(Of Form)
        Public Property Question As DbSet(Of Question)
        Public Property UserData As DbSet(Of UserData)

        'Pluralizer ( on DB ) can be enabled by deleting this overriding sub
        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        End Sub

    End Class
End Namespace


