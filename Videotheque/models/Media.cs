using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models.enums;

namespace Videotheque.models
{
    public class Media : AbstractModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Titre
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime DateCreation
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public int Note
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Commentaire
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Synopsis
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int AgeMin
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public Boolean Audiodescription
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public Boolean SupportPhysique
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public Boolean SupportNumerique
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public Pays LangueVO
        {
            get { return GetValue<Pays>(); }
            set { SetValue(value); }
        }

        public Pays LangueMedia
        {
            get { return GetValue<Pays>(); }
            set { SetValue(value); }
        }

        public Statut Statut
        {
            get { return GetValue<Statut>(); }
            set { SetValue(value); }
        }

        public byte[] Affiche
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }
    }
}
