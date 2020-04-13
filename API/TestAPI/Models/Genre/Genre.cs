using System;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models.Genre
{
    public class Genre
    {
        [Key]
        public int id_genre { get; set; }
        public string genre { get; set; }
    }
}