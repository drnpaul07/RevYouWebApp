Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports RevYou.Models.Base
Imports RevYou.Models.Reviewer

Namespace Migrations.RevConf

    Friend NotInheritable Class RevConf
        Inherits DbMigrationsConfiguration(Of DAL.RevYouContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As DAL.RevYouContext)
            Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))

            Dim userList As IList(Of ApplicationUser)
            userList = userManager.Users.ToList

            For Each user In userList
                context.UserData.AddOrUpdate(
                    New UserData() With {.Username = user.UserName, .Firstname = "John", .Surname = "Doe"})
            Next

            Dim category = New List(Of Category)() From {
                New Category() With {
                    .Name = "Sciences",
                    .Code = "SCI"
                }, New Category() With {
                    .Name = "Mathematics",
                    .Code = "MAT"
                },
                New Category() With {
                    .Name = "Engineering",
                    .Code = "ENG"
                },
                New Category() With {
                    .Name = "Agriculture",
                    .Code = "AGR"
                },
                New Category() With {
                    .Name = "Arts",
                    .Code = "ART"
                },
                New Category() With {
                    .Name = "Technology",
                    .Code = "TEC"
                }
            }
            category.ForEach(Function(c) context.Category.Add(c))
            context.SaveChanges()
        End Sub

    End Class

End Namespace
