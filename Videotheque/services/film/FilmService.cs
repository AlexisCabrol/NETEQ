using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.film
{
    interface FilmService
    {
        Task<List<Film>> selectAllFilmAsync();
        Task AddFilm(Film film);
        Task DeleteFilm(Film film);
    }
}
