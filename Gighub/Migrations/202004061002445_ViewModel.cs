namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "Artisit_Id", newName: "Artist_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artisit_Id", newName: "IX_Artist_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_Artisit_Id");
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "Artisit_Id");
        }
    }
}
