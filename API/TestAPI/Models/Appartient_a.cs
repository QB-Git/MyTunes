using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Appartient_a
    {
        [Key]
        public int id_album { get; set; }
        [Key]
        public int id_musique { get; set; }
        [Required]
        public int num_piste { get; set; }
    }
}