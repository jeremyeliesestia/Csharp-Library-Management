using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book() { Authors = "AUTEUR 1", Contenu = " CONTENU 1", Genre = new List<Genre>() {  }, Nom = "NOM 1", Prix = 12},
            new Book() { Authors = "AUTEUR 2", Contenu = " CONTENU 2", Genre = new List<Genre>() {  }, Nom = "NOM 2", Prix = 16 },
            new Book() { Authors = "AUTEUR 3", Contenu = " CONTENU 3", Genre = new List<Genre>() {  }, Nom = "NOM 3", Prix = 20 },
            new Book() { Authors = "AUTEUR 4", Contenu = " CONTENU 4", Genre = new List<Genre>() {  }, Nom = "NOM 4", Prix = 57 }
        
        };


        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
    }
}