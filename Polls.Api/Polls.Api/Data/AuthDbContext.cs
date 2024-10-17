using Microsoft.EntityFrameworkCore;
using Polls.Api.Data.DomainModels;

namespace Polls.Api.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }
    }
}
