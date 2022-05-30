namespace Sample_Project.Model
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
        public ICollection<User> Followers { get; set; } = new List<User>();
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    }
}
