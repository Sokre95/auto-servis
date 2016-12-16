namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserUmjestoKorisnika : DbMigration
    {
        public override void Up()
        {
			Sql(@"
ALTER TABLE [dbo].[Popravak] DROP CONSTRAINT [FK_dbo.Popravak_dbo.Korisnik_Korisnik_id]

ALTER TABLE [dbo].[Vozilo] DROP CONSTRAINT [FK_dbo.Vozilo_dbo.Korisnik_Korisnik_id]");

			DropTable("dbo.Korisnik");
			DropIndex("dbo.Popravak", new[] { "Korisnik_id" });
            DropIndex("dbo.Vozilo", new[] { "Korisnik_id" });
            AlterColumn("dbo.Popravak", "Korisnik_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vozilo", "Korisnik_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Popravak", "Korisnik_Id");
            CreateIndex("dbo.Vozilo", "Korisnik_Id");
        }
        
        public override void Down()
        {
			CreateTable(
				"dbo.Korisnik",
				c => new
				{
					id = c.Int(nullable: false, identity: true),
					eMail = c.String(nullable: false, maxLength: 30),
					ime = c.String(maxLength: 30),
					prezime = c.String(maxLength: 30),
					lozinka = c.String(nullable: false, maxLength: 30),
					brTel = c.String(maxLength: 20),
				})
				.PrimaryKey(t => t.id);

			DropIndex("dbo.Vozilo", new[] { "Korisnik_Id" });
			DropIndex("dbo.Popravak", new[] { "Korisnik_Id" });
			AlterColumn("dbo.Vozilo", "Korisnik_Id", c => c.Int());
			AlterColumn("dbo.Popravak", "Korisnik_Id", c => c.Int());
			CreateIndex("dbo.Vozilo", "Korisnik_id");
			CreateIndex("dbo.Popravak", "Korisnik_id");
		}
    }
}
