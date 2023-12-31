﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace Libreria_SAEG.Data.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRaed { get; set; }
        public string Rate { get; set; }
        public string Genero { get; set; }
        public string ConverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
    }
}
