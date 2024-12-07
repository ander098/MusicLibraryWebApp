using System.Collections.Generic;
using System.Linq;

namespace MusicLibraryWebApp.Models
{
    public class MusicLibrary
    {
        public List<Song> Songs { get; set; } = new List<Song>();
        public List<Album> Albums { get; set; } = new List<Album>();
        public List<Artist> Artists { get; set; } = new List<Artist>();

        public void AddSong(Song song)
        {
            Songs.Add(song);

            if (!Artists.Any(a => a.Name == song.Artist))
            {
                Artists.Add(new Artist { Name = song.Artist });
            }

            if (!Albums.Any(a => a.Title == song.Album))
            {
                Albums.Add(new Album { Title = song.Album, Artist = song.Artist });
            }
        }

        public void AddAlbum(Album album)
        {
            if (!Albums.Any(a => a.Title == album.Title))
            {
                Albums.Add(album);
            }
        }

        public void AddArtist(Artist artist)
        {
            if (!Artists.Any(a => a.Name == artist.Name))
            {
                Artists.Add(artist);
            }
        }
    }
}
