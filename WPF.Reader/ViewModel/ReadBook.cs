using System.ComponentModel;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { get; init; }

        public ReadBook(Book book)
        {
            CurrentBook = book;
        }

        public ReadBook()
        {
        }


        // A vous de jouer maintenant
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base()
        {
        }
    }
}
