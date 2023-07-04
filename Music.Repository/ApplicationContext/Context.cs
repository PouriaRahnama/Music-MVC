using Music.Data;
using System.Data.Entity;

namespace Music.Repository.ApplicationContext
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Singer> Singers { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<SongLike> SongLikes { get; set; }

        public DbSet<SongVisit> SongVisits { get; set; }
    }
}
