using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Playlist
    {
        [Key]
        public int id_user { get; set; }
        [Key]
        public int id_musique { get; set; }
        public string nom { get; set; }
    }
}