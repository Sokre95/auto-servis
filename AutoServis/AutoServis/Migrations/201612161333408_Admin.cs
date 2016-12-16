namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Ime], [Prezime], [BrojTel]) VALUES (N'2df51191-9e49-4c49-9bef-a1170ebc2e18', N'admin@servis.com', 0, N'AAiWSQC32wsd1HZwb3NvjlSOLrKTpvXvfsjMfSx/535ejrhc/2V4EjTZayxDG1aXIQ==', N'14611597-1261-4a56-a8d6-af8fdee9eb29', NULL, 0, 0, NULL, 1, 0, N'admin@servis.com', N'Marko', N'Horvat', N'012345678')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f4dd8dbe-d542-400e-998c-006f9166348a', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2df51191-9e49-4c49-9bef-a1170ebc2e18', N'f4dd8dbe-d542-400e-998c-006f9166348a')
");
        }
        
        public override void Down()
        {
        }
    }
}
