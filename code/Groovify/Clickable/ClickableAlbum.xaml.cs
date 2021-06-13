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
    /// Logique d'interaction pour ClickableAlbum.xaml
    /// </summary>
    public partial class ClickableAlbum : UserControl
    {
        Album album;
        public ClickableAlbum(Album album)
        {
            InitializeComponent();
            DataContext = album;
            this.album = album;
        }
        private void AlbumClicked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailAlbum(album);
        }
    }
}
