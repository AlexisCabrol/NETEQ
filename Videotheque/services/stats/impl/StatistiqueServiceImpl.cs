using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.stats.impl
{
    class StatistiqueServiceImpl : StatistiquesService
    {
        public async Task<Dictionary<string, int>> FilmPerGenre()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();

            List<Genre> listg = context.Genre.ToList();
            List<MediaGenre> listmg = context.MediaGenre.ToList();
            var stat = from u in listmg
                       group u by u.Genre.Name into grp
                       select new
                       {
                           Genre = grp.Key,
                           Count = grp.Count(),
                       };
            return stat.ToDictionary(p => p.Genre, p => p.Count);
        }
    }
}