using Microsoft.EntityFrameworkCore;
namespace API_project.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> UserDB
        {
            get;
            set;
        }
        public DbSet<Post> Posts
        {
            get;
            set;
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.firstName);

                entity.Property(e => e.lastName);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Title);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.posts)
                    .HasForeignKey(d => d.user_id);
            });

            // configures one-to-many relationship
            modelBuilder.Entity<User>()
                .HasMany(b => b.posts)
                .WithOne(s => s.user)
                .OnDelete(DeleteBehavior.ClientCascade);
        }*/
    }
}



