using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models.Artiste
{
    public class Artiste
    {
        [Key]
        public int id_artiste { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
    }
}