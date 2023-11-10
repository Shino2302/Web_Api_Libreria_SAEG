using Libreria_SAEG.Data.Services.ViewModel;
using Libreria_SAEG.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

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

        public List<Book> GetAllBks() => _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.id == bookId);

        public Book UpdateBookByID(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookId);
            if(_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRaed = book.DateRaed;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.ConverUrl = book.ConverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
    }
}
