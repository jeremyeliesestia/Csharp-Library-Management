using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{


    public class CreateGenreModel
    {
        [Required]
        [Display(Name = "Genre")]
        public string Nom { get; set; }

        public List<Book> Book { get; set; }


    }


    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Genre> ListGenres = libraryDbContext.Genre.ToList();
            return View(ListGenres);
        }

        // A vous de faire comme BookController.List mais pour les genres !
    }
}
