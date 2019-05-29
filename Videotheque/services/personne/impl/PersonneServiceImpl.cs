using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
            return new ObservableCollection<Personne> ( context.MediaPersonne
                .Where(b => b.Fonction == models.enums.Fonction.Acteur)
                .Select(b => b.Personne)
                .ToList<Personne>());
        }

        public async Task DeleteAuthor(Personne author)
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            MediaPersonne mp = await SelectOneAuthorByPersonneId(author.Id);
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
    }
}
