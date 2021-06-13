using System;
using System.Collections.Generic;
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


namespace Groovify.Vues
{
    /// <summary>
    /// Logique d'interaction pour VueTitres.xaml
    /// </summary>
    public partial class VueTitres : UserControl
    {
        public Manager ElManager => (App.Current as App).managerTest;
        private List<Musique> titres = new List<Musique>();
        public VueTitres(List<Musique> titres)
        {
            InitializeComponent();
            DataContext = ElManager;
            ListViewSons.ItemsSource = titres;
            this.titres = titres;
        }

        private void AddSongToPlaylist(object sender, RoutedEventArgs e)
        {
            if (ListViewSons.SelectedIndex == -1) return;

            var clickedMenuItem = e.OriginalSource as MenuItem;
            int musique = ListViewSons.SelectedIndex;
            //int playlist = MenuItemClickDroitSons.Items.IndexOf(clickedMenuItem.Items) ;
            Debug.WriteLine("chanson cliquée : "+ musique);
            Debug.WriteLine(clickedMenuItem.Header);
            Playlist playlist = ElManager.recherchePlaylist(clickedMenuItem.Header.ToString());
            playlist.addMusic(titres[musique]);
            ElManager.Persistance.SauvegardeDonnee(ElManager.ListePlaylists);
        }
        
        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Musique titre_doubleclické = ((ListViewItem)sender).Content as Musique;
            ((MainWindow)Application.Current.MainWindow).ChangeTitlePlayed(titre_doubleclické);
        }
        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gridView = listView.View as GridView;

            var width = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; //utilisé pour obtenir la largeur de la ListView

            var column1 = 0.34;
            var column2 = 0.34;
            var column3 = 0.34; //il faut arrondir au superieur pour pouvoir remplir toute la largeur

            gridView.Columns[0].Width = width * column1;
            gridView.Columns[1].Width = width * column2;
            gridView.Columns[2].Width = width * column3;
        }


    }
}
