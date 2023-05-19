using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models
{
    public partial class CONSULTATIONContext : DbContext
    {

        public CONSULTATIONContext(DbContextOptions<CONSULTATIONContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Consultation> Consultations { get; set; } = null!;
        public virtual DbSet<Medecin> Medecins { get; set; } = null!;
        public virtual DbSet<Diagnostic> Diagnostics { get; set; } = null!;
        public virtual DbSet<DiagnosticAvoir> DiagnosticAvoirs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>(entity =>
            {
                entity.HasKey(e => e.Consultationid)
                    .HasName("PK_consultation");

                entity.ToTable("consultation");

                entity.Property(e => e.Consultationid)
                .HasColumnName("CONSULTATIONID");

                entity.Property(e => e.Numjour)
                    .HasColumnName("NUMJOUR");

                entity.Property(e => e.Passage)
                    .HasColumnName("PASSAGE");

                entity.Property(e => e.Dateconsultation)
                    .HasColumnType("datetime")
                    .HasColumnName("DATECONSULTATION");

                //entity.Property(e => e.Diagnostique)
                //    .HasMaxLength(255)
                //    .IsUnicode(false)
                //    .HasColumnName("DIAGNOSTIQUE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Soinsid).HasColumnName("SOINSID");

                entity.Property(e => e.Medecinid).HasColumnName("MEDECINID");

                entity.Property(e => e.DateRdv)
                .HasColumnType("datetime")
                .HasColumnName("DATE_RDV");

                entity.Property(e => e.Observations)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVATIONS");

                entity.Property(e => e.Statut)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUT")
                    .IsFixedLength();

                entity.Property(e => e.Plainte)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PLAINTE");

                entity.Property(e => e.Symptomes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SYMPTOMES");

                entity.Property(e => e.ListeAttente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LISTE_ATTENTE");

                entity.Property(e => e.Programmer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                .HasColumnName("PROGRAMMER");

                entity.Property(e => e.repos)
                    .HasColumnName("REPOS");

                entity.Property(e => e.reposJours)
                .HasColumnType("decimal(4, 2) NULL")
                .HasColumnName("REPOS_JOURS");
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.ToTable("medecin");

                entity.Property(e => e.Medecinid).HasColumnName("MEDECINID");

                entity.Property(e => e.Utilisateurid).HasColumnName("UTILISATEURID");



                entity.Property(e => e.Adresse)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Statut)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUT");

                entity.Property(e => e.Fonction)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("FONCTION");

                entity.Property(e => e.NomMedecin)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NOM_MEDECIN");

                entity.Property(e => e.PrenomMedecin)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM_MEDECIN");

                entity.Property(e => e.Specialite)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SPECIALITE");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");

            });

            modelBuilder.Entity<Diagnostic>(entity =>
            {
                entity.ToTable("diagnostic");

                entity.Property(e => e.DiagnosticId).HasColumnName("DIAGNOSTIC_ID");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");
            });

            modelBuilder.Entity<DiagnosticAvoir>(entity =>
            {
                entity.ToTable("diagnostic_avoir");

                entity.Property(e => e.DiagnosticAvoirId).HasColumnName("DIAGNOSTIC_AVOIR_ID");

                entity.Property(e => e.ConsultationId).HasColumnName("CONSULTATION_ID");

                entity.Property(e => e.Date)
                .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DesignationDiag)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION_DIAG");

                entity.Property(e => e.DiagnosticId).HasColumnName("DIAGNOSTIC_ID");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
