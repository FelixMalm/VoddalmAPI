
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data
{
    public static class SeedHelper //Author Kim Jonsson
    {
        

       

        public static async Task DataHelper(ApplicationDbContext context)
        {
            
            var hasher = new PasswordHasher<Broker>();
            if (!context.Broker.Any())
            {
                // Create Agency instances
                var agency1 = new Agency
                {
                    Name = "Bill Robertson",
                    Presentation = "Luxury Living Experts",
                    LogoUrl = "https://cdn.logojoy.com/wp-content/uploads/2018/05/30150844/1415.png",
                };

                var agency2 = new Agency
                {
                    Name = "Real Estate",
                    Presentation = "Your Urban Lifestyle Specialists",
                    LogoUrl = "https://img.freepik.com/free-vector/real-estate-logo-template_1195-19.jpg",
                };

                var agency3 = new Agency
                {
                    Name = "Modern Home",
                    Presentation = "Coastal Living at Its Finest",
                    LogoUrl = "https://marketplace.canva.com/EAE2plelYDk/1/0/1600w/canva-modern-real-estate-agency-logo-template-l-8rw0yv5RA.jpg",
                };

                var broker1 = new Broker
                {
                    UserName = "Mike.Oxlong@example.com",
                    Email = "Mike.Oxlong@example.com",
                    PhoneNumber = "123-456-7890",
                    FirstName = "Mike",
                    LastName = "Oxlong",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/16/91/1691d7d43132f638d416b814532bc989.jpg",
                    Agency = agency1,
                    EmailConfirmed = true,
                    NormalizedUserName = "MIKE.OXLONG@EXAMPLE.COM",
                    NormalizedEmail = "MIKE.OXLONG@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker2 = new Broker
                {
                    UserName = "Mike.Litoris@example.com",
                    Email = "Mike.Litoris@example.com",
                    PhoneNumber = "234-567-8901",
                    FirstName = "Mike",
                    LastName = "Litoris",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/48/89/4889d149130990d377b541db651e1e94.jpg",
                    Agency = agency1,
                    EmailConfirmed = true,
                    NormalizedUserName = "MIKE.LITORIS@EXAMPLE.COM",
                    NormalizedEmail = "MIKE.LITORIS@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker3 = new Broker
                {
                    UserName = "Oliver.Klozoff@example.com",
                    Email = "Oliver.Klozoff@example.com",
                    PhoneNumber = "345-678-9012",
                    FirstName = "Oliver",
                    LastName = "Klozoff",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/22/05/2205a46acb2ce4570505ffa72f8d8df0.png",
                    Agency = agency2,
                    EmailConfirmed = true,
                    NormalizedUserName = "OLIVER.KLOZOFF@EXAMPLE.COM",
                    NormalizedEmail = "OLIVER.KLOZOFF@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker4 = new Broker
                {
                    UserName = "Jenna.Toll@example.com",
                    Email = "Jenna.Toll@example.com",
                    PhoneNumber = "456-789-0123",
                    FirstName = "Jenna",
                    LastName = "Toll",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/8a/07/8a0797543b3d208e789583211d4e091a.jpg",
                    Agency = agency2,
                    EmailConfirmed = true,
                    NormalizedUserName = "JENNA.TOLL@EXAMPLE.COM",
                    NormalizedEmail = "JENNA.TOLL@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker5 = new Broker
                {
                    UserName = "David.Martinez@example.com",
                    Email = "David.Martinez@example.com",
                    PhoneNumber = "567-890-1234",
                    FirstName = "David",
                    LastName = "Martinez",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/3f/87/3f87ed4178955da1f8f699c1b27f4033.jpg",
                    Agency = agency2,
                    EmailConfirmed = true,
                    NormalizedUserName = "DAVID.MARTINEZ@EXAMPLE.COM",
                    NormalizedEmail = "DAVID.MARTINEZ@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker6 = new Broker
                {
                    UserName = "Jennifer.Garcia@example.com",
                    Email = "Jennifer.Garcia@example.com",
                    PhoneNumber = "678-901-2345",
                    FirstName = "Jennifer",
                    LastName = "Garcia",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/b2/4e/b24e75cdd8f1d95e25321da17607058c.jpg",
                    Agency = agency3,
                    EmailConfirmed = true,
                    NormalizedUserName = "JENNIFER.GARCIA@EXAMPLE.COM",
                    NormalizedEmail = "JENNIFER.GARCIA@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker7 = new Broker
                {
                    UserName = "Seymour.Butts@example.com",
                    Email = "Seymour.Butts@example.com",
                    PhoneNumber = "789-012-3456",
                    FirstName = "Seymour",
                    LastName = "Butts",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/da/73/da73431cec8b93e979ebea305ef6675c.jpg",
                    Agency = agency3,
                    EmailConfirmed = true,
                    NormalizedUserName = "SEYMOUR.BUTTS@EXAMPLE.COM",
                    NormalizedEmail = "SEYMOUR.BUTTS@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker8 = new Broker
                {
                    UserName = "Ashley.Anderson@example.com",
                    Email = "Ashley.Anderson@example.com",
                    PhoneNumber = "890-123-4567",
                    FirstName = "Ashley",
                    LastName = "Anderson",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/7b/82/7b82dcc7354c9f67c4a4da81675ce89f.jpg",
                    Agency = agency3,
                    EmailConfirmed = true,
                    NormalizedUserName = "ASHLEY.ANDERSON@EXAMPLE.COM",
                    NormalizedEmail = "ASHLEY.ANDERSON@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker9 = new Broker
                {
                    UserName = "Matthew.Taylor@example.com",
                    Email = "Matthew.Taylor@example.com",
                    PhoneNumber = "901-234-5678",
                    FirstName = "Matthew",
                    LastName = "Taylor",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/10/8d/108de1efe4f487cefd817d47cb0b6f66.jpg",
                    Agency = agency3,
                    EmailConfirmed = true,
                    NormalizedUserName = "MATTHEW.TAYLOR@EXAMPLE.COM",
                    NormalizedEmail = "MATTHEW.TAYLOR@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };

                var broker10 = new Broker
                {
                    UserName = "Jessica.Thomas@example.com",
                    Email = "Jessica.Thomas@example.com",
                    PhoneNumber = "012-345-6789",
                    FirstName = "Jessica",
                    LastName = "Thomas",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/1b/92/1b9206e0d8fc0a6e7bbb75400172e85d.jpg",
                    Agency = agency3,
                    EmailConfirmed = true,
                    NormalizedUserName = "JESSICA.THOMAS@EXAMPLE.COM",
                    NormalizedEmail = "JESSICA.THOMAS@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "!Hej123!")
                };



                var municipality1 = new Municipality { Name = "Ale" };
                var municipality2 = new Municipality { Name = "Alingsås" };
                var municipality3 = new Municipality { Name = "Alvesta" };
                var municipality4 = new Municipality { Name = "Aneby" };
                var municipality5 = new Municipality { Name = "Arboga" };
                var municipality6 = new Municipality { Name = "Arjeplog" };
                var municipality7 = new Municipality { Name = "Arvidsjaur" };
                var municipality8 = new Municipality { Name = "Arvika" };
                var municipality9 = new Municipality { Name = "Askersund" };
                var municipality10 = new Municipality { Name = "Avesta" };

                var category1 = new Category { Name = "Apartment" };
                var category2 = new Category { Name = "Villas" };
                var category3 = new Category { Name = "Leisure house" };
                var category4 = new Category { Name = "New production" };


                var housing1 = new Housing
                {
                    Address = "Storgatan 555",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful house with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/d5/9a/d59a03dc9563c743c423ffcb06e5ef03.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/e1/f4/e1f4c6a39cb73f223e20ad2b50b4439c.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/6c/46/6c46866d3402fc4ea2a4fb117041bc23.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/05/70/0570ca9cf4dbdc9bcfb7b39455a12ff6.jpg" },
                    Municipality = municipality1,
                    Broker = broker1,
                    Category = category1

                };
                var housing2 = new Housing
                {
                    Address = "Stenvägen 4",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful cottage with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/c9/31/c9310fdb7dfe99789fa217621903aca1.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/e8/19/e819d827602dfc8c2fa236c1fde7cb02.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/9e/aa/9eaa0c1c7311c1bb3977d699bd8e39f0.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/a9/20/a920e8443d29b26920642d80e68b818c.jpg" },
                    Municipality = municipality2,
                    Broker = broker2,
                    Category = category2

                };
                var housing3 = new Housing
                {
                    Address = "Grusvägen 123",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful Condo with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/3d/02/3d02d57d0f2c10e90c544e011297c363.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/bf/e7/bfe726aa69826caf8e2cdb916092537a.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/bb/b2/bbb2cb68c678600187b7c4636bcf06c2.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/8f/7a/8f7a47be4c4d7b3b28945c32c6524f11.jpg" },
                    Municipality = municipality3,
                    Broker = broker3,
                    Category = category3

                };
                var housing4 = new Housing
                {
                    Address = "Mittivägen 55",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "This is definitely a place where you can live",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/9d/c3/9dc32f3cc1ea15cc54252706daa87562.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/45/a9/45a9cd9c5f371d4a9f6979c939666ab2.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/51/0f/510f18ef61962c349397dad26f30ada3.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/92/e0/92e05a19eda5c1e5186687b55fa4945c.jpg" },
                    Municipality = municipality4,
                    Broker = broker4,
                    Category = category4

                };
                var housing5 = new Housing
                {
                    Address = "teflonvägen 2",
                    InitialPrice = 100231,
                    LivingArea = 235,
                    AdditionalArea = 30,
                    PlotArea = 600,
                    Description = "Perfect place to live",
                    NumberOfRooms = 1,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 3000,
                    YearBuilt = 1977,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/06/b9/06b942483eef732634e4964f1a5a96e5.jpg", "https://bilder.hemnet.se/images/itemgallery_portrait_cut/3b/a5/3ba5bd646981e5a8bc730920aff7be7b.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/08/1f/081fdefc8af85b9f907ccd8deefda16e.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/10/d5/10d51f5d16ba766f5006076f7c210c0b.jpg" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };
                var housing6 = new Housing
                {
                    Address = "Mittivägen 56",
                    InitialPrice = 100231,
                    LivingArea = 300,
                    AdditionalArea = 30,
                    PlotArea = 400,
                    Description = "Perfect place to live",
                    NumberOfRooms = 4,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 3000,
                    YearBuilt = 2003,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/03/5d/035df554b24ba03ba480bd7c63186eef.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/f8/7d/f87d40f817ef96cc4eec4ac7e90ee325.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/51/51/5151da5af0bff603b17a3d5d4701712a.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/4f/ec/4fec2aeb49694cdc7e723d5f875f5a6c.jpg" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };
                var housing7 = new Housing
                {
                    Address = "Chungusvägen 97",
                    InitialPrice = 8760,
                    LivingArea = 120,
                    AdditionalArea = 30,
                    PlotArea = 330,
                    Description = "Perfect place to live",
                    NumberOfRooms = 3,
                    MonthlyFee = 250,
                    AnnualOperatingCost = 3000,
                    YearBuilt = 1998,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/8f/9e/8f9e79b2bc7d487ed99e556ecb0b28ad.jpg", "https://bilder.hemnet.se/images/itemgallery_portrait_cut/58/98/5898f96a3572e484e2baa5f342c2a92e.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/83/cb/83cb5a826dfb650d65fa4ccd5f324bcc.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/d0/a6/d0a6b0c4244abcb0719c48ce8d4d74de.jpg" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };
                var housing8 = new Housing
                {
                    Address = "Bonkvägen 13",
                    InitialPrice = 103256,
                    LivingArea = 250,
                    AdditionalArea = 30,
                    PlotArea = 550,
                    Description = "Perfect place to live",
                    NumberOfRooms = 5,
                    MonthlyFee = 140,
                    AnnualOperatingCost = 4000,
                    YearBuilt = 2016,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/8f/d2/8fd22ffc125172db76f4a15b7e89ec25.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/3d/9d/3d9da30e8e9959e93064e7036a0d9fd6.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/5e/1e/5e1e089d530a2dc4c2cbf32349cb55e0.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/fd/77/fd775f6333765137c312b8df29505587.jpg" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };
                var housing9 = new Housing
                {
                    Address = "Mellanvägen 18",
                    InitialPrice = 45363,
                    LivingArea = 300,
                    AdditionalArea = 30,
                    PlotArea = 400,
                    Description = "Perfect place to live",
                    NumberOfRooms = 2,
                    MonthlyFee = 60,
                    AnnualOperatingCost = 3000,
                    YearBuilt = 1993,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/0e/ec/0eecb7323fe04e578c44e29e83e97b6c.jpg", "https://bilder.hemnet.se/images/itemgallery_portrait_cut/73/bd/73bd5eab77fb78740cde3ea4e7ae5306.jpg", "https://bilder.hemnet.se/images/itemgallery_portrait_cut/03/c2/03c299ff0141c603acbf35393e917713.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/fb/ec/fbec1a77218311bac5a98f95432c5f32.jpg" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };

                await context.AddRangeAsync(new List<Agency> { agency1, agency2, agency3 });
                await context.AddRangeAsync(new List<Broker> { broker1, broker2, broker3, broker4, broker5, broker6, broker7, broker8, broker9, broker10 });
                await context.AddRangeAsync(new List<Municipality> { municipality1, municipality2, municipality3, municipality4, municipality5, municipality6, municipality7, municipality8, municipality9, municipality10 });
                await context.AddRangeAsync(new List<Category> { category1, category2, category3, category4 });
                await context.AddRangeAsync(new List<Housing> { housing1, housing2, housing3, housing4, housing5, housing6, housing7, housing8, housing9 });
                await context.SaveChangesAsync();
            }
        }
    }
}