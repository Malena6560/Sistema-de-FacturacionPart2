namespace SistemaFactura2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proveedores", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proveedores", "Email", c => c.String(nullable: false));
        }
    }
}
