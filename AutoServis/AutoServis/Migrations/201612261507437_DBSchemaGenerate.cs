namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DBSchemaGenerate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Kontakt",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImeServisa = c.String(nullable: false, maxLength: 100),
                        BrojTel = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Mjesto = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Popravak",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumVrijeme = c.DateTime(nullable: false),
                        DodatniOpis = c.String(maxLength: 500),
                        KorisnikId = c.Int(nullable: false),
                        VoziloId = c.Int(nullable: false),
                        ServiserId = c.Int(nullable: false),
                        ZamjenskoVoziloId = c.Int(nullable: false),
                        UslugaId = c.Int(nullable: false),
                        Korisnik_Id = c.String(maxLength: 128),
                        Serviser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vozilo", t => t.VoziloId)
                .ForeignKey("dbo.Serviser", t => t.Serviser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usluga", t => t.UslugaId, cascadeDelete: true)
                .ForeignKey("dbo.ZamjenskoVozilo", t => t.ZamjenskoVoziloId, cascadeDelete: true)
                .Index(t => t.VoziloId)
                .Index(t => t.ZamjenskoVoziloId)
                .Index(t => t.UslugaId)
                .Index(t => t.Korisnik_Id)
                .Index(t => t.Serviser_Id);

            CreateTable(
                    "dbo.AspNetUsers",
                    c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                    "dbo.AspNetUserClaims",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.AspNetUserLogins",
                    c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.AspNetUserRoles",
                    c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                    "dbo.Vozilo",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GodProizv = c.String(),
                        RegOznaka = c.String(maxLength: 10),
                        KorisnikId = c.String(maxLength: 128),
                        TipVozilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisnik", t => t.KorisnikId, cascadeDelete: true)
                .ForeignKey("dbo.TipVozila", t => t.TipVozilaId, cascadeDelete: true)
                .Index(t => t.KorisnikId)
                .Index(t => t.TipVozilaId);

            CreateTable(
                    "dbo.TipVozila",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Usluga",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.ZamjenskoVozilo",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegOznaka = c.String(nullable: false, maxLength: 10),
                        Dostupno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.AspNetRoles",
                    c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                    "dbo.Korisnik",
                    c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                    "dbo.Serviser",
                    c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Serviser", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Korisnik", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Popravak", "ZamjenskoVoziloId", "dbo.ZamjenskoVozilo");
            DropForeignKey("dbo.Popravak", "UslugaId", "dbo.Usluga");
            DropForeignKey("dbo.Popravak", "Serviser_Id", "dbo.Serviser");
            DropForeignKey("dbo.Vozilo", "TipVozilaId", "dbo.TipVozila");
            DropForeignKey("dbo.Popravak", "VoziloId", "dbo.Vozilo");
            DropForeignKey("dbo.Vozilo", "KorisnikId", "dbo.Korisnik");
            DropForeignKey("dbo.Popravak", "Korisnik_Id", "dbo.Korisnik");
            DropIndex("dbo.Serviser", new[] {"Id"});
            DropIndex("dbo.Korisnik", new[] {"Id"});
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Vozilo", new[] {"TipVozilaId"});
            DropIndex("dbo.Vozilo", new[] {"KorisnikId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Popravak", new[] {"Serviser_Id"});
            DropIndex("dbo.Popravak", new[] {"Korisnik_Id"});
            DropIndex("dbo.Popravak", new[] {"UslugaId"});
            DropIndex("dbo.Popravak", new[] {"ZamjenskoVoziloId"});
            DropIndex("dbo.Popravak", new[] {"VoziloId"});
            DropTable("dbo.Serviser");
            DropTable("dbo.Korisnik");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ZamjenskoVozilo");
            DropTable("dbo.Usluga");
            DropTable("dbo.TipVozila");
            DropTable("dbo.Vozilo");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Popravak");
            DropTable("dbo.Kontakt");
        }
    }
}