
using HW13.Configuration;
using HW13.Entities;
using Microsoft.EntityFrameworkCore;
namespace HW13.infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.Configuration.configurationstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberConfig());
            modelBuilder.ApplyConfiguration(new LibrariaConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Librarian> librarians { get; set; }
        public DbSet<Member> members { get; set; }
    }
}
//َAdd-Migration init
//Update-Database