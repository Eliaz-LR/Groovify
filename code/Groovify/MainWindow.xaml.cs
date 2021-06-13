using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Manager ElManager => (App.Current as App).managerTest;
        private MusicPlayer musicPlayer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ElManager;
            VuePrincipale.Content = new Vues.VueTitres(ElManager.ListeToutesMusiques);
            musicPlayer = new MusicPlayer(ElManager.ListeToutesMusiques[0]);
            MusicPlayer.Content = musicPlayer;
        }

        private void ChangeVueToVueTitres(object sender, RoutedEventArgs e)
        {
            VuePrincipale.Content = new Vues.VueTitres(ElManager.ListeToutesMusiques);
        }
        private void ChangeVueToVueAlbum(object sender, RoutedEventArgs e)
        {
            List<Album> ListAllAlbums = new List<Album>();
            foreach(Artiste artiste in ElManager.ListeArtiste)
            {
                ListAllAlbums.AddRange(artiste.ListeAlbum);
            }
            VuePrincipale.Content = new Vues.VueAlbum(ListAllAlbums);
        }
        private void ChangeVueToVueArtiste(object sender, RoutedEventArgs e)
        {
            VuePrincipale.Content = new Vues.VueArtiste(ElManager.ListeArtiste);
        }

        public void ChangeVueToVueDetailArtiste(Artiste artiste)
        {
            VuePrincipale.Content = new Vues.VueDetailArtiste(artiste);
        }
        public void ChangeVueToVueDetailAlbum(Album album)
        {
            VuePrincipale.Content = new Vues.VueDetailAlbum(album);
        }
        public void ChangeVueToVueDetailPlaylist(List<Musique> playlist)
        {
            VuePrincipale.Content = new Vues.VueTitres(playlist);
        }
        public void ChangeTitlePlayed(Musique musique)
        {
            if(musicPlayer.musiquePlaying)
            { musicPlayer.Play_Pause(); }
            musicPlayer = new MusicPlayer(musique);
            MusicPlayer.Content = musicPlayer;
            musicPlayer.Play_Pause();
        }

        private void NewPlaylist(object sender, RoutedEventArgs e)
        {
            popup.NouvellePlaylist newPlaylist = new popup.NouvellePlaylist();
            newPlaylist.Show();
            foreach (Playlist playlist in ElManager.ListePlaylists)
            {
                Debug.WriteLine("playlists existante : " + playlist);
            }
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListePlaylists.SelectedIndex == -1) return;

            int element = ListePlaylists.SelectedIndex;
            ElManager.SupprimerPlaylist(ElManager.ListePlaylists[element]);
            ElManager.Persistance.SauvegardeDonnee(ElManager.ListePlaylists);
        }
        private void MenuPlaylistVoir(object sender, RoutedEventArgs e)
        {
            Button playlistToSee = (Button)sender;
            Debug.WriteLine(playlistToSee.DataContext);
            Playlist playlist = ElManager.recherchePlaylist(playlistToSee.DataContext.ToString());
            ChangeVueToVueDetailPlaylist(playlist.musiquePlaylist);
        }

        private void MetroWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridMenu.Focus();
        }
    }
}
