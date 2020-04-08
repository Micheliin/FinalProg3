namespace FinalProgamacion3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proveedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDClientes = c.Int(nullable: false, identity: true),
                        RNC_Cedula = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDClientes);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IDProveedores = c.Int(nullable: false, identity: true),
                        RNC_cedula = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDProveedores);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proveedores");
            DropTable("dbo.Productos");
            DropTable("dbo.Clientes");
        }
    }
}
