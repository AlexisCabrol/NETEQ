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

        public async Task<int> FilmInDatabase()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return context.Film.Count();
        }

        public async Task<Dictionary<string, int>> FilmStatut()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();

            List<Film> listf = context.Film.ToList();
            var stat = from u in listf
                       group u by u.Statut into grp
                       select new
                       {
                           Statut = grp.Key.ToString(),
                           Count = grp.Count(),
                       };
            return stat.ToDictionary(p => p.Statut, p => p.Count);
        }



    }
}