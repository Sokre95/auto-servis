namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBaze : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'68e408e9-7e27-4e0d-87da-b99b7ee8616d', N'Marko', N'Horvat', N'0991234567', N'admin@servis.com', 0, N'AKZmSUa9BgZlvVG4g5OOzq3fAZTcJW5/POO3olERm7RUKxQGSOH8HCrrV5dVDQZ/+w==', N'f8d81808-810e-4d96-a160-c8d49f1fc681', NULL, 0, 0, NULL, 1, 0, N'admin@servis.com', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7cd00e8e-0295-44ab-8e3b-1e67206f74fe', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'68e408e9-7e27-4e0d-87da-b99b7ee8616d', N'7cd00e8e-0295-44ab-8e3b-1e67206f74fe')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'62d4801d-f955-4063-8b8b-2a333945c397', N'Serviser')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'c3dc60a1-257c-491e-9f79-fd3bafce26fa', N'Ivan', N'Juriæ', N'0917967454', N'ivan.juric@servis.com', 0, N'ABsZSN6CN4zI4TXjp8lVi5bkQKi1nw9ftu6uTuNPoTtIWQtnDHVeVICUY5dY9kRdtQ==', N'f58236b9-5465-4d2d-8b58-1f80fe8e2807', NULL, 0, 0, NULL, 1, 0, N'ivan.juric@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'22fe4562-b31a-4221-a8df-5c9b29b3c9e8', N'Ante', N'Petroviæ', N'0915334854', N'ante.petrovic@servis.com', 0, N'AD/WHI5Vfx9fdgn1skkNeXNgPaIXRHvUbOBVBk/OFqDvA9bXgNfTgI88vsDsvrQhDg==', N'0547d7b6-59d3-4720-9caa-283edc212769', NULL, 0, 0, NULL, 1, 0, N'ante.petrovic@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'453ecd9e-6afb-4915-8f41-47f44909cf51', N'Mario', N'Kovaèeviæ', N'0918688097', N'mario.kovacevic@servis.com', 0, N'AMX2UN7QKeF12eYNuJWrH9siXtjKlLWqz8YBNWXLaixAQvOQYE49gnRHV+hBQZisUg==', N'11f8d8a5-9d08-43c5-bae0-a20bb0183913', NULL, 0, 0, NULL, 1, 0, N'mario.kovacevic@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'94df3de5-11c2-40f9-acf8-da07e8f7cef2', N'Kristijan', N'Markoviæ', N'0918897619', N'kristijan.markovic@servis.com', 0, N'AMzp3ThTkIiwdwS9R5VXAT4HEYRYtRa3FsHQfklXyezwyZa1ZxWiVH/vxyamsu0A1g==', N'26765e9d-048c-4c8f-827e-ebc54121ce33', NULL, 0, 0, NULL, 1, 0, N'kristijan.markovic@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'a4d53de5-36d8-4035-bf18-31d6f99d72e1', N'Luka', N'Babiæ', N'0911826123', N'luka.babic@servis.com', 0, N'ACsmTXIg+5bD9wruoADC/fSeot45I5QOpMqbazxmh8NRDFPoluMzVdDJow5Xivjdxg==', N'afea1362-5dc1-43d5-9c20-e68185a35eac', NULL, 0, 0, NULL, 1, 0, N'luka.babic@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'b74d5dbe-6cb5-4efb-9c0e-6a0dcbd1f49c', N'Tomislav', N'Matiæ', N'0916061928', N'tomislav.matic@servis.com', 0, N'AAELvp69m26mXWEmkLweimqMOBgsJpfqCIRgWfEyjQA0Mv22Ef/OQWAWbIa/1lSORg==', N'0e70d361-b6ab-4893-ada2-0d3a32ca514a', NULL, 0, 0, NULL, 1, 0, N'tomislav.matic@servis.com', N'Serviser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Ime], [Prezime], [BrojTel], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'f9988085-5afb-4a4d-b315-78728fd65586', N'Josip', N'Novak', N'0916325463', N'josip.novak@servis.com', 0, N'AA+8DXRzEjWWbKxnvH7XE0F1bOhgCa/Ma9PUrA5xR6h6LckrnejE2QMAQOEhuMJv1A==', N'a3fc4307-5c6c-4823-8952-97b367af6d70', NULL, 0, 0, NULL, 1, 0, N'josip.novak@servis.com', N'Serviser')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c3dc60a1-257c-491e-9f79-fd3bafce26fa', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22fe4562-b31a-4221-a8df-5c9b29b3c9e8', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'453ecd9e-6afb-4915-8f41-47f44909cf51', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'94df3de5-11c2-40f9-acf8-da07e8f7cef2', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4d53de5-36d8-4035-bf18-31d6f99d72e1', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b74d5dbe-6cb5-4efb-9c0e-6a0dcbd1f49c', N'62d4801d-f955-4063-8b8b-2a333945c397')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f9988085-5afb-4a4d-b315-78728fd65586', N'62d4801d-f955-4063-8b8b-2a333945c397')
");
        }
        
        public override void Down()
        {
        }
    }
}
