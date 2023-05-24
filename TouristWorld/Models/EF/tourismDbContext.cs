using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TouristWorld.Models.EF
{
    public partial class tourismDbContext : DbContext
    {
        public tourismDbContext()
        {
        }

        public tourismDbContext(DbContextOptions<tourismDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbTouristLocation> TbTouristLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:touristworld.database.windows.net,1433;Initial Catalog=tourismDb;Persist Security Info=False;User ID=DbAdmin;Password=VipinKumar@#4u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbTouristLocation>(entity =>
            {
                entity.HasKey(e => e.PlaceId)
                    .HasName("PK__tb_Touri__D5222B6E71123E89");

                entity.ToTable("tb_TouristLocation");

                entity.Property(e => e.PlaceId).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationImage).IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
