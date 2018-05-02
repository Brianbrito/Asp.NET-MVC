namespace MaestroD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MVC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipoes",
                c => new
                    {
                        NombreEquipo = c.String(nullable: false, maxLength: 30),
                        Pais = c.String(),
                        Provincia = c.String(),
                    })
                .PrimaryKey(t => t.NombreEquipo);
            
            CreateTable(
                "dbo.Jugadors",
                c => new
                    {
                        JugadorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Posicion = c.String(),
                        NombreEquipo = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.JugadorId)
                .ForeignKey("dbo.Equipoes", t => t.NombreEquipo)
                .Index(t => t.NombreEquipo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jugadors", "NombreEquipo", "dbo.Equipoes");
            DropIndex("dbo.Jugadors", new[] { "NombreEquipo" });
            DropTable("dbo.Jugadors");
            DropTable("dbo.Equipoes");
        }
    }
}
