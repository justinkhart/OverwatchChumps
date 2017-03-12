using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWWeb.Models
{
    public class HomeViewModel
    {
        public string Name { get; set; }
        public string BattleTag { get; set; }
        public string Location { get; set; }
        public short? Rank { get; set; }
    }
}