using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models.Complementaire
{
    public partial class COMPLEMENTAIREContext : DbContext
    {

        public COMPLEMENTAIREContext(DbContextOptions<COMPLEMENTAIREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tdr> Tdrs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tdr>(entity =>
            {
                entity.ToTable("TDR");

                entity.Property(e => e.TdrId).HasColumnName("TDR_ID");

                entity.Property(e => e.AvoirSoinsId).HasColumnName("AVOIR_SOINS_ID");

                entity.Property(e => e.Commentaire)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTAIRE");

                entity.Property(e => e.Date)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("DATE");

                entity.Property(e => e.Demande)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEMANDE");

                entity.Property(e => e.Etat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ETAT");

                entity.Property(e => e.Resultat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESULTAT");

                entity.Property(e => e.Urgence)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URGENCE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
