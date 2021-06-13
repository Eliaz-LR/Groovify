using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public interface IPersistance
    {
        ObservableCollection<Playlist> ChargeDonnee();

        void SauvegardeDonnee(ObservableCollection<Playlist> playlists);
    }
}
