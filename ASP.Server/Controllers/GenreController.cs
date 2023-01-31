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

        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre)
        {
            // Le IsValid est True uniquement si tous les champs de CreateGenreModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                //On interroge la liste des genre existant pour pour éviter les doublons
                if (!libraryDbContext.Genre.Any(g => g.Nom == genre.Nom))
                {
                    // On complète la création du genre avec son nom qu'on aura ajouté
                    libraryDbContext.Add(new Genre() { Nom = genre.Nom });
                    libraryDbContext.SaveChanges();
                } 
            }
            return View(genre);
        }
    }
}
