using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.config;
using Videotheque.models;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddFilmPageViewModel : AbstractModel
    {
        public AddFilmPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
        }

        public MainViewModel SuperViewModel
        {
            get { return GetValue<MainViewModel>(); }
            set { SetValue<MainViewModel>(value); }
        }

        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public string Commentaire { get; set; }
        public string AgeMin { get; set; }
        public string Duree { get; set; }
        public string Note { get; set; }
        // MANQUE DES INFOS NOTAMENT LES LISTES ET CHECKBOX

        public Command AddFilm
        {
            get
            {
                saveFilmAsync();
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<FilmPage, FilmPageViewModel>(SuperViewModel);
                });
            }
        }

        private async Task saveFilmAsync()
        {
            var context = await databaseAccess.DatabaseContext.GetCurrent();
            context.Add(new Film()
            {
                Titre = this.Titre,
                Synopsis = this.Synopsis,
                Commentaire = this.Commentaire,
                AgeMin = Convert.ToInt32(this.AgeMin),
                Duree = TimeSpan.Parse(this.Duree),
                Note = Convert.ToInt32(this.Note)
            });
            await context.SaveChangesAsync();
        }
    }
}
