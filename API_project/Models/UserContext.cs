using API_project.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace API_project.Models
{
    public class UserContext : IdentityDbContext<User, UserRoles, int>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
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
    }
}



