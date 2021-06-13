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
    /// Logique d'interaction pour VueDetailArtiste.xaml
    /// </summary>
    public partial class VueDetailArtiste : UserControl
    {
        public VueDetailArtiste(Artiste artiste)
        {
            InitializeComponent();
            DataContext = artiste;
            List<Musique> ToutesMusiques = new List<Musique>();
            List<ClickableAlbum> clickableAlbums = new List<ClickableAlbum>();
            foreach(Album album in artiste.ListeAlbum)
            {
                ToutesMusiques.AddRange(album.ListeMusique);

                ClickableAlbum clickableAlbum = new ClickableAlbum(album);
                clickableAlbums.Add(clickableAlbum);
            }
            Albums.ItemsSource = clickableAlbums;
            Titres.Content = new Vues.VueTitres(ToutesMusiques);
        }
    }
}
