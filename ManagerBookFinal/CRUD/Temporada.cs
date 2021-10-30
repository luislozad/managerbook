using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;
using ManagerBookFinal.Module.Database;

namespace ManagerBookFinal.CRUD
{
    public class Temporada : IDisposable, ICrud<Model.Temporada>
    {
        private readonly Context Context = new();
        public Model.Temporada Create(Model.Temporada temporada)
        {
            return Context.Temporadas.Add(temporada).Entity;
        }

        public void Delete(Model.Temporada temporada)
        {
            Model.Temporada fTemporada = Context.Temporadas.Single(temp => temp.ID == temporada.ID);
            Context.Remove(fTemporada);
        }

        public List<Model.Temporada> Read()
        {
            return Context.Temporadas.ToList();
        }

        public List<Model.Temporada> Read(int limit)
        {
            return Context.Temporadas.Take(limit).ToList();
        }

        public List<Model.Temporada> Read(Range range)
        {
            int start = range.Start.Value;
            int end = range.End.Value;

            int limit = end - start + 1;

            return Context.Temporadas.Skip(start).Take(limit).ToList();
        }

        public void Update(Model.Temporada currentTemp, Model.Temporada newTemp)
        {
            Model.Temporada temporada = Context.Temporadas.Find(currentTemp.ID);
            temporada.Title = newTemp.Title;
            temporada.ImageLocation = newTemp.ImageLocation;
            temporada.LastDate = newTemp.LastDate;
            temporada.Books = newTemp.Books;
            temporada.BooksCompl = newTemp.BooksCompl;
            temporada.Pages = newTemp.Pages;
            temporada.PagesCompl = newTemp.PagesCompl;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
