using System.ComponentModel.DataAnnotations;

namespace MyTunes.Models.User
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string pseudo { get; set; }
        public string password { get; set; }
    }
}