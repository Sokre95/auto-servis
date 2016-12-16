namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
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
            
            CreateTable(
                "dbo.DodatnaUsluga",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_popravak = c.Int(nullable: false),
                        opis = c.String(maxLength: 500),
                        Popravak_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Popravak", t => t.Popravak_id)
                .Index(t => t.Popravak_id);
            
            CreateTable(
                "dbo.Popravak",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        datumVrijeme = c.DateTime(nullable: false, storeType: "date"),
                        dodatniOpis = c.String(maxLength: 500),
                        id_korisnik = c.Int(nullable: false),
                        id_Vozilo = c.Int(nullable: false),
                        id_serviser = c.Int(nullable: false),
                        Korisnik_id = c.Int(),
                        Vozilo_id = c.Int(),
                        Serviser_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_id)
                .ForeignKey("dbo.Vozilo", t => t.Vozilo_id)
                .ForeignKey("dbo.Serviser", t => t.Serviser_id)
                .Index(t => t.Korisnik_id)
                .Index(t => t.Vozilo_id)
                .Index(t => t.Serviser_id);
            
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
            
            CreateTable(
                "dbo.Vozilo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        godProizv = c.DateTime(),
                        regOznaka = c.String(maxLength: 10),
                        id_korisnik = c.Int(nullable: false),
                        Korisnik_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_id)
                .Index(t => t.Korisnik_id);
            
            CreateTable(
                "dbo.Serviser",
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
                "dbo.Usluga",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        opis = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ZamjenskoVozilo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        regOznaka = c.String(nullable: false, maxLength: 10),
                        dostupno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UslugaPopravak",
                c => new
                    {
                        Usluga_id = c.Int(nullable: false),
                        Popravak_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usluga_id, t.Popravak_id })
                .ForeignKey("dbo.Usluga", t => t.Usluga_id, cascadeDelete: true)
                .ForeignKey("dbo.Popravak", t => t.Popravak_id, cascadeDelete: true)
                .Index(t => t.Usluga_id)
                .Index(t => t.Popravak_id);
            
            CreateTable(
                "dbo.ZamjenskoVoziloPopravak",
                c => new
                    {
                        ZamjenskoVozilo_id = c.Int(nullable: false),
                        Popravak_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ZamjenskoVozilo_id, t.Popravak_id })
                .ForeignKey("dbo.ZamjenskoVozilo", t => t.ZamjenskoVozilo_id, cascadeDelete: true)
                .ForeignKey("dbo.Popravak", t => t.Popravak_id, cascadeDelete: true)
                .Index(t => t.ZamjenskoVozilo_id)
                .Index(t => t.Popravak_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZamjenskoVoziloPopravaks", "Popravak_id", "dbo.Popravak");
            DropForeignKey("dbo.ZamjenskoVoziloPopravaks", "ZamjenskoVozilo_id", "dbo.ZamjenskoVozilo");
            DropForeignKey("dbo.UslugaPopravaks", "Popravak_id", "dbo.Popravak");
            DropForeignKey("dbo.UslugaPopravaks", "Usluga_id", "dbo.Usluga");
            DropForeignKey("dbo.Popravak", "Serviser_id", "dbo.Serviser");
            DropForeignKey("dbo.Popravak", "Vozilo_id", "dbo.Vozilo");
            DropForeignKey("dbo.Vozilo", "Korisnik_id", "dbo.Korisnik");
            DropForeignKey("dbo.Popravak", "Korisnik_id", "dbo.Korisnik");
            DropForeignKey("dbo.DodatnaUsluga", "Popravak_id", "dbo.Popravak");
            DropIndex("dbo.ZamjenskoVoziloPopravaks", new[] { "Popravak_id" });
            DropIndex("dbo.ZamjenskoVoziloPopravaks", new[] { "ZamjenskoVozilo_id" });
            DropIndex("dbo.UslugaPopravaks", new[] { "Popravak_id" });
            DropIndex("dbo.UslugaPopravaks", new[] { "Usluga_id" });
            DropIndex("dbo.Vozilo", new[] { "Korisnik_id" });
            DropIndex("dbo.Popravak", new[] { "Serviser_id" });
            DropIndex("dbo.Popravak", new[] { "Vozilo_id" });
            DropIndex("dbo.Popravak", new[] { "Korisnik_id" });
            DropIndex("dbo.DodatnaUsluga", new[] { "Popravak_id" });
            DropTable("dbo.ZamjenskoVoziloPopravaks");
            DropTable("dbo.UslugaPopravaks");
            DropTable("dbo.ZamjenskoVozilo");
            DropTable("dbo.Usluga");
            DropTable("dbo.Serviser");
            DropTable("dbo.Vozilo");
            DropTable("dbo.Korisnik");
            DropTable("dbo.Popravak");
            DropTable("dbo.DodatnaUsluga");
            DropTable("dbo.Administrator");
        }
    }
}
