using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Genre
    {
        [Key]
        public int id_genre { get; set; }
        public string genre { get; set; }
    }
}