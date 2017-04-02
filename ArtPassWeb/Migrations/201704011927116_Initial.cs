namespace ArtPassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HospitalModels",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.RegistrantModels",
                c => new
                    {
                        RegistrantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        DaysStaying = c.Int(nullable: false),
                        UnitAndRoomNumber = c.String(),
                        Comments = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrantId)
                .ForeignKey("dbo.HospitalModels", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.HospitalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistrantModels", "HospitalId", "dbo.HospitalModels");
            DropIndex("dbo.RegistrantModels", new[] { "HospitalId" });
            DropTable("dbo.RegistrantModels");
            DropTable("dbo.HospitalModels");
        }
    }
}
