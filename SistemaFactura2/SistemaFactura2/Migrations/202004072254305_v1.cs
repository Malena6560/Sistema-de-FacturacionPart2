namespace SistemaFactura2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IDCategoria = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                    })
                .PrimaryKey(t => t.IDCategoria);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDClientes = c.Int(nullable: false, identity: true),
                        RNC = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(),
                        IDCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDClientes)
                .ForeignKey("dbo.Categorias", t => t.IDCategoria, cascadeDelete: true)
                .Index(t => t.IDCategoria);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        IDDetalle = c.Int(nullable: false, identity: true),
                        IDFactura = c.Int(nullable: false),
                        IDProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDDetalle)
                .ForeignKey("dbo.Facturas", t => t.IDFactura, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.IDProducto, cascadeDelete: true)
                .Index(t => t.IDFactura)
                .Index(t => t.IDProducto);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IDFactura = c.Int(nullable: false, identity: true),
                        IDCliente = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITBIS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaFactura = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDFactura)
                .ForeignKey("dbo.Clientes", t => t.IDCliente, cascadeDelete: true)
                .Index(t => t.IDCliente);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IDProductos = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDProductos);
            
            CreateTable(
                "dbo.EntradaMercancias",
                c => new
                    {
                        IDEntrada = c.Int(nullable: false, identity: true),
                        IDProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        IDProveedor = c.Int(nullable: false),
                        FechaEntrada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEntrada)
                .ForeignKey("dbo.Productos", t => t.IDProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedores", t => t.IDProveedor, cascadeDelete: true)
                .Index(t => t.IDProducto)
                .Index(t => t.IDProveedor);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IDProveedores = c.Int(nullable: false, identity: true),
                        RNC = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDProveedores);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntradaMercancias", "IDProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.EntradaMercancias", "IDProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleFacturas", "IDProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleFacturas", "IDFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "IDCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "IDCategoria", "dbo.Categorias");
            DropIndex("dbo.EntradaMercancias", new[] { "IDProveedor" });
            DropIndex("dbo.EntradaMercancias", new[] { "IDProducto" });
            DropIndex("dbo.Facturas", new[] { "IDCliente" });
            DropIndex("dbo.DetalleFacturas", new[] { "IDProducto" });
            DropIndex("dbo.DetalleFacturas", new[] { "IDFactura" });
            DropIndex("dbo.Clientes", new[] { "IDCategoria" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.EntradaMercancias");
            DropTable("dbo.Productos");
            DropTable("dbo.Facturas");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
