using Libreria_SAEG.Data.Models;
using Libreria_SAEG.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Libreria_SAEG.Data.ViewModel;

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
    }
}
