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
    /// Logique d'interaction pour VueAlbum.xaml
    /// </summary>
    public partial class VueAlbum : UserControl
    {
        public VueAlbum(List<Album> albums)
        {
            InitializeComponent();
            List<ClickableAlbum> clickableAlbums = new List<ClickableAlbum>();
            foreach (Album album in albums)
            {
                ClickableAlbum clickableAlbum = new ClickableAlbum(album);
                clickableAlbums.Add(clickableAlbum);
            }
            ListeAlbumsClickables.ItemsSource = clickableAlbums;
        }
    }
}
