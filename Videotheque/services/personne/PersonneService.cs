using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.services.personne
{
    interface PersonneService
    {
        Task AddFriend(Personne p);
    }
}
