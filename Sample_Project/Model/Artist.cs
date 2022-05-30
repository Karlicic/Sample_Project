using Sample_Project.Model.Enums;
using System.Text.Json.Serialization;

namespace Sample_Project.Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<User> Followers { get; set; } = new List<User>();

    }
}
