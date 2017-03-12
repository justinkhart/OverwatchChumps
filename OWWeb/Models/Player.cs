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
        Bronze, Silver, Gold, Platinum, Diamond, Master, Grandmaster
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
    }
}