namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TemplateDetails", "LayoutId", "dbo.Layouts");
            DropIndex("dbo.TemplateDetails", new[] { "LayoutId" });
            RenameColumn(table: "dbo.TemplateDetails", name: "LayoutId", newName: "Layout_Id");
            AlterColumn("dbo.TemplateDetails", "Layout_Id", c => c.Guid());
            CreateIndex("dbo.TemplateDetails", "Layout_Id");
            AddForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateDetails", "Layout_Id", "dbo.Layouts");
            DropIndex("dbo.TemplateDetails", new[] { "Layout_Id" });
            AlterColumn("dbo.TemplateDetails", "Layout_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.TemplateDetails", name: "Layout_Id", newName: "LayoutId");
            CreateIndex("dbo.TemplateDetails", "LayoutId");
            AddForeignKey("dbo.TemplateDetails", "LayoutId", "dbo.Layouts", "Id", cascadeDelete: true);
        }
    }
}
