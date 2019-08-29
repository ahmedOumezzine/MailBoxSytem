namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts");
            DropForeignKey("dbo.TemplateDetails", "Template_Id", "dbo.Templates");
            DropIndex("dbo.TemplateDetails", new[] { "Layout_Id" });
            DropIndex("dbo.TemplateDetails", new[] { "Template_Id" });
            RenameColumn(table: "dbo.TemplateDetails", name: "Layout_Id", newName: "LayoutId");
            RenameColumn(table: "dbo.TemplateDetails", name: "Template_Id", newName: "TemplateId");
            AlterColumn("dbo.TemplateDetails", "LayoutId", c => c.Guid(nullable: false));
            AlterColumn("dbo.TemplateDetails", "TemplateId", c => c.Guid(nullable: false));
            CreateIndex("dbo.TemplateDetails", "TemplateId");
            CreateIndex("dbo.TemplateDetails", "LayoutId");
            AddForeignKey("dbo.TemplateDetails", "LayoutId", "dbo.Layouts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TemplateDetails", "TemplateId", "dbo.Templates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateDetails", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.TemplateDetails", "LayoutId", "dbo.Layouts");
            DropIndex("dbo.TemplateDetails", new[] { "LayoutId" });
            DropIndex("dbo.TemplateDetails", new[] { "TemplateId" });
            AlterColumn("dbo.TemplateDetails", "TemplateId", c => c.Guid());
            AlterColumn("dbo.TemplateDetails", "LayoutId", c => c.Guid());
            RenameColumn(table: "dbo.TemplateDetails", name: "TemplateId", newName: "Template_Id");
            RenameColumn(table: "dbo.TemplateDetails", name: "LayoutId", newName: "Layout_Id");
            CreateIndex("dbo.TemplateDetails", "Template_Id");
            CreateIndex("dbo.TemplateDetails", "Layout_Id");
            AddForeignKey("dbo.TemplateDetails", "Template_Id", "dbo.Templates", "Id");
            AddForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts", "Id");
        }
    }
}
