using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string token { get; set; }
        public virtual IEnumerable<Playlist> playlists { get; set; }
        public virtual IEnumerable<Note> notes { get; set; }

    }
}