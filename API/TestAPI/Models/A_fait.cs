using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTunes.Models
{
    public class A_fait
    {
        public int id_artiste { get; set; }
        public int id_musique { get; set; }
    }
}