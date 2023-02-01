using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Pages;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public int CountBooks => Books.Count;

        public ICommand GoToDetail { get; set; }
        public ICommand GoToText { get; set; }
        
        

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => 
            {

            });

            GoToDetail = new RelayCommand(book => 
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book);
            });

            GoToText = new RelayCommand(book =>
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(book);
            });
        }
    }
}
