Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class RevMig
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Form",
                Function(c) New With
                    {
                        .FormID = c.String(nullable := False, maxLength := 128),
                        .Title = c.String(),
                        .Description = c.String(),
                        .User_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.FormID) _
                .ForeignKey("dbo.UserData", Function(t) t.User_ID) _
                .Index(Function(t) t.User_ID)
            
            CreateTable(
                "dbo.Question",
                Function(c) New With
                    {
                        .QuestionID = c.Int(nullable := False, identity := True),
                        .Index = c.String(),
                        .Statement = c.String(),
                        .Answer = c.String(),
                        .Form_FormID = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.QuestionID) _
                .ForeignKey("dbo.Form", Function(t) t.Form_FormID) _
                .Index(Function(t) t.Form_FormID)
            
            CreateTable(
                "dbo.UserData",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Username = c.String(),
                        .ImageContent = c.Binary(),
                        .ImageType = c.String(),
                        .ImageSize = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Form", "User_ID", "dbo.UserData")
            DropForeignKey("dbo.Question", "Form_FormID", "dbo.Form")
            DropIndex("dbo.Question", New String() { "Form_FormID" })
            DropIndex("dbo.Form", New String() { "User_ID" })
            DropTable("dbo.UserData")
            DropTable("dbo.Question")
            DropTable("dbo.Form")
        End Sub
    End Class
End Namespace
