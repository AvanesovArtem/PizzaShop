namespace PizzaShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Absolutepath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Absolutepath", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 1000));
        }
    }
}
