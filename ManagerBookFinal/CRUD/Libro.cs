using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;
using ManagerBookFinal.Module.Database;

namespace ManagerBookFinal.CRUD
{
    public class Libro: IDisposable, ICrud<Model.Libro>
    {
        private readonly Context Context = new();
        public Model.Libro Create(Model.Libro libro)
        {
            return Context.Libros.Add(libro).Entity;
        }

        public void Delete(Model.Libro libro)
        {
            Model.Libro fLibro = Context.Libros.Single(lb => lb.ID == libro.ID);
            Context.Remove(fLibro);
        }

        public List<Model.Libro> Read()
        {
            return Context.Libros.ToList();
        }

        public List<Model.Libro> Read(int limit)
        {
            return Context.Libros.Take(limit).ToList();
        }

        public List<Model.Libro> Read(Range range)
        {
            int start = range.Start.Value;
            int end = range.End.Value;

            int limit = end - start + 1;

            return Context.Libros.Skip(start).Take(limit).ToList();
        }

        public void Update(Model.Libro currentBook, Model.Libro newBook)
        {
            Model.Libro libro = Context.Libros.Find(currentBook.ID);
            libro.ImageLocation = newBook.ImageLocation;
            libro.LastDate = newBook.LastDate;
            libro.LastReadingDate = newBook.LastReadingDate;
            libro.Pages = newBook.Pages;
            libro.PagesCompl = newBook.PagesCompl;
            libro.Time = newBook.Time;
            libro.Title = newBook.Title;
            libro.Chapters = newBook.Chapters;
            libro.ChaptersCompl = newBook.ChaptersCompl;
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
