using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models
{
    public partial class PARAMETREContext : DbContext
    {

        public PARAMETREContext(DbContextOptions<PARAMETREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistoPassageEmployer> HistoPassageEmployers { get; set; } = null!;
        public virtual DbSet<ListeParametre> ListeParametres { get; set; } = null!;
        public virtual DbSet<Parametre> Parametres { get; set; } = null!;
        public virtual DbSet<Patiant> Patiants { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoPassageEmployer>(entity =>
            {
                entity.ToTable("histo_passage_employer");

                entity.Property(e => e.Histopassageemployerid).HasColumnName("HISTOPASSAGEEMPLOYERID");

                entity.Property(e => e.Affiliationid).HasColumnName("AFFILIATIONID");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Patiantid).HasColumnName("PATIANTID");
            });

            modelBuilder.Entity<ListeParametre>(entity =>
            {
                entity.ToTable("liste_parametre");

                entity.Property(e => e.Listeparametreid).HasColumnName("LISTEPARAMETREID");
                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Utilisateurid).HasColumnName("UTILISATEURID");

                entity.Property(e => e.Statut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUT");
            });

            modelBuilder.Entity<Parametre>(entity =>
            {
                entity.ToTable("parametre");

                entity.Property(e => e.Parametreid).HasColumnName("PARAMETREID");


                entity.Property(e => e.Datecreation)
                    .HasColumnType("datetime")
                    .HasColumnName("DATECREATION");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Medecinid).HasColumnName("MEDECINID");

                entity.Property(e => e.Observation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVATION")
                    .IsFixedLength();

                entity.Property(e => e.Patiantid).HasColumnName("PATIANTID");

                entity.Property(e => e.Poids)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POIDS")
                    .IsFixedLength();

                entity.Property(e => e.FrequenceCardiaque)
                    .HasMaxLength(50)
                    .HasColumnName("FREQUENCE_CARDIAQUE")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Tag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TAG")
                    .IsFixedLength();

                entity.Property(e => e.Tad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TAD")
                    .IsFixedLength();

                entity.Property(e => e.Temperature)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEMPERATURE")
                    .IsFixedLength();

                entity.Property(e => e.Passage)
                    .HasColumnName("PASSAGE");
            });

            modelBuilder.Entity<Patiant>(entity =>
            {
                entity.ToTable("patiant");

                entity.Property(e => e.Patiantid).HasColumnName("PATIANTID");

                entity.Property(e => e.Affiliationid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("AFFILIATIONID")
                    .IsFixedLength();

                entity.Property(e => e.Categorie)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE")
                    .IsFixedLength();
                entity.Property(e => e.Statut)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUT")
                    .IsFixedLength();

                entity.Property(e => e.Datepassage)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEPASSAGE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Numeroparametre).HasColumnName("NUMEROPARAMETRE");

                entity.Property(e => e.Numjour).HasColumnName("NUMJOUR");

                entity.Property(e => e.Nomparametre).HasColumnName("NOMPARAMETRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
