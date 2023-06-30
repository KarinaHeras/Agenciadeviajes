namespace AgenciaViajesKarinaHeras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencia",
                c => new
                    {
                        AgenciaId = c.Int(nullable: false, identity: true),
                        CodigoViaje = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaViaje = c.DateTime(nullable: false),
                        Role = c.Int(),
                        Destino_DestinoID = c.Int(),
                        Viajero_IdViajero = c.Int(),
                    })
                .PrimaryKey(t => t.AgenciaId)
                .ForeignKey("dbo.Destino", t => t.Destino_DestinoID)
                .ForeignKey("dbo.Viajero", t => t.Viajero_IdViajero)
                .Index(t => t.Destino_DestinoID)
                .Index(t => t.Viajero_IdViajero);
            
            CreateTable(
                "dbo.Destino",
                c => new
                    {
                        DestinoID = c.Int(nullable: false),
                        CodigoViaje = c.Int(nullable: false),
                        ViajeroId = c.Int(nullable: false),
                        Ciudad = c.String(),
                        Pais = c.String(),
                    })
                .PrimaryKey(t => t.DestinoID);
            
            CreateTable(
                "dbo.Viajero",
                c => new
                    {
                        IdViajero = c.Int(nullable: false, identity: true),
                        Dni = c.String(),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdViajero);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agencia", "Viajero_IdViajero", "dbo.Viajero");
            DropForeignKey("dbo.Agencia", "Destino_DestinoID", "dbo.Destino");
            DropIndex("dbo.Agencia", new[] { "Viajero_IdViajero" });
            DropIndex("dbo.Agencia", new[] { "Destino_DestinoID" });
            DropTable("dbo.Viajero");
            DropTable("dbo.Destino");
            DropTable("dbo.Agencia");
        }
    }
}
