using Libreria_SAEG.Controllers;
using System;
using System.Collections.Generic;

namespace Libreria_SAEG.Data.ViewModel
{
    public class BookVM
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRaed { get; set; }
        public string Rate { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string ConverUrl { get; set; }
        public int PublisherID { get; set; }
        public List<int> AuthorIDs { get; set; }
    }
    public class BookWithAuthorsVM
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRaed { get; set; }
        public string Rate { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string ConverUrl { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
