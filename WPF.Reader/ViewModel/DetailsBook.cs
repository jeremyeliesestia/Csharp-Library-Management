using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class DetailsBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; init; } = new RelayCommand(x => { /* A vous de définir la commande */ });
        public ICommand GoToText { get; set; }

        // n'oublier pas faire de faire le binding dans DetailsBook.xaml !!!!
        public BookWrapper CurrentBook { get; init; }

        public DetailsBook(BookWrapper book)
        {
            CurrentBook = book;
            GoToText = new RelayCommand(book =>
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(CurrentBook);
            });
        }

        public Book selectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                //Ioc.Default.GetRequiredService<LibraryService>().DisplayBookDetails(selectedBook);
            }
        }
    }











    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    public class InDesignDetailsBook : DetailsBook
    {
        public InDesignDetailsBook() : base(new BookWrapper() /*{ Title = "Test Book" }*/) { }
    }
}
