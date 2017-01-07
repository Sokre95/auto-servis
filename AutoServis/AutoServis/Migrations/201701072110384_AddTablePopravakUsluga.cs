namespace AutoServis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTablePopravakUsluga : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.PopravakUsluga",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PopravakId = c.Int(nullable: false),
                        UslugaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usluga", t => t.UslugaId)
                .ForeignKey("dbo.Popravak", t => t.PopravakId)
                .Index(t => t.PopravakId)
                .Index(t => t.UslugaId);
        }

        public override void Down()
        {
            DropTable("dbo.PopravakUsluga");
            DropIndex("dbo.PopravakUsluga", new[] {"PopravakId"});
            DropIndex("dbo.PopravakUsluga", new[] { "UslugaId" });
        }
    }
}