using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyTunes.Models
{
    public class Album
    {
        [Key]
        public int id_album { get; set; }
        [Required]
        public string nom_album { get; set; }
        [ForeignKey("id_pochette")]
        public Pochette pochette { get; set; }
        public virtual IEnumerable<Appartient_a> musiques { get; set; }
    }
}