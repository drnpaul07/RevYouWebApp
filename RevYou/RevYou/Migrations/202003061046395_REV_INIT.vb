Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations.RevConf
    Public Partial Class REV_INIT
        Inherits DbMigration
    
        Public Overrides Sub Up()
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
            
            AddColumn("dbo.Question", "Type", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Choice", "QuestionID", "dbo.Question")
            DropIndex("dbo.Choice", New String() { "QuestionID" })
            DropColumn("dbo.Question", "Type")
            DropTable("dbo.Choice")
        End Sub
    End Class
End Namespace
