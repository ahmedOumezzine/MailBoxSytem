namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parameters", "TemplateDetailsId", "dbo.TemplateDetails");
            DropIndex("dbo.Parameters", new[] { "TemplateDetailsId" });
            AddColumn("dbo.Parameters", "TemplateId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Parameters", "TemplateId");
            AddForeignKey("dbo.Parameters", "TemplateId", "dbo.Templates", "Id", cascadeDelete: true);
            DropColumn("dbo.Parameters", "TemplateDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parameters", "TemplateDetailsId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Parameters", "TemplateId", "dbo.Templates");
            DropIndex("dbo.Parameters", new[] { "TemplateId" });
            DropColumn("dbo.Parameters", "TemplateId");
            CreateIndex("dbo.Parameters", "TemplateDetailsId");
            AddForeignKey("dbo.Parameters", "TemplateDetailsId", "dbo.TemplateDetails", "Id", cascadeDelete: true);
        }
    }
}
