using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Album
    {
        [Key]
        public int id_album { get; set; }
        [Required]
        public string nom_album { get; set; }
        public int id_pochette { get; set; }
    }
}