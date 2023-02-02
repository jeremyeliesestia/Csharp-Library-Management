using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.ComponentModel;
using WPF.Reader.Api;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { get; init; }

        public ReadBook(BookWrapper book)
        {
            CurrentBook = Ioc.Default.GetService<LibraryService>().GetBook(book);
            
        }


        public ReadBook() { 
        
        }

        // A vous de jouer maintenant
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook()
        {
        }
    }
}
