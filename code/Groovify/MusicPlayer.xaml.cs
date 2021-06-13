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

namespace Groovify
{
    /// <summary>
    /// Logique d'interaction pour MusicPlayer.xaml
    /// </summary>
    public partial class MusicPlayer : UserControl
    {
        public WMPLib.WindowsMediaPlayer Player;

        public Manager ElManager => (App.Current as App).managerTest;
        private Musique Musique;
        private Album Album;
        public bool musiquePlaying = false;

        public MusicPlayer(Musique musique)
        {
            InitializeComponent();
            Textes.DataContext = musique;
            Musique = musique;
            Album = ElManager.rechercheAlbum(Musique.NameAlbum, ElManager.rechercheArtiste(Musique.NameArtiste));
            image_musique.DataContext = Album;
            music_player();
        }

        private void Button_Click_Name(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_NameArtiste(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ChangeVueToVueDetailArtiste(ElManager.rechercheArtiste(Musique.NameArtiste));
        }
        private void music_player()
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Debug.WriteLine(Musique.Path);
            Player.URL = Musique.Path;
            Player.controls.stop();
        }
        private void Play_Pause_button(object sender, RoutedEventArgs e)
        { Play_Pause(); }
        public void Play_Pause()
        {
            if (musiquePlaying)
            {
                Player.controls.pause();
                playpause_image.Source = new BitmapImage(new Uri(@"Ressources/Icons/play-100.png", UriKind.Relative));
                musiquePlaying = false;
            }
            else
            {
                Player.controls.play();
                playpause_image.Source = new BitmapImage(new Uri(@"Ressources/Icons/pause-96.png", UriKind.Relative));
                musiquePlaying = true;
            }
        }

        private void Button_Click_next(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ChangeTitlePlayed(Musique);
        }
    }
}
