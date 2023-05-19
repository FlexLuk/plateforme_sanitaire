using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models
{
    public partial class ADHESIONContext : DbContext
    {

        public ADHESIONContext(DbContextOptions<ADHESIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistoEmploi> HistoEmplois { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Employeur> Employeurs { get; set; } = null!;
        public virtual DbSet<Famille> Familles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("employer");

                entity.Property(e => e.Employerid).HasColumnName("EMPLOYERID");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(128)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(32)
                    .HasColumnName("CATEGORIE")
                    .IsFixedLength();

                entity.Property(e => e.Cin)
                    .HasMaxLength(32)
                    .HasColumnName("CIN")
                    .IsFixedLength();

                entity.Property(e => e.Contact)
                    .HasMaxLength(128)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Datenaissance)
                    .HasColumnType("datetime")
                    .HasColumnName("DATENAISSANCE");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fonction)
                    .HasMaxLength(50)
                    .HasColumnName("FONCTION");

                entity.Property(e => e.NomDossier)
                    .HasColumnName("NOM_DOSSIER");

                entity.Property(e => e.Lieunaissance)
                    .HasMaxLength(128)
                    .HasColumnName("LIEUNAISSANCE");

                entity.Property(e => e.Nom)
                    .HasMaxLength(32)
                    .HasColumnName("NOM")
                    .IsFixedLength();

                entity.Property(e => e.Numemployeur)
                    .HasMaxLength(10)
                    .HasColumnName("NUMEMPLOYEUR")
                    .IsFixedLength();

                entity.Property(e => e.Numeroosiet)
                    .HasMaxLength(50)
                    .HasColumnName("NUMEROOSIET");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(32)
                    .HasColumnName("PRENOM")
                    .IsFixedLength();

                entity.Property(e => e.Sexe)
                    .HasMaxLength(32)
                    .HasColumnName("SEXE")
                    .IsFixedLength();

                entity.Property(e => e.Situationmatrimoniale)
                    .HasMaxLength(32)
                    .HasColumnName("SITUATIONMATRIMONIALE")
                    .IsFixedLength();

                entity.Property(e => e.Statut)
                    .HasMaxLength(50)
                    .HasColumnName("STATUT");
            });

            modelBuilder.Entity<HistoEmploi>(entity =>
            {
                entity.HasKey(e => e.Emploiid)
                    .HasName("PK_EMPLOI");

                entity.ToTable("histo_emploi");

                entity.Property(e => e.Emploiid).HasColumnName("EMPLOIID");

                entity.Property(e => e.Commentaire).HasColumnName("COMMENTAIRE");

                entity.Property(e => e.Datedebauche)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEDEBAUCHE");

                entity.Property(e => e.Dateembauche)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEEMBAUCHE");

                entity.Property(e => e.Emploi)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOI");

                entity.Property(e => e.Employerid).HasColumnName("EMPLOYERID");

                entity.Property(e => e.Numemployeur)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NUMEMPLOYEUR")
                    .IsFixedLength();

                entity.Property(e => e.Numosiet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NUMOSIET")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employeur>(entity =>
            {
                entity.ToTable("employeur");

                entity.Property(e => e.Employeurid).HasColumnName("EMPLOYEURID");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Formejurdique)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("FORMEJURDIQUE");

                entity.Property(e => e.Nif)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NIF");

                entity.Property(e => e.Nomcontact)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NOMCONTACT");

                entity.Property(e => e.Numemployeur)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("NUMEMPLOYEUR");

                entity.Property(e => e.Raisonsociale)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("RAISONSOCIALE");

                entity.Property(e => e.Stat)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STAT");

                entity.Property(e => e.Statut)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STATUT");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TELEPHONE");
            });

            modelBuilder.Entity<Famille>(entity =>
            {
                entity.ToTable("famille");

                entity.Property(e => e.Familleid).HasColumnName("FAMILLEID");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE")
                    .IsFixedLength();

                entity.Property(e => e.Cin)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CIN")
                    .IsFixedLength();

                entity.Property(e => e.Contact)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT");

                entity.Property(e => e.Datenaissance)
                    .HasColumnType("datetime")
                    .HasColumnName("DATENAISSANCE");

                entity.Property(e => e.Lieunaissance)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LIEUNAISSANCE")
                .IsFixedLength();

                entity.Property(e => e.Employerid).HasColumnName("EMPLOYERID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM")
                    .IsFixedLength();

                entity.Property(e => e.Prenom)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM")
                    .IsFixedLength();

                entity.Property(e => e.Sexe)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SEXE")
                    .IsFixedLength();

                entity.Property(e => e.Numeroosiet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROOSIET");

                entity.Property(e => e.NomDossier)
                    .HasColumnName("NOM_DOSSIER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
