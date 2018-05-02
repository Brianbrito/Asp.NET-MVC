namespace MaestroD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reparacion1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jugadores", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Jugadores", "Apellido", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jugadores", "Apellido", c => c.String());
            AlterColumn("dbo.Jugadores", "Nombre", c => c.String());
        }
    }
}
