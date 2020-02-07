Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            ContextKey = "RevYou.ApplicationDbContext"
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})


            Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
            Dim roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
            'Dim user = New ApplicationUser() With {
            '    .UserName = "drnpaul07",
            '    .Email = "drnpaul07@gmail.com"
            '}
            'Dim role = New IdentityRole() With {
            '    .Name = "ADMIN"
            '}

            'roleManager.Create(role)
            'If userManager.Create(user, "P@ssw0rd").Succeeded Then
            '    userManager.AddToRole(user.Id, "ADMIN")
            'End If
            Dim array() As String = {"admin", "superadmin", "user"}

            context.Roles.AddOrUpdate(
                New IdentityRole() With {.Name = "ADMIN"},
                New IdentityRole() With {.Name = "SUPER_ADMIN"},
                New IdentityRole() With {.Name = "USER"}
                )
            context.SaveChanges()

            For i As Byte = 0 To array.Length - 1
                userManager.Create(New ApplicationUser() With {.UserName = array(i), .Email = array(i) + "@" + array(i) + ".com"}, "P@ssw0rd")
            Next

            userManager.AddToRole(userManager.FindByName("admin").Id, "ADMIN")
            userManager.AddToRole(userManager.FindByName("user").Id, "USER")
            userManager.AddToRole(userManager.FindByName("superadmin").Id, "SUPER_ADMIN")

            context.SaveChanges()
        End Sub

    End Class

End Namespace
