using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TucAlgoritmer
{
    public class DataCache
    {
        private List<App.HockeyPlayer> players = null;
        public List<App.HockeyPlayer> GetPlayers()
        {
            if (players == null)
            {
                players = ReadPlayers();
            }

            return players;
        }

        private List<App.HockeyPlayer> ReadPlayers()
        {
            var l = new List<App.HockeyPlayer>();
            System.Threading.Thread.Sleep(3000);
            l.Add(new App.HockeyPlayer());
            l.Add(new App.HockeyPlayer());
            l.Add(new App.HockeyPlayer());
            l.Add(new App.HockeyPlayer());
            l.Add(new App.HockeyPlayer());
            return l;
        }
    }
}
