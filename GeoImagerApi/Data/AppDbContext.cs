using GeoImagerApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoImagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfileModel>()
                .HasMany(x => x.Followers)
                .WithMany(x => x.Following);
            
            modelBuilder.Entity<UserModel>()
             .HasOne(x => x.UserProfile)
             .WithOne(x => x.User)
             .HasForeignKey<UserProfileModel>(x => x.UserId);
        }

    }
}
