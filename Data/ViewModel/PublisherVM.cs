﻿using Libreria_SAEG.Data.Models;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Libreria_SAEG.Data.ViewModel
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }
    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
