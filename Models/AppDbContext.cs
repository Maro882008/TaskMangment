using Microsoft.EntityFrameworkCore;
using TaskManagment.Models.Entites;

namespace TaskManagment.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet <Project> projects { get; set; }
        public DbSet<task> tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<task>().HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x => x.Userid).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<task>().HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x => x.Projectid).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
