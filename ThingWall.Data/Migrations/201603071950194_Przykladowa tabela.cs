namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Przykladowatabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExampleItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExampleItems", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.ExampleItems", new[] { "OwnerId" });
            DropTable("dbo.ExampleItems");
        }
    }
}
