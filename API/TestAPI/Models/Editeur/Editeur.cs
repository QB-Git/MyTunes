﻿using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models.Editeur
{
    public class Editeur
    {
        [Key]
        public int id_editeur { get; set; }
        [Required]
        public string nom_editeur { get; set; }
    }
}