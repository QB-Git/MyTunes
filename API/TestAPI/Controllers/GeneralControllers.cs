using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;



namespace MyTunes.Controllers
{
    public class GeneralControllers : ControllerBase
    {
        protected readonly MyTunesContext _context;

        protected GeneralControllers(MyTunesContext context)
        {
            _context = context;
        }

        protected bool AlbumExists(int id)
        {
            return _context.ALBUM.Any(e => e.id_album == id);
        }

        protected bool ArtisteExists(int id)
        {
            return _context.ARTISTE.Any(e => e.id_artiste == id);
        }

        protected bool EditeurExists(int id)
        {
            return _context.EDITEUR.Any(e => e.id_editeur == id);
        }

        protected bool GenreExists(int id)
        {
            return _context.GENRE.Any(e => e.id_genre == id);
        }

        protected bool MusiqueExists(int id)
        {
            return _context.MUSIQUE.Any(e => e.id_musique == id);
        }

        protected bool PochetteExists(int id)
        {
            return _context.POCHETTE.Any(e => e.id_pochette == id);
        }

        //Cherche si l'utilisateur est admin
        protected bool UserAdmin(string pseudo, string passwd, string token)
        {
            return _context.USER.Any(e => e.pseudo == pseudo && e.password == passwd && e.token == token);
        }

        protected bool UserExists(int id)
        {
            return _context.USER.Any(e => e.id_user == id);
        }

        protected bool PlaylistExists(int id_user, string nom, int id_musique)
        {
            return _context.PLAYLIST.Any(e => e.id_user == id_user && e.nom == nom && e.id_musique == id_musique);
        }
    }
}
