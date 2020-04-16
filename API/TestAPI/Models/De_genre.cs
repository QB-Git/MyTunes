using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class De_genre
    {
        [Key]
        public int id_musique { get; set; }
        [Key]
        public int id_genre { get; set; }
    }
}