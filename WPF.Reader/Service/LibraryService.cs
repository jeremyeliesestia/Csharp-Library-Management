using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Xml.Linq;
using WPF.Reader.Api;
using WPF.Reader.Model;
using WPF.Reader.Pages;
using WPF.Reader.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()

        /*
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>()
        { 
            new Genre() { Id = 0, Nom = "SF"        },
            new Genre() { Id = 1, Nom = "Classic"   },
            new Genre() { Id = 2, Nom = "Romance"   },
            new Genre() { Id = 3, Nom = "Thriller"  },
            new Genre() { Id = 4, Nom = "Horror"    },
            new Genre() { Id = 5, Nom = "Fantastic" },
            new Genre() { Id = 6, Nom = "Fantaisy"  },
            new Genre() { Id = 7, Nom = "Theatre"   }

        };
        */

        public ObservableCollection<BookWrapper> Books { get; set; } = new ObservableCollection<BookWrapper>();

        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>();
        /*
        public LibraryService()
        {
            Books.Add(new BookWrapper() { Id = 1, Authors = "Stephen King",    Nom = "Salem",      Prix = 9.70f,   Contenu = "Salem est un romans effrayant.",         Genre = new List<Genre>() { Genres[0], Genres[4]    } });
            Books.Add(new Book() { Id = 2, Authors = "J.R.R Tolkien",   Nom = "LOTR",       Prix = 27.90f,  Contenu = "Trilogie du seigneur des anneaux",       Genre = new List<Genre>() { Genres[6], Genres[5]    } });
            Books.Add(new Book() { Id = 3, Authors = "EL James",        Nom = "50 S of G",  Prix = 8.20f,   Contenu = "Trilogie des Fifty Shades",              Genre = new List<Genre>() { Genres[2]               } });
            Books.Add(new Book() { Id = 4, Authors = "Corneil",         Nom = "Le Cid",     Prix = 5.00f,   Contenu = "Classic de la littérature francaise",    Genre = new List<Genre>() { Genres[1], Genres[7]    } });
        }
        */
        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 

        public List<BookWrapper> GetAllBooks()
        {
            List<BookWrapper> InvertList = new BookApi().BookGetBooks();
            InvertList.Reverse();
            List<BookWrapper> List = InvertList;

            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                foreach (var x in List)
                {
                    Books.Add(x);
                }

            }));

 
            return List;
        }






        public Book GetBook(BookWrapper bookWrapper)
        {
            Book book = new BookApi().BookGetBook(numeroLivre: bookWrapper.Id); 
            return book;
        }





        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new BookApi().BookGetGenres();
            foreach (var x in genres)
            {
                Genres.Add(x);
            }
            return genres;
        }

        public List<BookWrapper> UpdateBooksByGenre(Genre selectedGenre)
        {
            List<int> genre = new List<int>();
            genre.Add(selectedGenre.Id);
            List<BookWrapper> ListBooks = new BookApi().BookGetBooks(idGenre: genre);
            return ListBooks;
        }

        public void DisplayBookDetails(Book selectedBook)
        {
            new BookApi().BookGetBook(numeroLivre: selectedBook.Id);
        }

        public List<BookWrapper> DisplayNFirstBooks(int N)
        {



            int theoffset = new BookApi().BookGetBooks().Count() - N;
            int thelimit = new BookApi().BookGetBooks().Count();
            List<BookWrapper> InvertList = new BookApi().BookGetBooks(offset: theoffset, limit: N);

            InvertList.Reverse();
            List<BookWrapper> List = InvertList;

            return List;
        }

        public static void Main()
        {
            new LibraryService().Init();
        }
        public void Init()
        {

            List<Genre> genres = GetAllGenres();
            Console.WriteLine("List of all Genres:");
            foreach (Genre genre in Genres)
            {
                Console.WriteLine(genre.Nom);
            }
            Console.WriteLine("End of List");


            List<BookWrapper> books = GetAllBooks();
            Console.WriteLine("List of all Book:");
            foreach (var book in Books)
            {
                Console.WriteLine(book.Nom);
            }
            Console.WriteLine("End of List");

            /*
            List<BookWrapper> Nbooks = LibraryService.DisplayNFirstBooks(3);
            Console.WriteLine("List of 3 first Book:");
            foreach (var book in Nbooks)
            {
                Console.WriteLine(book.Nom);
            }
            Console.WriteLine("End of List");

            
            List<BookWrapper> GenreBooks = LibraryService.UpdateBooksByGenre(new BookApi().BookGetGenre(2));
            Console.WriteLine("List of Book with the genre n°2:");
            foreach (var book in GenreBooks)
            {
                Console.WriteLine(book.Nom);
            }
            Console.WriteLine("End of List");
            */

        }

    }
}
