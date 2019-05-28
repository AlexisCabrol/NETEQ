using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.film.impl
{
    class FilmServiceImpl : FilmService
    {
        public async Task AddFilm(Film film)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Film.Add(film);
            await context.SaveChangesAsync();
        }

        public async Task<List<Film>> SelectAllFilmAsync()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return context.Film.ToList<Film>();
        }

        public async Task DeleteFilm(Film film)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Film.Remove(film);
            await context.SaveChangesAsync();
        }

        public async Task<Film> SelectOneFilm(Film film)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return context.Film.Where(f => f.Id == film.Id).First();
        }
    }
}
