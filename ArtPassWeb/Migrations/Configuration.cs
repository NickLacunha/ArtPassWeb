namespace ArtPassWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtPassWeb.Models.ArtPassWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArtPassWeb.Models.ArtPassWebContext context)
        {
            context.HospitalModels.AddOrUpdate(new Models.HospitalModel[]
            {
                new Models.HospitalModel {HospitalId = 1, Name="Children's Hospital #1" },
                new Models.HospitalModel {HospitalId = 2, Name="Children's Hospital #2" }
            });

            context.RegistrantModels.AddOrUpdate(new Models.RegistrantModel[]
            {
                new Models.RegistrantModel {RegistrantId = 1, Name="Frank", HospitalId = 1, Age = 13, DaysStaying = 12,
                    EmailAddress ="frank@website.com", PhoneNumber = "555-555-5555", UnitAndRoomNumber = "Unit 5, Room 201",
                    Comments = "Interests include football, eating, and sleeping." },
                new Models.RegistrantModel {RegistrantId = 2, Name="Lisa", HospitalId = 2, Age = 9, DaysStaying = 30,
                    EmailAddress = "lisa@differentWebsite.com", PhoneNumber = "555-555-5556", UnitAndRoomNumber = "Room 371",
                    Comments = "Likes classical music, plays violin, took a pottery class last summer."},
                new Models.RegistrantModel {RegistrantId = 3, Name="Sally", HospitalId = 1, Age = 16, DaysStaying = 5,
                    EmailAddress = "sally@website.com", PhoneNumber = "555-555-5557", UnitAndRoomNumber = "Unit 4, Room 102",
                    Comments = "Drives a Ford Flex, captain of the cheer squad, would like to speak to your manager." }
            });
        }
    }
}
