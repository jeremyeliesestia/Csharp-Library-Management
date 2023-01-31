using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Nom { get; set; }

        //---------------------------------------------------
        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        //Louis---------------------------------------------
        
        public String Authors { get; set; }

        //authors du livre ajouté par l'utilisateur
        
        public Double Prix { get; set; }

        //price du livre ajouté par l'utilisateur
       
        public String Description { get; set; }
        //Description du livre ajouté par l'utilisateur
       
        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            //-----------------------
           List<Book> books = libraryDbContext.Books.Include(Book => Book.Genre).ToList();
           return View(books);
            //Louis-----------------------
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = libraryDbContext.Genre.Where(genre => book.Genres.Contains(genre.Id)).ToList();
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book() { Authors = book.Authors, Contenu = book.Description, Nom = book.Nom, Prix=book.Prix , Genre= genres }); ;
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookModel() { AllGenres = libraryDbContext.Genre.ToList() } );
        }

        public ActionResult Delete(int IdDeleted)
        {

            var ToDelete = libraryDbContext.Books.Where(book => book.Id == IdDeleted);
            libraryDbContext.Books.RemoveRange(ToDelete);
            libraryDbContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }


    }
}
