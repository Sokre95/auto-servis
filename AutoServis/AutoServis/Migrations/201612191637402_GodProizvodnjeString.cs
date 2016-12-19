namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GodProizvodnjeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vozilo", "GodProizv", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vozilo", "GodProizv", c => c.DateTime(nullable: false));
        }
    }
}
