namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromjeneModela : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Popravak", "Korisnik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Popravak", "Serviser_Id", "dbo.Serviser");

            DropIndex("dbo.Popravak", new[] { "Serviser_id" });
            DropIndex("dbo.Popravak", new[] { "Korisnik_Id" });
            DropIndex("dbo.Vozilo", new[] { "Korisnik_Id" });

            AlterColumn("dbo.Popravak", "Korisnik_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vozilo", "Korisnik_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Popravak", "Serviser_Id", c => c.String(maxLength: 128));

            CreateIndex("dbo.Popravak", "Serviser_Id");
            CreateIndex("dbo.Popravak", "Korisnik_Id");
            CreateIndex("dbo.Vozilo", "Korisnik_Id");

            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));

            AddForeignKey("dbo.Vozilo", "Korisnik_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Popravak", "Korisnik_Id", "dbo.AspNetUsers", "Id");

            DropTable("dbo.Administrator");
            DropTable("dbo.Serviser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Servisers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eMail = c.String(maxLength: 30),
                        lozinka = c.String(nullable: false, maxLength: 30),
                        ime = c.String(maxLength: 30),
                        prezime = c.String(maxLength: 30),
                        brTel = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 10),
                        ime = c.String(maxLength: 10),
                        prezime = c.String(maxLength: 30),
                        lozinka = c.String(nullable: false, maxLength: 30),
                        brTel = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Popravaks", "Korisnik_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Voziloes", "Korisnik_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Popravaks", "Korisnik_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Voziloes", new[] { "Korisnik_Id1" });
            DropIndex("dbo.Popravaks", new[] { "Korisnik_Id1" });
            DropIndex("dbo.Popravaks", new[] { "Serviser_Id" });
            AlterColumn("dbo.Popravaks", "Serviser_Id", c => c.Int());
            DropColumn("dbo.Voziloes", "Korisnik_Id1");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Popravaks", "Korisnik_Id1");
            CreateIndex("dbo.Popravaks", "Serviser_id");
            AddForeignKey("dbo.Popravaks", "Korisnik_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
