using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class CustomProviderContext : DbContext
    {
        public CustomProviderContext(DbContextOptions<CustomProviderContext> options) : base(options) { }
        public virtual DbSet<CustomUser> CustomUser { get; set; }
        public virtual DbSet<CustomUserClaim> CustomUserClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<CustomUserClaim>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomUserClaim)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.CustomUserClaim_dbo.CustomUser_UserId");
            });
        }
    }
}
