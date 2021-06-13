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

namespace Groovify.Vues
{
    /// <summary>
    /// Logique d'interaction pour VueDetailAlbum.xaml
    /// </summary>
    public partial class VueDetailAlbum : UserControl
    {
        public VueDetailAlbum(Album album)
        {
            InitializeComponent();
            DataContext = album;
            Titres.Content = new Vues.VueTitres(album.ListeMusique);
        }
    }
}
