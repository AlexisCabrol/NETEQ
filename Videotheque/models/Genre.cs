using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    class Genre : AbstractModel
    {
        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
