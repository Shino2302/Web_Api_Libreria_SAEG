using System;

namespace Libreria_SAEG.Data.Services.ViewModel
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
    }
}
