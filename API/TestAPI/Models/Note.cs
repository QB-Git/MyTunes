using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Note
    {
        [Key]
        public int id_user { get; set; }
        [Key]
        public int id_musique { get; set; }
        public int note { get; set; }
    }
}