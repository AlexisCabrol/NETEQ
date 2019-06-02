using System.Collections.Generic;
using System.Collections.ObjectModel;
using Videotheque.config;
using Videotheque.models;
using Videotheque.models.enums;
using Videotheque.services.film;
using Videotheque.services.film.impl;
using Videotheque.services.personne;
using Videotheque.services.personne.impl;
using Videotheque.utils;
using Videotheque.views;

namespace Videotheque.viewmodels
{
    class AddCollabPageViewModel : AbstractModel
    {
        private readonly PersonneService personneService = new PersonneServiceImpl();
        private readonly FilmService filmService = new FilmServiceImpl();
        public MainViewModel SuperViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public MediaPersonne Collab;
        public ObservableCollection<Film> Films { get { return GetValue<ObservableCollection<Film>>(); } set { SetValue<ObservableCollection<Film>>(value); } }
        public List<ComboboxUtils> ListFonction { get; set; }
        public int ValueId { get { return GetValue<int>(); } set { SetValue<int>(value); } }
        public AddCollabPageViewModel(MainViewModel mvm)
        {
            SuperViewModel = mvm;
            ListFonction = ComboboxUtils.init(new Fonction());
        }

        public async void Setup()
        {
            Collab = new MediaPersonne()
            {
                PersonneId = SuperViewModel.MVMAuthor.Id,
                Personne = SuperViewModel.MVMAuthor
            };
            Films = await filmService.SelectAllFilmAsync();
        }

        public Command ValidateCollab
        {
            get
            {
                return new Command(async () =>
                {
                    Collab.MediaId = ValueId;
                    await personneService.AddCollab(Collab);
                    SuperViewModel.Source = NavigationCache.GetPage<ConsultAuthorPage, ConsultAuthorPageViewModel>(SuperViewModel);
                });
            }
        }

        public Command GoBack
        {
            get
            {
                return new Command(() =>
                {
                    SuperViewModel.Source = NavigationCache.GetPage<ConsultAuthorPage, ConsultAuthorPageViewModel>(SuperViewModel);
                });
            }
        }
    }
}
