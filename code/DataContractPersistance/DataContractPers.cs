using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Modele;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistance
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "JSON");
        public string FileName { get; set; } = "playlists.json";
        public ObservableCollection<Playlist> ChargeDonnee()
        {
            if (!Directory.Exists(FilePath))
            {
                throw new FileNotFoundException("le fichier est manquant");
            }
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Playlist>));
            if (!File.Exists(Path.Combine(FilePath, FileName)))
            {
                throw new FileNotFoundException("le json est manquant");
            }
            ObservableCollection<Playlist> playlists;
            
            using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                playlists = serializer.ReadObject(s) as ObservableCollection<Playlist>;
            }
            return playlists;
        }

        public void SauvegardeDonnee(ObservableCollection<Playlist> playlists)
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Playlist>));
            if(!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
            {
                serializer.WriteObject(s, playlists);
            }
            Debug.WriteLine("donnees saved");
        }
    }
}
