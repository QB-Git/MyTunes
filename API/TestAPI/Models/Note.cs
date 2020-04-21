using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTunes.Models
{
    public class Note
    {
        public int id_user { get; set; }
        public virtual User User { get; set; }
        public int id_musique { get; set; }
        public virtual Musique Musique { get; set; }
        public int note { get; set; }
    }
}