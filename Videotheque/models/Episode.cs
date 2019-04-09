﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    public class Episode : AbstractModel
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

        public int SaisonId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [ForeignKey(nameof(SaisonId))]
        public Saison Saison
        {
            get { return GetValue<Saison>(); }
            set { SetValue(value); }
        }
    }
}
