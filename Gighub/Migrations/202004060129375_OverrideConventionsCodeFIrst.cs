namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsCodeFIrst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                        Artisit_Id = c.String(nullable: false, maxLength: 128),
                        Genre_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artisit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Artisit_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artisit_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artisit_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
