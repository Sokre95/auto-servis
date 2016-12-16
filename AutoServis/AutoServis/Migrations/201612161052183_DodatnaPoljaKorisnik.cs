namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatnaPoljaKorisnik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Ime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String());
            AddColumn("dbo.AspNetUsers", "BrojTel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BrojTel");
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "Ime");
            RenameTable(name: "dbo.ZamjenskoVoziloes", newName: "ZamjenskoVozilo");
            RenameTable(name: "dbo.Uslugas", newName: "Usluga");
            RenameTable(name: "dbo.Servisers", newName: "Serviser");
            RenameTable(name: "dbo.Voziloes", newName: "Vozilo");
            RenameTable(name: "dbo.Korisniks", newName: "Korisnik");
            RenameTable(name: "dbo.Popravaks", newName: "Popravak");
            RenameTable(name: "dbo.Administrators", newName: "Administrator");
        }
    }
}
