using System;
using System.Collections.Generic;
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
    }
}
