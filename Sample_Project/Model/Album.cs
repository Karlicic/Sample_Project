using System.ComponentModel.DataAnnotations;

namespace Sample_Project.Model
{
    public class Album
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public ICollection<User> Followers { get; set; } = new List<User>();
    }
}
