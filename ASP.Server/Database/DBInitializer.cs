using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre(),
                Classic = new Genre(),
                Romance = new Genre(),
                Thriller = new Genre()
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            
            //-------------------------------------------------------------------------
            
            bookDbContext.Books.AddRange(
                new Book() { Authors = "AUTEUR 1", Contenu = " CONTENU 1", Genre = new() { Romance }, Nom = "NOM 1", Prix = 12}, 
                new Book() { Authors = "AUTEUR 2", Contenu = " CONTENU 2", Genre = new() { SF }, Nom = "NOM 2", Prix = 16 },
                new Book() { Authors = "AUTEUR 3", Contenu = " CONTENU 3", Genre = new() { Thriller }, Nom = "NOM 3", Prix = 20 },
                new Book() { Authors = "AUTEUR 4", Contenu = " CONTENU 4", Genre = new() { Classic }, Nom = "NOM 4", Prix = 57 }
            );

            //-------------------------------------------------------------------------

            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}