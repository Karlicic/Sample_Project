namespace Sample_Project.Model
{
    public class Playlist
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
