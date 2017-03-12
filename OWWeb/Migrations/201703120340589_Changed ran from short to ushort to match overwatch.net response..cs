namespace OWWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedranfromshorttoushorttomatchoverwatchnetresponse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RankHistory", "CompetitiveRank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RankHistory", "CompetitiveRank", c => c.Short());
        }
    }
}
