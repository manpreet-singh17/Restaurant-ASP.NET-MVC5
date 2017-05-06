namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Rating = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantID" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.RestaurantReviews");
        }
    }
}
