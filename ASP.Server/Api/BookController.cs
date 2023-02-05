using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public class BookWrapper
        {
            public Book BW { private get;  init; }
            public int Id { get { return BW.Id; } }
            public string Nom { get { return BW.Nom; } }
            public string Authors { get { return BW.Authors; } }
            public double Prix { get { return BW.Prix; } }
            public List<Genre> Genre { get { return BW.Genre; } }
        }


        public ActionResult<List<BookWrapper>> GetBooks([FromQuery] List<int> Id_Genre = null, int offset = 0, int limit = 10)
        {


            IQueryable<Book> bookQuery = libraryDbContext.Books.Skip(offset).Take(limit).Include(Book => Book.Genre);

            if (Id_Genre != null && Id_Genre.Any())
            {
                bookQuery = bookQuery.Where(Books => Books.Genre.Intersect(libraryDbContext.Genre.Where(Genre => Id_Genre.Contains(Genre.Id))).Any());
            }


            return bookQuery.Select(book => new BookWrapper() {BW=book}).ToList();

        }

        public ActionResult<Book> GetBook(int numero_livre)
        {
            var book = libraryDbContext.Books.Include(Book => Book.Genre).FirstOrDefault(Book => Book.Id == numero_livre);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound(new { message = "Le livre demandé est introuvable" });
            }

        }

        public ActionResult<List<Genre>> GetGenres()
        {
            var genres = libraryDbContext.Genre.ToList();

            if (genres != null)
            {
                return Ok(genres);
            }
            else
            {
                return NotFound(new { message = "La liste de genres n'existe pas" });
            }
        }

        public ActionResult<Genre> GetGenre(int numero_genre)
        {
            var genre = libraryDbContext.Genre.FirstOrDefault(Genre => Genre.Id == numero_genre);

            if (genre != null)
            {
                return Ok(genre);
            }
            else
            {
                return NotFound(new { message = "Le genre demandé est introuvable" });
            }

        }

    }
}

