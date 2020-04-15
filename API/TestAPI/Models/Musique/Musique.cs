using System;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class Musique
    {
        [Key]
        public int id_musique { get; set; }
        [Required]
        public string url { get; set; }
        [Required]
        public string titre { get; set; }
        public string langue { get; set; }
        public int id_pochette { get; set; }
        public DateTime date { get; set; }
        public int id_editeur { get; set; }
    }
}