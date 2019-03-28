using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    class Saison : Media
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
    }
}
