using Libreria_SAEG.Data.Models;
using Libreria_SAEG.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Libreria_SAEG.Data.ViewModel;
using System.Linq;

namespace Libreria_SAEG.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher= new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorsVM GetPublisherWithBooksAndAuthors(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Titulo,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }
    }
}
