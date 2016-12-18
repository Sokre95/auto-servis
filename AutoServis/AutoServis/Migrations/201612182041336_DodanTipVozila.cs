namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanTipVozila : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipVozila",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vozilo", "TipVozila_Id", c => c.Int());
            CreateIndex("dbo.Vozilo", "TipVozila_Id");
            AddForeignKey("dbo.Vozilo", "TipVozila_Id", "dbo.TipVozila", "Id");
            DropColumn("dbo.Vozilo", "IdKorisnik");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voziloes", "IdKorisnik", c => c.Int(nullable: false));
            DropForeignKey("dbo.Voziloes", "TipVozila_Id", "dbo.TipVozilas");
            DropIndex("dbo.Voziloes", new[] { "TipVozila_Id" });
            DropColumn("dbo.Voziloes", "TipVozila_Id");
            DropTable("dbo.TipVozilas");
        }
    }
}
