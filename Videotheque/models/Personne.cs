﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models.enums;

namespace Videotheque.models
{
    public class Personne : AbstractModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public byte[] PhotoProfil
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }
    }
}