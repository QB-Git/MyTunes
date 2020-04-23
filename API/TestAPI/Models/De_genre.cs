using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTunes.Models
{
    public class De_genre
    {
        public int id_musique { get; set; }
        public virtual Musique Musique { get; set; }
        public int id_genre { get; set; }
        public virtual Genre Genre { get; set; }
    }
}