using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("id_pochette")]
        public Pochette pochette { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("id_editeur")]
        public Editeur editeur { get; set; }
        public virtual IEnumerable<De_genre> genres { get; set; }
        public virtual IEnumerable<A_fait> artistes { get; set; }
        public virtual IEnumerable<Appartient_a> albums { get; set; }
        //public virtual IEnumerable<Playlist> playlists { get; set; } pas besoin
        public virtual IEnumerable<Note> notes { get; set; }

    }
}