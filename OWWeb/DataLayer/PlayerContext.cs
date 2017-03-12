using OWWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OWWeb.DataLayer
{
    public class PlayerContext : DbContext
    {

        public PlayerContext() : base("PlayerContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<RankHistory> RankHistorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}