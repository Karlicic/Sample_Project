using System.ComponentModel.DataAnnotations;

namespace Sample_Project.Model
{
    public class User
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Username { get; set; }
        public ICollection<Artist> FavouriteArtists { get; set; } = new List<Artist>();
        public ICollection<Album> FavouriteAlbums { get; set; } = new List<Album>();
        public ICollection<Song> LikedSongs { get; set; } = new List<Song>();
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    }
}
