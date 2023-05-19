using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models.Rendez_vous
{
    public partial class RDVContext : DbContext
    {

        public RDVContext(DbContextOptions<RDVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MedecinRdv> MedecinRdvs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedecinRdv>(entity =>
            {
                entity.HasKey(e => e.Rdvid);

                entity.ToTable("medecin_rdv");

                entity.Property(e => e.Rdvid).HasColumnName("RDVID");

                entity.Property(e => e.Affiliationid).HasColumnName("AFFILIATIONID");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE");

                entity.Property(e => e.Consultationid).HasColumnName("CONSULTATIONID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Medecinid).HasColumnName("MEDECINID");

                entity.Property(e => e.Statut)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STATUT");

                entity.Property(e => e.Titre)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TITRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
