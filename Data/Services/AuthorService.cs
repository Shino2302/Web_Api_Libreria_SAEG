using Libreria_SAEG.Data.Models;
using Libreria_SAEG.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Libreria_SAEG.Data.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Libreria_SAEG.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }/*
        public List<Author> GetAllAuthors() => _context.Authors.ToList();
        public Author GetAuthorById(int authorId) => _context.Authors.FirstOrDefault(n => n.Id == authorId);
        */
    }
}
