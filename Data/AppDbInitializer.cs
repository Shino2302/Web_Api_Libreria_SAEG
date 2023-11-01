using Libreria_SAEG.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Libreria_SAEG.Data
{
    public class AppDbInitializer
    {
        //Método que agrega datos a nuestra DB
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1st Book Title",
                        Descripcion = "1st Book Description",
                        IsRead = true,
                        DateRaed = System.DateTime.Now.AddDays(-10),
                        Rate = "4",
                        Genero = "Biography",
                        Autor = "1st Author",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Titulo = "2nd Book Title",
                        Descripcion = "2nd Book Description",
                        IsRead = false,
                        Rate = "4",
                        Genero = "Biography",
                        Autor = "2nd Author",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
