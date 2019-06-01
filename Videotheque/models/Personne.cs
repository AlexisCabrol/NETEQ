using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Videotheque.models.enums;

namespace Videotheque.models
{
    public class Personne : AbstractModel, IComparable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public Civilite Civilite
        {
            get { return GetValue<Civilite>(); }
            set { SetValue(value); }
        }

        public string Prenom
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Nom
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public Pays Nationalite
        {
            get { return GetValue<Pays>(); }
            set { SetValue(value); }
        }

        public Boolean Ami
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public byte[] PhotoProfil
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Personne otherPersonne = obj as Personne;
            if (otherPersonne != null)
            {
                return this.GetIdentity().CompareTo(otherPersonne.GetIdentity());
            }
            else
            {
                throw new ArgumentException("Object is not a Personne");
            }
        }

        public string GetIdentity()
        {
            return Nom + " " + Prenom;
        }
    }
}
