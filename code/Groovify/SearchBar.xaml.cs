using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;

namespace Groovify
{
    /// <summary>
    /// Logique d'interaction pour SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        Recherche recherche = new Recherche();
        public Manager ElManager => (App.Current as App).managerTest;
        List<Album> ListAllAlbums = new List<Album>();
        public SearchBar()
        {
            InitializeComponent();
            foreach (Artiste artiste in ElManager.ListeArtiste)
            {
                ListAllAlbums.AddRange(artiste.ListeAlbum);
            }
        }
        
        private void barreRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            popupResultats.IsOpen = true;
            recherche.MethodeRecherche(barreRecherche.Text, ElManager.ListeArtiste, ListAllAlbums, ElManager.ListeToutesMusiques, new List<Playlist>(ElManager.ListePlaylists));
            ListBoxTitres.ItemsSource = recherche.musiques;
            ListBoxArtistes.ItemsSource = recherche.artistes;
            ListBoxAlbums.ItemsSource = recherche.albums;
            ListBoxPlaylists.ItemsSource = recherche.playlists;
        }

        private void barreRecherche_LostFocus(object sender, RoutedEventArgs e)
        {
            popupResultats.IsOpen = false;
        }


        private void ListBoxTitres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxTitres.SelectedIndex == -1) return;
            //le choix a été fait de plutot afficher l'album du titre plutot que le titre seul sur le modele de Spotify (afficher le titre seul serait facilement fesable en recuperant le titre clické et en le fesant afficher par ChangeVueToVueDetailPlaylist)
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailAlbum(ElManager.rechercheAlbum(recherche.musiques[ListBoxTitres.SelectedIndex].NameAlbum, ElManager.rechercheArtiste(recherche.musiques[ListBoxTitres.SelectedIndex].NameArtiste)));
        }
        private void ListBoxPlaylists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxPlaylists.SelectedIndex == -1) return;
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailPlaylist(recherche.playlists[ListBoxPlaylists.SelectedIndex].musiquePlaylist);
        }

        private void ListBoxAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAlbums.SelectedIndex == -1) return; 
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailAlbum(recherche.albums[ListBoxAlbums.SelectedIndex]);
        }

        private void ListBoxArtistes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxArtistes.SelectedIndex == -1) return;
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailArtiste(recherche.artistes[ListBoxArtistes.SelectedIndex]);
        }
    }
}
