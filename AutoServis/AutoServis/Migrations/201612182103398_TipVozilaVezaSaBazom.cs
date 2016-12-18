namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipVozilaVezaSaBazom : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TipVozila", newName: "TipVozila");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TipVozila", newName: "TipVozila");
        }
    }
}
