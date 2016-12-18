namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopunaBazeTipovimaVozila : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[TipVozila] ON
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (1, N'Adam')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (2, N'Astra')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (3, N'Cascada')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (4, N'Corsa')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (5, N'Insignia')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (6, N'Karl')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (7, N'Meriva')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (8, N'Mocca X')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (9, N'Zafira')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (10, N'Combo')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (11, N'Combo Tour')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (12, N'Corsavan')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (13, N'Movano')
INSERT INTO [dbo].[TipVozila] ([Id], [Naziv]) VALUES (14, N'Vivaro')
SET IDENTITY_INSERT [dbo].[TipVozila] OFF"
);
        }
        
        public override void Down()
        {
        }
    }
}
