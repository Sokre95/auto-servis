namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kontakt", newName: "Kontakt");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Kontakt", newName: "Kontakt");
        }
    }
}
