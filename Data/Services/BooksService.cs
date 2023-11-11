using Libreria_SAEG.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Libreria_SAEG.Data.ViewModel;

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

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRaed = book.DateRaed,
                Rate = book.Rate,
                Genero = book.Genero,
                ConverUrl = book.ConverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }

        }

        public List<Book> GetAllBks() => _context.Books.ToList();

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRaed = book.DateRaed,
                Rate = book.Rate,
                Genero = book.Genero,
                ConverUrl = book.ConverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }

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
                _book.ConverUrl = book.ConverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBookByID(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookId);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
