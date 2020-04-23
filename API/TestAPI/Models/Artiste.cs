using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Artiste
    {
        [Key]
        public int id_artiste { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public virtual ICollection<A_fait> musiques { get; set; }
    }
}