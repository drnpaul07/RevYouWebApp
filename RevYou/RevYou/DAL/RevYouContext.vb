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
        'LATEST
        Public Property Result As DbSet(Of Result)
        Public Property UserActivity As DbSet(Of UserActivity)

        'has Many-To-Many-Relationship
        Public Property UserTag As DbSet(Of UserTag)
        Public Property FormTag As DbSet(Of FormTag)
        Public Property Choice As DbSet(Of Choice)

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

            'WITH LATEST AND WOULD NOT CASCADE DELETE MODELS
            'USERDATA
            modelBuilder.Entity(Of UserData)() _
                .HasMany(Function(m) m.UserActivities) _
                .WithRequired(Function(m) m.UserData) _
                .WillCascadeOnDelete(False)

            modelBuilder.Entity(Of UserData)() _
                .HasMany(Function(m) m.Results) _
                .WithRequired(Function(m) m.UserData) _
                .WillCascadeOnDelete(False)
            'FORM
            'modelBuilder.Entity(Of Form)() _
            '    .HasMany(Function(m) m.Results) _
            '    .WithRequired(Function(m) m.Form) _
            '    .WillCascadeOnDelete(False)
            'modelBuilder.Entity(Of Form)() _
            '    .HasMany(Function(m) m.UserActivities) _
            '    .WithRequired(Function(m) m.Form) _
            '    .WillCascadeOnDelete(False)
            'FOR NULLABLE FK ON USER ACTIVITY
            'modelBuilder.Entity(Of UserActivity)() _
            '    .HasOptional(Function(m) m.Result) _
            '    .WithOptionalDependent(Function(m) m.UserActivities)

        End Sub

    End Class
End Namespace


