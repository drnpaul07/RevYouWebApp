Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class init
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.AspNetUsers", "FirstName")
            DropColumn("dbo.AspNetUsers", "LastName")
            DropColumn("dbo.AspNetUsers", "Hatdog")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.AspNetUsers", "Hatdog", Function(c) c.String(nullable := False))
            AddColumn("dbo.AspNetUsers", "LastName", Function(c) c.String(nullable := False))
            AddColumn("dbo.AspNetUsers", "FirstName", Function(c) c.String(nullable := False))
        End Sub
    End Class
End Namespace
