namespace CVRaul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitantes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitantes", "Ip", c => c.String());
            AddColumn("dbo.Visitantes", "Visitas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitantes", "Visitas");
            DropColumn("dbo.Visitantes", "Ip");
        }
    }
}
