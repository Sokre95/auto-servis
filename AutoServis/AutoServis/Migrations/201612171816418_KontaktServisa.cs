namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KontaktServisa : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kontakt");
        }
    }
}
