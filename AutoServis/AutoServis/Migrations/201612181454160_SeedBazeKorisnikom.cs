namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBazeKorisnikom : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bee09deb-ce7b-474d-87e3-0d4107c5a450', N'Korisnik')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'ab4a0f9b-3d34-4a79-8d88-2e593118ae60', N'ivo.ivic@example.com', 0, N'ANFqOHzk9kqjF080L1bwWtY5dxfIN800C5ZLkEl3QvQNRKhbmQLsqx/CLHKw3FE5/Q==', N'e3236c86-7d52-4d50-872f-27e1e801dddb', NULL, 0, 0, NULL, 1, 0, N'ivo.ivic@example.com', N'Ivo', N'Iviæ', N'0981234567')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab4a0f9b-3d34-4a79-8d88-2e593118ae60', N'bee09deb-ce7b-474d-87e3-0d4107c5a450')
");
        }
        
        public override void Down()
        {
        }
    }
}
