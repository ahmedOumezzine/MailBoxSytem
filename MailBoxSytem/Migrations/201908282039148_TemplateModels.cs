namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemplateModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Layouts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Style = c.String(),
                        Header = c.String(),
                        Footer = c.String(),
                        TemplateType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Key = c.String(),
                        Description = c.String(),
                        ClassName = c.String(),
                        TemplateDetails_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateDetails", t => t.TemplateDetails_Id)
                .Index(t => t.TemplateDetails_Id);
            
            CreateTable(
                "dbo.TemplateDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Subject = c.String(),
                        Style = c.String(),
                        Body = c.String(),
                        Template_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Templates", t => t.Template_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        GroupBy = c.String(),
                        TemplateType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateDetails", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.Parameters", "TemplateDetails_Id", "dbo.TemplateDetails");
            DropIndex("dbo.TemplateDetails", new[] { "Template_Id" });
            DropIndex("dbo.Parameters", new[] { "TemplateDetails_Id" });
            DropTable("dbo.Templates");
            DropTable("dbo.TemplateDetails");
            DropTable("dbo.Parameters");
            DropTable("dbo.Layouts");
        }
    }
}
