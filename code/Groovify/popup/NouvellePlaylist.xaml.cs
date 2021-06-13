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
using System.Windows.Shapes;
using Modele;

namespace Groovify.popup
{
    /// <summary>
    /// Logique d'interaction pour NouvellePlaylist.xaml
    /// </summary>
    public partial class NouvellePlaylist : Window
    {
        public Manager ElManager => (App.Current as App).managerTest;
        private string str;
        public NouvellePlaylist()
        {
            InitializeComponent();
        }
        private void ValiderNouvellePlaylist(object sender, RoutedEventArgs e)
        {
            str = NomPlaylist.Text;
            Playlist newplaylist = new Playlist { Name = str };
            ElManager.AjoutePlaylist(newplaylist);
            Debug.WriteLine("nouvelle playlist "+str+" ajoutée");
            ElManager.Persistance.SauvegardeDonnee(ElManager.ListePlaylists);
            this.Close();
        }
        private void AnnulerNouvellePlaylist(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
