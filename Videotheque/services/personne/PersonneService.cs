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
        // Service for entity
        Task AddPersonne(Personne p);
        Task DeletePersonne(Personne p);

        // Service for friend management
        Task UpdateFriend(Personne p);
        Task<ObservableCollection<Personne>> SelectAllFriend();
        Task<ObservableCollection<Personne>> SelectFriendFilter(string text);

        // Service for author management
        Task<ObservableCollection<Personne>> SelectAllCollab();
        Task<ObservableCollection<Personne>> SelectCollabFilter(string text);
        Task<ObservableCollection<MediaPersonne>> SelectAllFilmForOneCollab(int id);
        Task DeleteMediaPersonne(MediaPersonne p);
        Task DeleteCollbaborateurs(Personne p, ObservableCollection<MediaPersonne> collab);
        Task AddCollab(MediaPersonne p);
    }
}
