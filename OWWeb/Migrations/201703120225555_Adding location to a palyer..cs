namespace OWWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addinglocationtoapalyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BattleTag = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.RankHistory",
                c => new
                    {
                        RankHistoryID = c.Int(nullable: false, identity: true),
                        CompetitiveRank = c.Short(),
                        Timestamp = c.DateTime(nullable: false),
                        Tier = c.Int(),
                        Player_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.RankHistoryID)
                .ForeignKey("dbo.Player", t => t.Player_PlayerID)
                .Index(t => t.Player_PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RankHistory", "Player_PlayerID", "dbo.Player");
            DropIndex("dbo.RankHistory", new[] { "Player_PlayerID" });
            DropTable("dbo.RankHistory");
            DropTable("dbo.Player");
        }
    }
}
