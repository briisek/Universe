using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Metadata;
using Universe.DatabaseLayer.Model;

#nullable disable

namespace Universe.DatabaseLayer
{
    public partial class VesmirContext : DbContext
    {
        public VesmirContext()
        {
        }

        public VesmirContext(DbContextOptions<VesmirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Galaxie> Galaxies { get; set; }
        public virtual DbSet<Planetum> Planeta { get; set; }
        public virtual DbSet<Vlastnost> Vlastnosts { get; set; }
        public virtual DbSet<VlastnostiPlanet> VlastnostiPlanets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sqltest02;Database=Vesmir;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies();
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Czech_CI_AS");

            modelBuilder.Entity<Galaxie>(entity =>
            {
                entity.ToTable("Galaxie");

                entity.Property(e => e.Jmeno)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planetum>(entity =>
            {
                entity.Property(e => e.Jmeno)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Velikost).HasDefaultValueSql("((6378))");

                entity.HasOne(d => d.Galaxie)
                    .WithMany(p => p.Planeta)
                    .HasForeignKey(d => d.GalaxieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Planeta_Galaxie");
            });

            modelBuilder.Entity<Vlastnost>(entity =>
            {
                entity.ToTable("Vlastnost");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nazev)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VlastnostiPlanet>(entity =>
            {
                entity.HasKey(e => new { e.PlanetaId, e.VlastnostId });

                entity.ToTable("VlastnostiPlanet");

                entity.HasOne(d => d.Planeta)
                    .WithMany(p => p.VlastnostiPlanets)
                    .HasForeignKey(d => d.PlanetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VlastnostiPlanet_Planeta");

                entity.HasOne(d => d.Vlastnost)
                    .WithMany(p => p.VlastnostiPlanets)
                    .HasForeignKey(d => d.VlastnostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VlastnostiPlanet_Vlastnost");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
