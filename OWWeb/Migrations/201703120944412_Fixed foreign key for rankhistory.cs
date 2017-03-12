namespace OWWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixedforeignkeyforrankhistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RankHistory", "Player_PlayerID", "dbo.Player");
            DropIndex("dbo.RankHistory", new[] { "Player_PlayerID" });
            RenameColumn(table: "dbo.RankHistory", name: "Player_PlayerID", newName: "PlayerID");
            AlterColumn("dbo.RankHistory", "PlayerID", c => c.Int(nullable: false));
            CreateIndex("dbo.RankHistory", "PlayerID");
            AddForeignKey("dbo.RankHistory", "PlayerID", "dbo.Player", "PlayerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RankHistory", "PlayerID", "dbo.Player");
            DropIndex("dbo.RankHistory", new[] { "PlayerID" });
            AlterColumn("dbo.RankHistory", "PlayerID", c => c.Int());
            RenameColumn(table: "dbo.RankHistory", name: "PlayerID", newName: "Player_PlayerID");
            CreateIndex("dbo.RankHistory", "Player_PlayerID");
            AddForeignKey("dbo.RankHistory", "Player_PlayerID", "dbo.Player", "PlayerID");
        }
    }
}
