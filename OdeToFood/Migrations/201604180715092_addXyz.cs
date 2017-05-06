namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addXyz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantReviews", "xyz", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantReviews", "xyz");
        }
    }
}
