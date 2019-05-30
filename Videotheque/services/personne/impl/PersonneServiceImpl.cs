using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.personne.impl
{
    class PersonneServiceImpl : PersonneService
    {
        public async Task AddFriend(Personne p)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Personne.Add(p);
            await context.SaveChangesAsync();
        }

        public async Task<ObservableCollection<Personne>> SelectAllAuthor()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<Personne>(context.MediaPersonne
                .Where(b => b.Fonction == models.enums.Fonction.Acteur)
                .Select(b => b.Personne)
                .ToList<Personne>());
        }

        public async Task DeleteMediaPersonne(MediaPersonne mp)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.MediaPersonne.Remove(mp);
            await context.SaveChangesAsync();
        }

        private async Task<MediaPersonne> SelectOneAuthorByPersonneId(int id)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return context.MediaPersonne.Where(b => b.PersonneId == id).First();
        }

        public async Task<ObservableCollection<Personne>> SelectAuthorFilter(string text)
        {
            ObservableCollection<Personne> list = await SelectAllAuthor();
            return new ObservableCollection<Personne>(
                list.Where(author => author.GetIdentity().ToLower().Contains(text.ToLower())).ToList());
        }

        public async Task<ObservableCollection<MediaPersonne>> SelectAllFilmForOneAuthor(int id)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<MediaPersonne> (context.MediaPersonne
                .Where(b => b.PersonneId == id && b.Fonction == models.enums.Fonction.Acteur)
                .ToList());
        }
    }
}
