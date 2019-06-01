using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.personne
{
    interface PersonneService
    {
        // Service for friend management
        Task AddFriend(Personne p);
        Task DeleteFriend(Personne p);
        Task<ObservableCollection<Personne>> SelectAllFriend();
        Task<ObservableCollection<Personne>> SelectFriendFilter(string text);

        // Service for author management
        Task<ObservableCollection<Personne>> SelectAllAuthor();
        Task<ObservableCollection<Personne>> SelectAuthorFilter(string text);
        Task DeleteMediaPersonne(MediaPersonne p);
    }
}
