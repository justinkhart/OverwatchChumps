using OWWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWWeb.DataLayer
{
    public class PlayerInitializer : System.Data.Entity.CreateDatabaseIfNotExists<PlayerContext>
    {
        /// <summary>
        /// Is only used during development to seed data into the database. 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(PlayerContext context)
        {
            //var players = new List<Player>
            //{
            //    new Player{BattleTag="liamsteele#1184",Name="",Location=""},
            //    new Player{BattleTag="BawssNass#11834",Name="",Location=""},
            //    new Player{BattleTag="Arkhaeon#6384",Name="",Location=""},
            //    new Player{BattleTag="Soul#14626",Name="",Location=""},
            //    new Player{BattleTag="Katrial#1382",Name="",Location=""},
            //    new Player{BattleTag="Jeebers#11532",Name="",Location=""},
            //    new Player{BattleTag="studro#1458",Name="",Location=""},
            //    new Player{BattleTag="rektasaurus#11444",Name="",Location=""},
            //    new Player{BattleTag="Godlike#6626",Name="",Location=""},
            //    new Player{BattleTag="busterblues#6886",Name="",Location=""},
            //    new Player{BattleTag="Dom#12634",Name="",Location=""},
            //    new Player{BattleTag="RathRa#6697",Name="Justin",Location="Brisbane"},
            //    new Player{BattleTag="Perseus#1381",Name="",Location=""},
            //    new Player{BattleTag="superslug#6762",Name="",Location=""}
            //};

            //players.ForEach(p => context.Players.Add(p));
            //context.SaveChanges();
        }
    }
}