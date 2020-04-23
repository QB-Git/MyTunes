using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTunes.Models
{
    public class Playlist { 
        public int id_user { get; set; }
        public virtual User User { get; set; }
        public int id_musique { get; set; }
        public virtual Musique Musique { get; set; }
        public string nom { get; set; }
        public Boolean publique { get; set; }
    }
}