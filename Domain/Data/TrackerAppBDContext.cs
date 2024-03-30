using TrackerDomain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;

namespace TrackerDomain.Data
{
    public class TrackerAppBDContext : IdentityDbContext
    {
        public TrackerAppBDContext(DbContextOptions<TrackerAppBDContext> options) : base(options)
        {

        }

        protected TrackerAppBDContext()
        {
            Status = Set<Status>();
            MovementType = Set<MovementType>();
            Book = Set<Book>();
            Movement = Set<Movement>();

        }


        public DbSet<Status> Status { get; set; }
        public virtual DbSet<MovementType> MovementType { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Movement> Movement { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Status>()
                .Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<MovementType>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<MovementType>()
                .Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Book>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Book>()
                .Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Book>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Movement>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Movement>()
                .Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Movement>()
                .Property(a => a.Balance)
                .HasColumnType("Decimal(18,2)");
            //.HasPrecision(18, 2);
            modelBuilder.Entity<Movement>()
                .Property(a => a.Value)
                .HasColumnType("Decimal(18,2)");
            //.HasPrecision(18, 2);

           //modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
           //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
           //modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}
