namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemAndNick : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            AddColumn("dbo.AspNetUsers", "Nick", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "OwnerId" });
            DropColumn("dbo.AspNetUsers", "Nick");
            DropTable("dbo.Items");
        }
    }
}
