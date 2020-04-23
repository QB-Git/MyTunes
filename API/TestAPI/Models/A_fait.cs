using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTunes.Models
{
    public class A_fait
    {
        public int id_artiste { get; set; }
        public virtual Artiste Artiste { get; set; }
        public int id_musique { get; set; }
        public virtual Musique Musique { get; set; }
    }
}