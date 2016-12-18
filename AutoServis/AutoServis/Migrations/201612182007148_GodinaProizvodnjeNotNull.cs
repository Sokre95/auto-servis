namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GodinaProizvodnjeNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vozilo", "godProizv", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voziloes", "godProizv", c => c.DateTime());
        }
    }
}
