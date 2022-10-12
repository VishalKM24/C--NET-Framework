namespace EFHandsOn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Long(nullable: false, identity: true),
                        PhoneDescripion = c.String(),
                        Price = c.Single(nullable: false),
                        ManufacturingDate = c.DateTime(nullable: false),
                        BrandName = c.String(),
                        InStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Phones");
        }
    }
}
