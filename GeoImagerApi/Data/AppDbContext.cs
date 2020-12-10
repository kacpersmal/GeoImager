using GeoImagerApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoImagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<UserPostModel> UserPosts { get; set; }
        public DbSet<UserPostModel> UserComments { get; set; }
        public DbSet<Follower> Followers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            
            modelBuilder.Entity<UserModel>()
             .HasOne(x => x.UserProfile)
             .WithOne(x => x.User)
             .HasForeignKey<UserProfileModel>(x => x.UserId);

            modelBuilder.Entity<UserProfileModel>().HasMany(x => x.Posts).WithOne(x => x.Owner);
            modelBuilder.Entity<UserPostModel>().HasMany(x => x.Photos).WithOne(x => x.Owner).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follower>()
                .HasOne(x => x.User).WithMany(x => x.Followers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
