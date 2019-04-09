using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    public class Film : Media
    {
        public TimeSpan Duree
        {
            get { return GetValue<TimeSpan>(); }
            set { SetValue(value); }
        }
    }
}
