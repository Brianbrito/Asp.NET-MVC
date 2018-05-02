namespace MaestroD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reparacion2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jugadores", "NombreEquipo", "dbo.Equipos");
            DropIndex("dbo.Jugadores", new[] { "NombreEquipo" });
            RenameColumn(table: "dbo.Jugadores", name: "NombreEquipo", newName: "EquipoId");
            DropPrimaryKey("dbo.Equipos");
            AddColumn("dbo.Equipos", "EquipoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Equipos", "NombreEquipo", c => c.String());
            AlterColumn("dbo.Jugadores", "EquipoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Equipos", "EquipoId");
            CreateIndex("dbo.Jugadores", "EquipoId");
            AddForeignKey("dbo.Jugadores", "EquipoId", "dbo.Equipos", "EquipoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jugadores", "EquipoId", "dbo.Equipos");
            DropIndex("dbo.Jugadores", new[] { "EquipoId" });
            DropPrimaryKey("dbo.Equipos");
            AlterColumn("dbo.Jugadores", "EquipoId", c => c.String(maxLength: 30));
            AlterColumn("dbo.Equipos", "NombreEquipo", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Equipos", "EquipoId");
            AddPrimaryKey("dbo.Equipos", "NombreEquipo");
            RenameColumn(table: "dbo.Jugadores", name: "EquipoId", newName: "NombreEquipo");
            CreateIndex("dbo.Jugadores", "NombreEquipo");
            AddForeignKey("dbo.Jugadores", "NombreEquipo", "dbo.Equipos", "NombreEquipo");
        }
    }
}
