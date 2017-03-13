using OverwatchAPI;
using OWWeb.DataLayer;
using OWWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.ComponentModel;

namespace OWWeb.Controllers
{
    public class HomeController : Controller
    {

        private PlayerContext db = new PlayerContext(); // Player table from database

        /// <summary>
        /// Main page, returns the View and passes in model of Player table.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Left joins from player to rankhistorys, converts any null ranks to 0 and orders by rank
            // Returns all that as a model to the View
            var query = (
                from player in db.Players
                from rankhistory in db.RankHistorys
                    .Where(rankhistory => rankhistory.PlayerID == player.PlayerID)
					.OrderByDescending(rankhistory => rankhistory.Timestamp)
					.Take(1)
					.DefaultIfEmpty()

                select new HomeViewModel
                {
                    Name = player.Name,
                    BattleTag = player.BattleTag,
                    Location = player.Location,
                    Rank = rankhistory.CompetitiveRank
                }).ToList();

            foreach(var item in query)
            {
                if (item.Rank == null)
                    item.Rank = 0;
            }

            var model = query.OrderByDescending(o => o.Rank).ToList();

            return View(model);
        }


        /// <summary>
        /// Loop through all Players in the database to retrieve the competitive rank. 
        /// Uses Overwatch.NET to scrape the information from the overwatch website.
        /// Updates the database once it is done.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetPlayerRanksAsync()
        {
            foreach (var player in db.Players.ToList())
            {
                // Get an Overwatch player object from Overwatch.NET
                var op = await GetOverwatchPlayer(player);

                // Create a new RankHistory row object to be added to dbo.RankHistory
                var rh = new RankHistory();
                rh.CompetitiveRank = short.Parse(op.CompetitiveRank.ToString());
                rh.Tier = Tier.Bronze; //TODO: Assign correct tier based on the result
                rh.Timestamp = DateTime.Now.AddHours(10);

                // Add the RankHistory row 
                player.RankHistory.Add(rh);

                // Update the database
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Use Overwatch.NET to retrieve an OverwatchPlayer object.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public async Task<OverwatchPlayer> GetOverwatchPlayer(Player player)
        {
            var op = new OverwatchPlayer(player.BattleTag, Platform.pc, Region.us);
            await op.UpdateStats();
            return op;
        }
    }
}