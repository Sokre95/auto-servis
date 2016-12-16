namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Serviseri : DbMigration
    {
        public override void Up()
        {
	        Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0', N'Serviser')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'0a545f57-54b8-4475-8bd4-29337d790d7d', N'kristijanmarkovic@servis.com', 0, N'AEMlh7Hx1IvTn0NFH4domNSAa8UNVHVBRIVqus3zHwpF4HlH0RN0+EfL5yrbzY05DQ==', N'0b07fd2f-419a-4e8c-949f-2eca487b94f0', NULL, 0, 0, NULL, 1, 0, N'kristijanmarkovic@servis.com', N'Kristijan', N'Markoviæ', N'0918897619')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'4068d904-a493-4fa6-a098-018789fe15b9', N'ivanjuric@servis.com', 0, N'ACaHMhNcUel6rGxIuwSj0+iPlhlFzLpyZZeUZcJ5aRK+qaW1F6FIBzVGIeBO/YPV2w==', N'1ecc3fec-0c5e-4837-9a15-3db102a5418e', NULL, 0, 0, NULL, 1, 0, N'ivanjuric@servis.com', N'Ivan', N'Juriæ', N'0917967454')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'5e6b2b18-1315-4283-8533-e9ce5e88b589', N'mariokovacevic@servis.com', 0, N'AL2VNaRLM4ncUMY7BK0TeEi/e7Q4c3608RH7VExHPALRiRMGYe8mgh7XhREgGekg2A==', N'9317b54b-f989-4289-a0b4-9611674feb68', NULL, 0, 0, NULL, 1, 0, N'mariokovacevic@servis.com', N'Mario', N'Kovaèeviæ', N'0918688097')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'7bf1c463-6d28-4b9e-8be7-4f8a12fb9d77', N'antepetrovic@servis.com', 0, N'AAVZDUHO/ApFn4Km0yVbd9RV2HbaIkcfH75jyfiILTeyfEy9msqQ/6Lyoj1iluz+jw==', N'3f547711-c34a-473e-8933-2e4516df1e3e', NULL, 0, 0, NULL, 1, 0, N'antepetrovic@servis.com', N'Ante', N'Petroviæ', N'0915334854')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'b53c6810-7e16-40d9-988b-9094f9629de7', N'josip.novak@servis.com', 0, N'AOoBTOT6YcLj98/4313zUBaGMoU4CSS3866FvoL8J51p2t4s7KBIJR+g5OlVtDprVw==', N'61df07d2-38b5-4776-a0a4-fce9ac8283ba', NULL, 0, 0, NULL, 1, 0, N'josip.novak@servis.com', N'Josip', N'Novak', N'0916325463')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'dc7b8e58-9e14-4adc-96af-28b8d0711269', N'lukababic@servis.com', 0, N'AGnRWA+ffj/4FtaRJ0BA7BT/etxRWzjeFtt+thPWOwzdxmHKTdKe3z63goXd7g/ZTA==', N'982f6c06-a341-49ae-a589-381d6628be5c', NULL, 0, 0, NULL, 1, 0, N'lukababic@servis.com', N'Luka', N'Babiæ', N'0911826123')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'ee6b1ac2-9669-45d1-b247-b0c3b4bff13a', N'tomislavmatic@servis.com', 0, N'AExlwc2BRrW9CNhW4xgqtg3jIQjrmZx+23fyIekPYQ5YWVOmb+6ZuDc8BvsRxiL3YQ==', N'47e4fd87-1b2a-4528-8e75-2422f535b0b4', NULL, 0, 0, NULL, 1, 0, N'tomislavmatic@servis.com', N'Tomislav', N'Matiæ', N'0916061928')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0a545f57-54b8-4475-8bd4-29337d790d7d', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4068d904-a493-4fa6-a098-018789fe15b9', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e6b2b18-1315-4283-8533-e9ce5e88b589', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7bf1c463-6d28-4b9e-8be7-4f8a12fb9d77', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b53c6810-7e16-40d9-988b-9094f9629de7', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc7b8e58-9e14-4adc-96af-28b8d0711269', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ee6b1ac2-9669-45d1-b247-b0c3b4bff13a', N'088a3a96-afcc-4cde-8b4c-3c49a533f5c0')

");
        }
        
        public override void Down()
        {
        }
    }
}
