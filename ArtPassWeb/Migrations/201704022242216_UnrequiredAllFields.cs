namespace ArtPassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnrequiredAllFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistrantModels", "Name", c => c.String());
            AlterColumn("dbo.RegistrantModels", "EmailAddress", c => c.String());
            AlterColumn("dbo.RegistrantModels", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistrantModels", "Comments", c => c.String(nullable: false));
            AlterColumn("dbo.RegistrantModels", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.RegistrantModels", "Name", c => c.String(nullable: false));
        }
    }
}
