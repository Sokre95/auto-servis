namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserFK : DbMigration
    {
        public override void Up()
        {
			Sql(@"
ALTER TABLE [dbo].[Popravak] ADD CONSTRAINT [FK_dbo.Popravak_dbo.AspNetUsers_Id] FOREIGN KEY (Korisnik_id) REFERENCES [dbo].[AspNetUsers] (Id)

ALTER TABLE [dbo].[Vozilo] ADD CONSTRAINT [FK_dbo.Vozilo_dbo.AspNetUsers_Id] FOREIGN KEY (Korisnik_id) REFERENCES [dbo].[AspNetUsers] (Id)");
		}
        
        public override void Down()
        {
        }
    }
}
