using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyTunes.Models
{
    public class Genre
    {
        [Key]
        public int id_genre { get; set; }
        public string genre { get; set; }
        public virtual IEnumerable<De_genre> musiques { get; set; }

    }
}