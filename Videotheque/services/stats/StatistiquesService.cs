using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.services.stats
{
    interface StatistiquesService
    {
        Task<Dictionary<string, int>> FilmPerGenre();
        Task<int> FilmInDatabase();
        Task<Dictionary<string, int>> FilmStatut();
    }
}
