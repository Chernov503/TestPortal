using AuthService.Domain.Entityes;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.PostgreSQL
{
    public class AuthDbContext : DbContext
    {
        public DbSet<BanRecordEntity> BanRecords { get; set; }
        public DbSet<UserEntity> Users { get; set; }

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
                .HasMaxLength(1000)
                .HasDefaultValue("No message provided");
            BanRecordsBuilder.HasIndex(blr => blr.Email)
                .IsUnique()
                .HasDatabaseName("IX_BanRecords_Email");

            #endregion

            #region UserBuilder

            var UserBuilder = modelBuilder.Entity<UserEntity>();

            UserBuilder.HasKey(u => u.Id);
            UserBuilder.Property(u => u.Firstname)
                .IsRequired()
                .HasMaxLength(50);
            UserBuilder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(50);
            UserBuilder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256)
                .HasAnnotation("Email", "Email address");
            UserBuilder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);
            UserBuilder.Property(u => u.Company)
                .HasMaxLength(100);
            UserBuilder.Property(u => u.Role)
                .IsRequired();
            UserBuilder.HasIndex(u => u.Email).IsUnique();

            #endregion
        }
    }

}
