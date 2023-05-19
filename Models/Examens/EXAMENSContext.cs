using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models.Examens
{
    public partial class EXAMENSContext : DbContext
    {

        public EXAMENSContext(DbContextOptions<EXAMENSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dentiste> Dentistes { get; set; } = null!;
        public virtual DbSet<EchoEcg> EchoEcgs { get; set; } = null!;
        public virtual DbSet<AvoirLaboratoire> AvoirLaboratoires { get; set; } = null!;
        public virtual DbSet<Laboratoire> Laboratoires { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentiste>(entity =>
            {
                entity.ToTable("dentiste");

                entity.Property(e => e.Dentisteid).HasColumnName("DENTISTEID");

                entity.Property(e => e.Age).HasColumnName("AGE");
                entity.Property(e => e.numDent).HasColumnName("NUMERO_DENT");

                entity.Property(e => e.Cas)
                    .HasMaxLength(50)
                    .HasColumnName("NOUVEAU_CAS")
                    .IsFixedLength();

                //entity.Property(e => e.Commentaires).HasColumnName("COMMENTAIRES");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Rendez_vous)
                    .HasColumnType("datetime")
                    .HasColumnName("RENDEZ_VOUS");

                entity.Property(e => e.Demande)
                    .HasMaxLength(255)
                    .HasColumnName("DEMANDE");

                entity.Property(e => e.Diagnostiques)
                    .HasMaxLength(32)
                    .HasColumnName("DIAGNOSTIQUES");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");
                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.Property(e => e.Ordonnanceid).HasColumnName("ORDONNANCEID");

                entity.Property(e => e.Plaintes).HasColumnName("PLAINTES");

                entity.Property(e => e.Prescripteur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRESCRIPTEUR");

                entity.Property(e => e.Repetition).HasColumnName("REPETITION");

                entity.Property(e => e.Resultat).HasColumnName("RESULTAT");

                entity.Property(e => e.Symptomes).HasColumnName("SYMPTOMES");
                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.Property(e => e.Terminer)
                    .HasMaxLength(50)
                    .HasColumnName("TERMINER");
            });

            modelBuilder.Entity<EchoEcg>(entity =>
            {
                entity.ToTable("echo_ecg");

                entity.Property(e => e.EchoEcgId).HasColumnName("ECHO_ECG_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Demande).HasColumnName("DEMANDE");

                entity.Property(e => e.Ecg)
                    .HasMaxLength(100)
                    .HasColumnName("ECG");

                entity.Property(e => e.Echo)
                    .HasMaxLength(100)
                    .HasColumnName("ECHO");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Prescripteur)
                    .HasMaxLength(100)
                    .HasColumnName("PRESCRIPTEUR");

                entity.Property(e => e.Resultat).HasColumnName("RESULTAT");

                entity.Property(e => e.Statut)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Laboratoire>(entity =>
            {
                entity.ToTable("laboratoire");

                entity.Property(e => e.LaboratoireId).HasColumnName("LABORATOIRE_ID");
                entity.Property(e => e.MedecinId).HasColumnName("MEDECIN_ID");
                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");

                entity.Property(e => e.Commentaire)
                    .HasMaxLength(255)
                    .HasColumnName("COMMENTAIRE")
                    .IsFixedLength();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.Prescripteur)
                    .HasMaxLength(100)
                    .HasColumnName("PRESCRIPTEUR");

                entity.Property(e => e.Resultat)
                    .HasMaxLength(255)
                    .HasColumnName("RESULTAT")
                    .IsFixedLength();

                entity.Property(e => e.Statut)
                    .HasMaxLength(10)
                    .HasColumnName("STATUT")
                    .IsFixedLength();

                entity.Property(e => e.Test)
                    .HasMaxLength(100)
                    .HasColumnName("TEST");

                entity.Property(e => e.TypeTest)
                    .HasMaxLength(100)
                    .HasColumnName("TYPE_TEST");
            });

            modelBuilder.Entity<AvoirLaboratoire>(entity =>
            {
                entity.ToTable("avoir_laboratoire");

                entity.Property(e => e.AvoirLaboratoireId).HasColumnName("AVOIR_LABORATOIRE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.Statut)
                    .HasMaxLength(50)
                    .HasColumnName("STATUT");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
