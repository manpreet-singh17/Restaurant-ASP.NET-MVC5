namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "State");
        }
    }
}
