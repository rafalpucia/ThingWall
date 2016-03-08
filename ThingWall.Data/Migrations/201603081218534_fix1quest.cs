namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1quest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "OwnerId" });
            AlterColumn("dbo.Items", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Items", "OwnerId");
            AddForeignKey("dbo.Items", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "OwnerId" });
            AlterColumn("dbo.Items", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Items", "OwnerId");
            AddForeignKey("dbo.Items", "OwnerId", "dbo.AspNetUsers", "Id");
        }
    }
}
