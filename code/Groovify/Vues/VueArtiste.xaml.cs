using Modele;
using System;
using System.Collections.Generic;
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

namespace Groovify.Vues
{
    /// <summary>
    /// Logique d'interaction pour VueArtiste.xaml
    /// </summary>
    public partial class VueArtiste : UserControl
    {
        public Manager ElManager => (App.Current as App).managerTest;
        
        public VueArtiste(List<Artiste> AllArtists)
        {
            InitializeComponent();
            List<ClickableArtist> clickableArtists = new List<ClickableArtist>();
            foreach (Artiste artiste in AllArtists)
            {
                ClickableArtist clickableArtist =new ClickableArtist(artiste);
                clickableArtists.Add(clickableArtist);
            }
            ListeArtistesClickable.ItemsSource = clickableArtists;
        }
    }
}
