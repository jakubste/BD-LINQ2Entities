namespace StepakJakub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommentstopost : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
        }
    }
}
