namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBazeKontaktPodacima : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Kontakt] ON
INSERT INTO [dbo].[Kontakt] ([Id], [ImeServisa], [BrojTel], [Adresa], [Mjesto], [Email]) VALUES (1, N'Najbolji mehanièar', N'45555123', N'Trg bana Josipa Jelaèiæa 1', N'10000 Zagreb', N'mehanicar@servis.com')
SET IDENTITY_INSERT [dbo].[Kontakt] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
