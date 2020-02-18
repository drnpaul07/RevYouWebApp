Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations.RevConf
    Public Partial Class REV_INIT
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Category",
                Function(c) New With
                    {
                        .CategoryID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Code = c.String()
                    }) _
                .PrimaryKey(Function(t) t.CategoryID)
            
            CreateTable(
                "dbo.Form",
                Function(c) New With
                    {
                        .FormID = c.Int(nullable := False, identity := True),
                        .Title = c.String(),
                        .Description = c.String(),
                        .DateCreated = c.DateTime(nullable := False),
                        .UserDataID = c.Int(nullable := False),
                        .CategoryID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.FormID) _
                .ForeignKey("dbo.Category", Function(t) t.CategoryID, cascadeDelete := True) _
                .ForeignKey("dbo.UserData", Function(t) t.UserDataID, cascadeDelete := True) _
                .Index(Function(t) t.UserDataID) _
                .Index(Function(t) t.CategoryID)
            
            CreateTable(
                "dbo.Question",
                Function(c) New With
                    {
                        .QuestionID = c.Int(nullable := False, identity := True),
                        .Index = c.String(),
                        .Statement = c.String(),
                        .Answer = c.String(),
                        .FormID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.QuestionID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .Index(Function(t) t.FormID)
            
            CreateTable(
                "dbo.Tag",
                Function(c) New With
                    {
                        .TagID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Usage = c.Int(nullable := False),
                        .FormID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.TagID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .Index(Function(t) t.FormID)
            
            CreateTable(
                "dbo.UserData",
                Function(c) New With
                    {
                        .UserDataID = c.Int(nullable := False, identity := True),
                        .Username = c.String(),
                        .Firstname = c.String(),
                        .Surname = c.String()
                    }) _
                .PrimaryKey(Function(t) t.UserDataID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Form", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.Tag", "FormID", "dbo.Form")
            DropForeignKey("dbo.Question", "FormID", "dbo.Form")
            DropForeignKey("dbo.Form", "CategoryID", "dbo.Category")
            DropIndex("dbo.Tag", New String() { "FormID" })
            DropIndex("dbo.Question", New String() { "FormID" })
            DropIndex("dbo.Form", New String() { "CategoryID" })
            DropIndex("dbo.Form", New String() { "UserDataID" })
            DropTable("dbo.UserData")
            DropTable("dbo.Tag")
            DropTable("dbo.Question")
            DropTable("dbo.Form")
            DropTable("dbo.Category")
        End Sub
    End Class
End Namespace
