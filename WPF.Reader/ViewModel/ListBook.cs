using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        private Genre selectedGenre;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!

        public Genre SelectedGenre
        {
            get
            {
                return selectedGenre;
            }
            set
            {
                selectedGenre = value;
                //Ioc.Default.GetRequiredService<LibraryService>().UpdateBooksByGenre(selectedGenre);
            }
        }
        
        public int NFisrtBooks
        {
            get
            {
                return NFisrtBooks;
            }
            set
            {
                NFisrtBooks = value;
                //Ioc.Default.GetRequiredService<LibraryService>().DisplayNFirstBooks(NFisrtBooks);
            }
        }


        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => { /* the livre devrais etre dans la variable book */ });
        }


    }
}
