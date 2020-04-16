﻿using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        public string pseudo { get; set; }
        [Required]
        public string password { get; set; }
    }
}