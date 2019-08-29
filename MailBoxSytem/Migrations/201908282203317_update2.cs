namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parameters", "TemplateDetails_Id", "dbo.TemplateDetails");
            DropIndex("dbo.Parameters", new[] { "TemplateDetails_Id" });
            RenameColumn(table: "dbo.Parameters", name: "TemplateDetails_Id", newName: "TemplateDetailsId");
            AddColumn("dbo.TemplateDetails", "Layout_Id", c => c.Guid());
            AlterColumn("dbo.Parameters", "TemplateDetailsId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Parameters", "TemplateDetailsId");
            CreateIndex("dbo.TemplateDetails", "Layout_Id");
            AddForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts", "Id");
            AddForeignKey("dbo.Parameters", "TemplateDetailsId", "dbo.TemplateDetails", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameters", "TemplateDetailsId", "dbo.TemplateDetails");
            DropForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts");
            DropIndex("dbo.TemplateDetails", new[] { "Layout_Id" });
            DropIndex("dbo.Parameters", new[] { "TemplateDetailsId" });
            AlterColumn("dbo.Parameters", "TemplateDetailsId", c => c.Guid());
            DropColumn("dbo.TemplateDetails", "Layout_Id");
            RenameColumn(table: "dbo.Parameters", name: "TemplateDetailsId", newName: "TemplateDetails_Id");
            CreateIndex("dbo.Parameters", "TemplateDetails_Id");
            AddForeignKey("dbo.Parameters", "TemplateDetails_Id", "dbo.TemplateDetails", "Id");
        }
    }
}
