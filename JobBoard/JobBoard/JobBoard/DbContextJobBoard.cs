using JobBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoard
{
    public class DbContextJobBoard : IdentityDbContext<IdentityUser>
    {
        public DbSet<JobOffer> Offers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbContextJobBoard(DbContextOptions<DbContextJobBoard> Options) :base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
