using AuthService.Domain.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.PostgreSQL
{
    public class AuthDbContext : DbContext
    {
        public DbSet<BanRecordEntity> BanRecords { get; set; }
        public DbSet<UserTestAccessEntity> UserTestAccesses { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BanRecordsBuilder

            var BanRecordsBuilder = modelBuilder.Entity<BanRecordEntity>();

            BanRecordsBuilder.HasKey(blr => blr.Email);
            BanRecordsBuilder.Property(blr => blr.Email)
                .IsRequired()
                .HasMaxLength(256);
            BanRecordsBuilder.Property(blr => blr.BanMessage)
                .IsRequired()
                .HasMaxLength(1000);
            BanRecordsBuilder.HasIndex(blr => blr.Email)
                .IsUnique();
            BanRecordsBuilder.Property(blr => blr.DateExp)
                .IsRequired();

            #endregion

            #region UserTestAccessBuilder

            var UserTestAccessBuilder = modelBuilder.Entity<UserTestAccessEntity>();

            UserTestAccessBuilder.HasKey(uta => new{uta.TestId, uta.UserId});
            
            #endregion
        }
    }

}
