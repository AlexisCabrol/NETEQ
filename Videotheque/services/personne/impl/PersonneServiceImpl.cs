using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.personne.impl
{
    class PersonneServiceImpl : PersonneService
    {
        public async Task<ObservableCollection<Personne>> SelectAllCollab()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<Personne>(context.MediaPersonne
                .Select(b => b.Personne)
                .Distinct()
                .ToList<Personne>());
        }

        public async Task<ObservableCollection<MediaPersonne>> SelectAllFilmForOneCollab(int id)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<MediaPersonne>(context.MediaPersonne
                .Where(b => b.PersonneId == id)
                .ToList());
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

        public async Task<ObservableCollection<Personne>> SelectCollabFilter(string text)
        {
            ObservableCollection<Personne> list = await SelectAllCollab();
            return new ObservableCollection<Personne>(
                list.Where(author => author.GetIdentity().ToLower().Contains(text.ToLower())).ToList());
        }

        public async Task DeletePersonne(Personne p)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Personne.Remove(p);
            await context.SaveChangesAsync();
        }

        public async Task<ObservableCollection<Personne>> SelectAllFriend()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            return new ObservableCollection<Personne>(context.Personne
                .Where(b => b.Ami)
                .ToList<Personne>());
        }

        public async Task UpdateFriend(Personne p)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Personne.Update(p);
            await context.SaveChangesAsync();
        }

        public async Task<ObservableCollection<Personne>> SelectFriendFilter(string text)
        {
            ObservableCollection<Personne> list = await SelectAllFriend();
            return new ObservableCollection<Personne>(
                list.Where(p => p.GetIdentity().ToLower().Contains(text.ToLower())).ToList());
        }
        public async Task AddPersonne(Personne p)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Personne.Add(p);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCollbaborateurs(Personne p, ObservableCollection<MediaPersonne> collab)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.MediaPersonne.RemoveRange(collab);
            context.Personne.Remove(p);
            await context.SaveChangesAsync();
        }

        public async Task AddCollab(MediaPersonne p)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.MediaPersonne.Add(p);
            await context.SaveChangesAsync();
        }
    }
}
