using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyTunes.Models
{
    public class Appartient_a
    {
        public int id_album { get; set; }
        public virtual Album Album{ get; set; }
        public int id_musique { get; set; }
        public virtual Musique Musique { get; set; }
        [Required]
        public int num_piste { get; set; }
    }
}