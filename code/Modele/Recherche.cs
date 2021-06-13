using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modele
{
    public class Recherche
    {
        public List<Artiste> artistes { get; private set; }
        public List<Album> albums { get; private set; }
        public List<Musique> musiques { get; private set; }
        public List<Playlist> playlists { get; private set; }
        public Recherche(){}
        public void MethodeRecherche(string motRecherché, List<Artiste> artistes, List<Album> albums, List<Musique> musiques, List<Playlist> playlists)
        {
            //voir https://stackoverflow.com/questions/4343336/a-list-of-multiple-data-types, la creation d'une liste contenant des instance est peut etre mieux ?
            //l'ordre de resultats titres - artistes - albums - playlist a été pris sur la façon de presenter les resultats de Spotify
            this.musiques = new List<Musique>(musiques.Where(a => a.Name.Contains(motRecherché)));
            this.artistes = new List<Artiste>(artistes.Where(a => a.Name.Contains(motRecherché)));
            this.albums = new List<Album>(albums.Where(a => a.Name.Contains(motRecherché)));
            this.playlists = new List<Playlist>(playlists.Where(a => a.Name.Contains(motRecherché)));
        }
    }
}
