using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TucAlgoritmer
{
    public static class ListExtensions
    {
        public static int CountIsTheBestPlayers(this List<App.HockeyPlayer> players)
        {
            return players.Count(e=>e.IsTheBest());
        }

        public static bool IsFoppa(this App.HockeyPlayer p)
        {
            if (p.Jersey == 21 && p.Name == "Peter Forsberg") return true;
            return false;
        }
    }
}
