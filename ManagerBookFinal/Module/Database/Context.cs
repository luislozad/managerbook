using ManagerBookFinal.Interface;
using ManagerBookFinal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module.Database
{
    public class Context: DbContext
    {
        private const string FILE_NAME = "database.db";
        
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<TemporadaLectura> TemporadaLecturas { get; set; }
        public DbSet<Lecturas> Lecturas { get; set; }
        public DbSet<NotaLectura> NotaLecturas { get; set; }

        public DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: $"Filename={FILE_NAME}", sqliteOptionsAction: HandleOptionsAction);

            base.OnConfiguring(optionsBuilder);
        }

        private void HandleOptionsAction(SqliteDbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        }
    }
}
