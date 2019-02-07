namespace CVRaul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitantes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitantes");
        }
    }
}
