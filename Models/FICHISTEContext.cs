using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models
{
    public partial class FICHISTEContext : DbContext
    {
        public FICHISTEContext(DbContextOptions<FICHISTEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fichiste> Fichistes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fichiste>(entity =>
            {
                entity.ToTable("fichiste");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Affiliationid)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("AFFILIATIONID");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Frequencemois).HasColumnName("FREQUENCEMOIS");
                entity.Property(e => e.Frequenceannee).HasColumnName("FREQUENCEANNEE");

                entity.Property(e => e.Numjour).HasColumnName("NUMJOUR");

                entity.Property(e => e.Parametreid).HasColumnName("PARAMETREID");
                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
