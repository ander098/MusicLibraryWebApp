using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebApp.Models;

namespace MusicLibraryWebApp.Controllers
{
    public class MusicLibraryController : Controller
    {
        private static MusicLibrary _library = new MusicLibrary();

        public IActionResult Index()
        {
            return View(_library);
        }

        public IActionResult AddSong()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSong(Song song)
        {
        if (ModelState.IsValid)
        {
            _library.AddSong(song); 
        }
        return RedirectToAction("Index");
        }


        public IActionResult AddAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAlbum(Album album)
        {
            _library.AddAlbum(album);
            return RedirectToAction("Index");
        }

        public IActionResult AddArtist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArtist(Artist artist)
        {
            _library.AddArtist(artist);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var results = new MusicLibrary
        {
        Songs = _library.Songs
            .Where(s => s.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        s.Artist.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList(),
        Albums = _library.Albums
            .Where(a => a.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        a.Artist.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList(),
        Artists = _library.Artists
            .Where(a => a.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList()
        };

            return View("Index", results);
        }


        public IActionResult SongDetails(string title)
        {
        var song = _library.Songs.FirstOrDefault(s => s.Title == title);
        if (song == null)
        {
            return NotFound();
        }
            return View(song);
        }

        public IActionResult EditSong(string title)
        {
        var song = _library.Songs.FirstOrDefault(s => s.Title == title);
        if (song == null)
        {
            return NotFound();
        }   
            return View(song);
        }   

    [HttpPost]
        public IActionResult EditSong(Song updatedSong)
        {   
        var song = _library.Songs.FirstOrDefault(s => s.Title == updatedSong.Title);
        if (song == null)
        {
            return NotFound();
        }

        song.Artist = updatedSong.Artist;
        song.Album = updatedSong.Album;
        song.Genre = updatedSong.Genre;
        song.Rank = updatedSong.Rank;

        return RedirectToAction("Index");
        }

        public IActionResult DeleteSong(string title)
        {
        var song = _library.Songs.FirstOrDefault(s => s.Title == title);
        if (song != null)
        {
            _library.Songs.Remove(song);
        }
        return RedirectToAction("Index");
        }

        public IActionResult AlbumDetails(string album)
        {
        var songs = _library.Songs.Where(s => s.Album == album).ToList();
        if (!songs.Any())
        {
            return NotFound();
        }
        ViewBag.Album = album;
            return View(songs);
        }

        public IActionResult ArtistDetails(string artist)
        {
        var songs = _library.Songs.Where(s => s.Artist == artist).ToList();
        if (!songs.Any())
        {
            return NotFound();
        }
        ViewBag.Artist = artist;
            return View(songs);
        }


        public IActionResult SongsByGenre(string genre)
        {
        var songs = _library.Songs.Where(s => s.Genre == genre).ToList();
        if (!songs.Any())
        {
            return NotFound();
        }
        ViewBag.Genre = genre;
            return View(songs);
        }
        

        public IActionResult TopRankedSongs()
        {
        var songs = _library.Songs.Where(s => s.Rank >= 8).OrderByDescending(s => s.Rank).ToList();
        if (!songs.Any())
        {
            return NotFound();
        }
            return View(songs);
        }


    }
}
