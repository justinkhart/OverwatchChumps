namespace OWWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedushortbacktoshortIthinkitwasbreakingazuresql : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RankHistory", "CompetitiveRank", c => c.Short());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RankHistory", "CompetitiveRank");
        }
    }
}
