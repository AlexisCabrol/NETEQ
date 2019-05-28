using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private FilmService filmService = new FilmServiceImpl();
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public string Commentaire { get; set; }
        public string AgeMin { get; set; }
        public string Duree { get; set; }
        public string Note { get; set; }
        public Boolean AudioDescription { get; set; }
        public Boolean SupportPhysique { get; set; }
        public Boolean SupportNumerique { get; set; }

        public List<ComboboxUtils> ListVO { get; set; }
        public List<ComboboxUtils> ListME { get; set; }
        public List<ComboboxUtils> ListStatut { get; set; }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public Pays VOEnum
        {
            get { return GetValue<Pays>(); }
            set { SetValue<Pays>(value); }
        }

        public Pays MEEnum
        {
            get { return GetValue<Pays>(); }
            set { SetValue<Pays>(value); }
        }

        public Statut StatutEnum
        {
            get { return GetValue<Statut>(); }
            set { SetValue<Statut>(value); }
        }

        public AddFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            ListVO = ComboboxUtils.init(new Pays());
            ListME = ComboboxUtils.init(new Pays());
            ListStatut = ComboboxUtils.init(new Statut());
        }



        public Command ValidateFilm
        {
            get
            {
                return new Command(async () =>
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
                });
            }
        }
    }
}
