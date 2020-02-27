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
                        .IsPosted = c.Boolean(nullable := False),
                        .UserDataID = c.Int(nullable := False),
                        .CategoryID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.FormID) _
                .ForeignKey("dbo.Category", Function(t) t.CategoryID, cascadeDelete := True) _
                .ForeignKey("dbo.UserData", Function(t) t.UserDataID, cascadeDelete := True) _
                .Index(Function(t) t.UserDataID) _
                .Index(Function(t) t.CategoryID)
            
            CreateTable(
                "dbo.FormTag",
                Function(c) New With
                    {
                        .FormTagID = c.Int(nullable := False, identity := True),
                        .FormID = c.Int(nullable := False),
                        .TagID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.FormTagID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .ForeignKey("dbo.Tag", Function(t) t.TagID) _
                .Index(Function(t) t.FormID) _
                .Index(Function(t) t.TagID)
            
            CreateTable(
                "dbo.Tag",
                Function(c) New With
                    {
                        .TagID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Usage = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.TagID)
            
            CreateTable(
                "dbo.UserTag",
                Function(c) New With
                    {
                        .UserTagID = c.Int(nullable := False, identity := True),
                        .UserDataID = c.Int(nullable := False),
                        .TagID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.UserTagID) _
                .ForeignKey("dbo.UserData", Function(t) t.UserDataID, cascadeDelete := True) _
                .ForeignKey("dbo.Tag", Function(t) t.TagID) _
                .Index(Function(t) t.UserDataID) _
                .Index(Function(t) t.TagID)
            
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
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Question", "FormID", "dbo.Form")
            DropForeignKey("dbo.UserTag", "TagID", "dbo.Tag")
            DropForeignKey("dbo.UserTag", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.Form", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.FormTag", "TagID", "dbo.Tag")
            DropForeignKey("dbo.FormTag", "FormID", "dbo.Form")
            DropForeignKey("dbo.Form", "CategoryID", "dbo.Category")
            DropIndex("dbo.Question", New String() { "FormID" })
            DropIndex("dbo.UserTag", New String() { "TagID" })
            DropIndex("dbo.UserTag", New String() { "UserDataID" })
            DropIndex("dbo.FormTag", New String() { "TagID" })
            DropIndex("dbo.FormTag", New String() { "FormID" })
            DropIndex("dbo.Form", New String() { "CategoryID" })
            DropIndex("dbo.Form", New String() { "UserDataID" })
            DropTable("dbo.Question")
            DropTable("dbo.UserData")
            DropTable("dbo.UserTag")
            DropTable("dbo.Tag")
            DropTable("dbo.FormTag")
            DropTable("dbo.Form")
            DropTable("dbo.Category")
        End Sub
    End Class
End Namespace
