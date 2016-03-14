namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Nick", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Nick", c => c.String());
        }
    }
}
