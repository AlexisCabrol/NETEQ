using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.databaseAccess;
using Videotheque.utils;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string fpath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "database.db");
            if(System.IO.File.Exists(fpath))
            {
                System.IO.File.Delete(fpath);
            }

            var context = await DatabaseContext.GetCurrent();
            await context.Film.AddRangeAsync(GenerateDataUtils.InitFilms());
            await context.Personne.AddRangeAsync(GenerateDataUtils.InitPersonnes());
            await context.Genre.AddRangeAsync(GenerateDataUtils.InitGenre());
            await context.MediaGenre.AddRangeAsync(GenerateDataUtils.InitMediaGenre());
            await context.MediaPersonne.AddRangeAsync(GenerateDataUtils.InitMediaPersonne());
            await context.SaveChangesAsync();
        }
    }
}
