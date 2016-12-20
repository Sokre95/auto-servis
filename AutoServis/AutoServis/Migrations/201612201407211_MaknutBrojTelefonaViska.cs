namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaknutBrojTelefonaViska : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "BrojTel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BrojTel", c => c.String());
        }
    }
}
