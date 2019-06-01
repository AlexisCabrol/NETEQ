using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.film
{
    interface FilmService
    {
        Task<ObservableCollection<Film>> SelectAllFilmAsync();
        Task AddFilm(Film film);
        Task DeleteFilm(Film film);
        Task<Film> SelectOneFilm(Film film);
        Task<ObservableCollection<Film>> SelectFilmFilter(string text);
        Task UpdateFilm(Film film);
    }
}
