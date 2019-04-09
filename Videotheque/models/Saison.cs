using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    public class Saison : Media
    {
        public int Duree
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public int NbSaison
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [InverseProperty(nameof(Episode.Saison))]
        public List<Episode> Episodes
        {
            get { return GetValue<List<Episode>>(); }
            set { SetValue(value); }
        }
    }
}
