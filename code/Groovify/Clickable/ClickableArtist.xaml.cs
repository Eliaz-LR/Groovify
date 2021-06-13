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
using Modele;

namespace Groovify
{
    /// <summary>
    /// Logique d'interaction pour ClickableArtist.xaml
    /// </summary>
    public partial class ClickableArtist : UserControl
    {
        Artiste artiste1 = new Artiste();
        public ClickableArtist(Artiste artiste)
        {
            InitializeComponent();
            DataContext = artiste;
            artiste1 = artiste;
        }

        private void ArtistClicked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailArtiste(artiste1);
        }
    }
}
