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
                "dbo.Result",
                Function(c) New With
                    {
                        .ResultID = c.Int(nullable := False, identity := True),
                        .UserDataID = c.Int(nullable := False),
                        .FormID = c.Int(nullable := False),
                        .Score = c.Int(nullable := False),
                        .Grade = c.String(),
                        .DateAnswered = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ResultID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .ForeignKey("dbo.UserData", Function(t) t.UserDataID) _
                .Index(Function(t) t.UserDataID) _
                .Index(Function(t) t.FormID)
            
            CreateTable(
                "dbo.UserActivity",
                Function(c) New With
                    {
                        .UserActivityID = c.Int(nullable := False, identity := True),
                        .Action = c.String(),
                        .UserDataID = c.Int(nullable := False),
                        .ResultID = c.Int(nullable := False),
                        .FormID = c.Int(nullable := False),
                        .DateOfAction = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.UserActivityID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .ForeignKey("dbo.UserData", Function(t) t.UserDataID) _
                .Index(Function(t) t.UserDataID) _
                .Index(Function(t) t.FormID)
            
            CreateTable(
                "dbo.Question",
                Function(c) New With
                    {
                        .QuestionID = c.Int(nullable := False, identity := True),
                        .Index = c.String(),
                        .Statement = c.String(),
                        .Type = c.String(),
                        .FormID = c.Int(nullable := False),
                        .Answer = c.String()
                    }) _
                .PrimaryKey(Function(t) t.QuestionID) _
                .ForeignKey("dbo.Form", Function(t) t.FormID, cascadeDelete := True) _
                .Index(Function(t) t.FormID)
            
            CreateTable(
                "dbo.Choice",
                Function(c) New With
                    {
                        .ChoiceID = c.Int(nullable := False, identity := True),
                        .Item = c.String(),
                        .isAnswer = c.Boolean(nullable := False),
                        .QuestionID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ChoiceID) _
                .ForeignKey("dbo.Question", Function(t) t.QuestionID, cascadeDelete := True) _
                .Index(Function(t) t.QuestionID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Question", "FormID", "dbo.Form")
            DropForeignKey("dbo.Choice", "QuestionID", "dbo.Question")
            DropForeignKey("dbo.UserTag", "TagID", "dbo.Tag")
            DropForeignKey("dbo.UserTag", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.UserActivity", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.UserActivity", "FormID", "dbo.Form")
            DropForeignKey("dbo.Result", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.Result", "FormID", "dbo.Form")
            DropForeignKey("dbo.Form", "UserDataID", "dbo.UserData")
            DropForeignKey("dbo.FormTag", "TagID", "dbo.Tag")
            DropForeignKey("dbo.FormTag", "FormID", "dbo.Form")
            DropForeignKey("dbo.Form", "CategoryID", "dbo.Category")
            DropIndex("dbo.Choice", New String() { "QuestionID" })
            DropIndex("dbo.Question", New String() { "FormID" })
            DropIndex("dbo.UserActivity", New String() { "FormID" })
            DropIndex("dbo.UserActivity", New String() { "UserDataID" })
            DropIndex("dbo.Result", New String() { "FormID" })
            DropIndex("dbo.Result", New String() { "UserDataID" })
            DropIndex("dbo.UserTag", New String() { "TagID" })
            DropIndex("dbo.UserTag", New String() { "UserDataID" })
            DropIndex("dbo.FormTag", New String() { "TagID" })
            DropIndex("dbo.FormTag", New String() { "FormID" })
            DropIndex("dbo.Form", New String() { "CategoryID" })
            DropIndex("dbo.Form", New String() { "UserDataID" })
            DropTable("dbo.Choice")
            DropTable("dbo.Question")
            DropTable("dbo.UserActivity")
            DropTable("dbo.Result")
            DropTable("dbo.UserData")
            DropTable("dbo.UserTag")
            DropTable("dbo.Tag")
            DropTable("dbo.FormTag")
            DropTable("dbo.Form")
            DropTable("dbo.Category")
        End Sub
    End Class
End Namespace
