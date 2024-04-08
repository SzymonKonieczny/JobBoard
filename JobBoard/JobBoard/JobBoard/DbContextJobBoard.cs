using JobBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoard
{
    public class DbContextJobBoard : IdentityDbContext<JobBoardAccount>
    {
        public DbSet<JobOffer> Offers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbContextJobBoard(DbContextOptions<DbContextJobBoard> Options) :base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<JobOffer>().HasOne(c => c.CompanyID).WithMany(o => o.)


            modelBuilder.Entity<JobBoardAccount>().HasMany(o => o.Offers)
                .WithOne(c => c.OwnedBy).HasForeignKey(c => c.CompanyID);

        }
    }
}
