namespace MailBoxSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TemplateDetails", "Style");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TemplateDetails", "Style", c => c.String());
        }
    }
}
