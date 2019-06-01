using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<ObservableCollection<Film>> SelectAllFilmAsync()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<Film>( context.Film.ToList<Film>() );
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

        public async Task<ObservableCollection<Film>> SelectFilmFilter(string text)
        {
            ObservableCollection<Film> list = await SelectAllFilmAsync();
            return new ObservableCollection<Film>(
                list.Where(film => film.Titre.ToLower().Contains(text.ToLower())).ToList());
        }

        public async Task UpdateFilm(Film film)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Film.Update(film);
            await context.SaveChangesAsync();
        }
    }
}
