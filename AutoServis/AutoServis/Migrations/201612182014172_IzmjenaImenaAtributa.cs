namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IzmjenaImenaAtributa : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DodatnaUsluga", new[] { "Popravak_id" });
            DropIndex("dbo.Popravak", new[] { "Vozilo_id" });
            DropIndex("dbo.UslugaPopravak", new[] { "Usluga_id" });
            DropIndex("dbo.UslugaPopravak", new[] { "Popravak_id" });
            DropIndex("dbo.ZamjenskoVoziloPopravak", new[] { "ZamjenskoVozilo_id" });
            DropIndex("dbo.ZamjenskoVoziloPopravak", new[] { "Popravak_id" });
            AddColumn("dbo.DodatnaUsluga", "IdPopravak", c => c.Int(nullable: false));
            AddColumn("dbo.Popravak", "IdKorisnik", c => c.Int(nullable: false));
            AddColumn("dbo.Popravak", "IdVozilo", c => c.Int(nullable: false));
            AddColumn("dbo.Popravak", "IdServiser", c => c.Int(nullable: false));
            AddColumn("dbo.Vozilo", "IdKorisnik", c => c.Int(nullable: false));
            AlterColumn("dbo.Popravak", "DatumVrijeme", c => c.DateTime(nullable: false));
            CreateIndex("dbo.DodatnaUsluga", "Popravak_Id");
            CreateIndex("dbo.Popravak", "Vozilo_Id");
            CreateIndex("dbo.UslugaPopravak", "Usluga_Id");
            CreateIndex("dbo.UslugaPopravak", "Popravak_Id");
            CreateIndex("dbo.ZamjenskoVoziloPopravak", "ZamjenskoVozilo_Id");
            CreateIndex("dbo.ZamjenskoVoziloPopravak", "Popravak_Id");
            DropColumn("dbo.DodatnaUsluga", "id_popravak");
            DropColumn("dbo.Popravak", "id_korisnik");
            DropColumn("dbo.Popravak", "id_Vozilo");
            DropColumn("dbo.Popravak", "id_serviser");
            DropColumn("dbo.Vozilo", "id_korisnik");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voziloes", "id_korisnik", c => c.Int(nullable: false));
            AddColumn("dbo.Popravaks", "id_serviser", c => c.Int(nullable: false));
            AddColumn("dbo.Popravaks", "id_Vozilo", c => c.Int(nullable: false));
            AddColumn("dbo.Popravaks", "id_korisnik", c => c.Int(nullable: false));
            AddColumn("dbo.DodatnaUslugas", "id_popravak", c => c.Int(nullable: false));
            DropIndex("dbo.ZamjenskoVoziloPopravaks", new[] { "Popravak_Id" });
            DropIndex("dbo.ZamjenskoVoziloPopravaks", new[] { "ZamjenskoVozilo_Id" });
            DropIndex("dbo.UslugaPopravaks", new[] { "Popravak_Id" });
            DropIndex("dbo.UslugaPopravaks", new[] { "Usluga_Id" });
            DropIndex("dbo.Popravaks", new[] { "Vozilo_Id" });
            DropIndex("dbo.DodatnaUslugas", new[] { "Popravak_Id" });
            AlterColumn("dbo.Popravaks", "DatumVrijeme", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Voziloes", "IdKorisnik");
            DropColumn("dbo.Popravaks", "IdServiser");
            DropColumn("dbo.Popravaks", "IdVozilo");
            DropColumn("dbo.Popravaks", "IdKorisnik");
            DropColumn("dbo.DodatnaUslugas", "IdPopravak");
            CreateIndex("dbo.ZamjenskoVoziloPopravaks", "Popravak_id");
            CreateIndex("dbo.ZamjenskoVoziloPopravaks", "ZamjenskoVozilo_id");
            CreateIndex("dbo.UslugaPopravaks", "Popravak_id");
            CreateIndex("dbo.UslugaPopravaks", "Usluga_id");
            CreateIndex("dbo.Popravaks", "Vozilo_id");
            CreateIndex("dbo.DodatnaUslugas", "Popravak_id");
        }
    }
}
