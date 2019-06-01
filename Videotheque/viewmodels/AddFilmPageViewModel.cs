using System;
using System.Collections.Generic;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.services.film;
using Videotheque.services.film.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddFilmPageViewModel : AbstractModel
    {
        private readonly FilmService filmService = new FilmServiceImpl();
        private Boolean UpdateMode = false;
        public string Titre { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public string Synopsis { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public string Commentaire { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public string AgeMin { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public string Duree { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public string Note { get { return GetValue<string>(); } set { SetValue<string>(value); } }
        public Boolean AudioDescription { get { return GetValue<Boolean>(); } set { SetValue<Boolean>(value); } }
        public Boolean SupportPhysique { get { return GetValue<Boolean>(); } set { SetValue<Boolean>(value); } }
        public Boolean SupportNumerique { get { return GetValue<Boolean>(); } set { SetValue<Boolean>(value); } }
        public List<ComboboxUtils> ListVO { get; set; }
        public List<ComboboxUtils> ListME { get; set; }
        public List<ComboboxUtils> ListStatut { get; set; }
        public Pays VOEnum { get { return GetValue<Pays>(); } set { SetValue<Pays>(value); } }
        public Pays MEEnum { get { return GetValue<Pays>(); } set { SetValue<Pays>(value); } }
        public Statut StatutEnum { get { return GetValue<Statut>(); } set { SetValue<Statut>(value); } }
        public Film Film { get { return GetValue<Film>(); } set { SetValue<Film>(value); } }

        public AddFilmPageViewModel(MainViewModel mvm, Film film)
        {
            SuperViewModel = mvm;
            ListVO = ComboboxUtils.init(new Pays());
            ListME = ComboboxUtils.init(new Pays());
            ListStatut = ComboboxUtils.init(new Statut());

            if (film != null)
            {
                UpdateMode = true;
                Titre = film.Titre;
                Synopsis = film.Synopsis;
                Commentaire = film.Commentaire;
                AgeMin = Convert.ToString(film.AgeMin);
                VOEnum = film.LangueVO;
                MEEnum = film.LangueMedia;
                StatutEnum = film.Statut;
                AudioDescription = film.Audiodescription;
                SupportNumerique = film.SupportNumerique;
                SupportPhysique = film.SupportPhysique;
            }
        }

        public Command ValidateFilm
        {
            get
            {
                return new Command(async () =>
                {
                    if (UpdateMode)
                    {

                    }
                    else
                    {
                        await filmService.AddFilm(new Film()
                        {
                            Titre = this.Titre,
                            Synopsis = this.Synopsis,
                            Commentaire = this.Commentaire,
                            AgeMin = Convert.ToInt32(this.AgeMin),
                            //Duree = TimeSpan.Parse(this.Duree),
                            //Note = Convert.ToInt32(this.Note),
                            LangueVO = this.VOEnum,
                            LangueMedia = this.MEEnum,
                            Statut = this.StatutEnum,
                            Audiodescription = this.AudioDescription,
                            SupportNumerique = this.SupportNumerique,
                            SupportPhysique = this.SupportPhysique
                        });
                        SuperViewModel.Source = NavigationCache.GetPage<FilmPage, FilmPageViewModel>(SuperViewModel);
                    }
                });
            }
        }
    }
}
