using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models.Pochette
{
    public class Pochette
    {
        [Key]
        public int id_pochette { get; set; }
        [Required]
        public string img_pochette { get; set; }
    }
}