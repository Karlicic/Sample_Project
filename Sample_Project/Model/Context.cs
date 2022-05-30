using Microsoft.EntityFrameworkCore;
using Sample_Project.Model.Enums;

namespace Sample_Project.Model
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlist { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.FavouriteArtists)
                .WithMany(a => a.Followers);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavouriteAlbums)
                .WithMany(a => a.Followers);

            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedSongs)
                .WithMany(s => s.Followers);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.CreatedBy);

            modelBuilder.Entity<Artist>()
                .HasMany(ar => ar.Albums)
                .WithOne(al => al.Artist);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Song>()
                .HasMany(s => s.Playlists)
                .WithMany(p => p.Songs);

            //Maximum length
            modelBuilder.Entity<Song>()
                .Property(s => s.Title)
                .HasMaxLength(500);

            //Value conversion
            modelBuilder.Entity<Artist>()
                .Property(a => a.Genre)
                .HasConversion(
                v => v.ToString(),
                v => (Genre)Enum.Parse(typeof(Genre), v));
        }
    }
}
