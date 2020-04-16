using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class A_fait
    {
        [Key]
        public int id_artiste { get; set; }
        [Key]
        public int id_musique { get; set; }
    }
}