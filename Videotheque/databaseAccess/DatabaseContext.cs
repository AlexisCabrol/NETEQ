using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.databaseAccess
{
    public class DatabaseContext : DbContext
    {
        private static DatabaseContext _context = null;
        public async static Task<DatabaseContext> GetCurrent()
        {
            if(_context == null)
            {
                _context = new DatabaseContext(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }
            
        internal DatabaseContext(DbContextOptions options): base(options) { }
        private DatabaseContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public string DatabasePath { get; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<MediaGenre> MediaGenre { get; set; }
        public DbSet<MediaPersonne> MediaPersonne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MediaGenre>().HasKey(mediaGenre => new { mediaGenre.GenreId, mediaGenre.MediaId });
            modelBuilder.Entity<MediaPersonne>().HasKey(mediaPersonne => new { mediaPersonne.PersonneId, mediaPersonne.MediaId });
        }
    }
}
