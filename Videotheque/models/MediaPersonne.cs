using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models.enums;

namespace Videotheque.models
{
    public class MediaPersonne : AbstractModel
    {
        public int PersonneId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [ForeignKey(nameof(PersonneId))]
        public Personne Personne
        {
            get { return GetValue<Personne>(); }
            set { SetValue(value); }
        }

        public int MediaId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [ForeignKey(nameof(MediaId))]
        public Media Media
        {
            get { return GetValue<Media>(); }
            set { SetValue(value); }
        }

        public Fonction Fonction
        {
            get { return GetValue<Fonction>(); }
            set { SetValue(value); }
        }

        public string Role
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
