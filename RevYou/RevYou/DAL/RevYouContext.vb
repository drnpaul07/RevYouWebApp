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
        Public Property Category As DbSet(Of Category)
        Public Property Tag As DbSet(Of Tag)

        'has Many-To-Many-Relationship
        Public Property UserTag As DbSet(Of UserTag)
        Public Property FormTag As DbSet(Of FormTag)

        'Pluralizer ( on DB ) can be enabled by deleting this overriding sub
        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

            'MANY TO MANY TABLE CASCADING
            modelBuilder.Entity(Of Tag)() _
                .HasMany(Function(m) m.UserTags) _
                .WithRequired(Function(m) m.Tag) _
                .WillCascadeOnDelete(False)

            modelBuilder.Entity(Of Tag)() _
                .HasMany(Function(m) m.FormTags) _
                .WithRequired(Function(m) m.Tag) _
                .WillCascadeOnDelete(False)
        End Sub

    End Class
End Namespace


