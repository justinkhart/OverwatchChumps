using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OWWeb.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; } //Primary Key
        public string Name { get; set; }
        public string BattleTag { get; set; }
        public string Location { get; set; }
        public virtual ICollection<RankHistory> RankHistory { get; set; }

    }

    public enum Tier
    {
        Unranked, Bronze, Silver, Gold, Platinum, Diamond, Master, Grandmaster
    }

    public class RankHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RankHistoryID { get; set; } //Primary Key
        public short? CompetitiveRank { get; set; }
        public DateTime Timestamp { get; set; }
        public Tier? Tier { get; set; }

        public int PlayerID { get; set; } // Foreign Key
        public virtual Player Player { get; set; }

        public RankHistory(short? competitiveRank, DateTime timestamp)
        {
            CompetitiveRank = competitiveRank;
            Timestamp = timestamp;
            Tier = GetTier(CompetitiveRank);
        }

        public RankHistory() {}

        /// <summary>
        /// Calculates the Tier from the given competitiveRank, returns Unranked if Player has not finished placement matches for this season. 
        /// </summary>
        /// <param name="competitiveRank"></param>
        /// <returns></returns>
        private Models.Tier GetTier(short? competitiveRank)
        {
            if (competitiveRank == null || competitiveRank == 0)
                return Models.Tier.Unranked;
            else if (competitiveRank >= 4000)
                return Models.Tier.Grandmaster;
            else if (competitiveRank >= 3500)
                return Models.Tier.Master;
            else if (competitiveRank >= 3000)
                return Models.Tier.Diamond;
            else if (competitiveRank >= 2500)
                return Models.Tier.Platinum;
            else if (competitiveRank >= 2000)
                return Models.Tier.Gold;
            else if (competitiveRank >= 1500)
                return Models.Tier.Silver;
            else
                return Models.Tier.Bronze; // you are bad
        }
    }
}