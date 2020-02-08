Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations.RevConf

    Friend NotInheritable Class RevConf
        Inherits DbMigrationsConfiguration(Of DAL.RevYouContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As DAL.RevYouContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})
        End Sub

    End Class

End Namespace
