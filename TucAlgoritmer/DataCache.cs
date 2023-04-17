using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TucAlgoritmer
{
    public class DataCache<T>
    {
        private readonly int _cacheMinutes;

        public DataCache(int cacheMinutes = 10)
        {
            _cacheMinutes = cacheMinutes;
        }
        private List<T> players = null;
        private DateTime LastFetched = DateTime.MinValue;
        public List<T> GetPlayers(Func<List<T>> readPlayers)
        {
            if (players == null || (DateTime.Now- LastFetched).TotalMinutes > _cacheMinutes)
            {
                players = readPlayers();
                LastFetched = DateTime.Now;
            }

            return players;
        }

        //private List<App.HockeyPlayer> ReadPlayers()
        //{
        //    var l = new List<App.HockeyPlayer>();
        //    System.Threading.Thread.Sleep(3000);
        //    l.Add(new App.HockeyPlayer());
        //    l.Add(new App.HockeyPlayer());
        //    l.Add(new App.HockeyPlayer());
        //    l.Add(new App.HockeyPlayer());
        //    l.Add(new App.HockeyPlayer());
        //    return l;
        //}
    }
}
