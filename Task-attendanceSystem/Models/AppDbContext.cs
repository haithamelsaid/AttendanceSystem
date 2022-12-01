using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Task_attendanceSystem.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public virtual DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public virtual DbSet<Attendence> Attendences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Attendence>()
                .HasOne(x => x.applicationUser)
                .WithMany(x => x.attendences)
                .HasForeignKey(x => x.ApplicationUserGuid)
                .HasConstraintName("ApplicationUserGuid")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


            base.OnModelCreating(builder);
        }
    }
}
