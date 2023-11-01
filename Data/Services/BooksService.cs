using Libreria_SAEG.Data.Services.ViewModel;
using Libreria_SAEG.Data.Models;
using System;

namespace Libreria_SAEG.Data.Services
{
    public class BooksService
    {
        //Método para agregar libros a la DB
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRaed = book.DateRaed,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                ConverUrl = book.ConverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
    }
}
