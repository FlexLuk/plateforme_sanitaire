using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models.Pharmacie
{
    public partial class PHARMACIEContext : DbContext
    {
        public PHARMACIEContext(DbContextOptions<PHARMACIEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entree> Entrees { get; set; } = null!;
        public virtual DbSet<Medicament> Medicaments { get; set; } = null!;
        public virtual DbSet<Ordonnance> Ordonnances { get; set; } = null!;
        public virtual DbSet<OrdonnanceAvoir> OrdonnanceAvoirs { get; set; } = null!;
        public virtual DbSet<Sortie> Sorties { get; set; } = null!;
        public virtual DbSet<AvoirSoins> AvoirSoinss { get; set; } = null!;
        public virtual DbSet<Soins> Soinss { get; set; } = null!;
        public virtual DbSet<PassageSoin> PassageSoins { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entree>(entity =>
            {
                entity.ToTable("entree");

                entity.Property(e => e.Entreeid).HasColumnName("ENTREEID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Medicamentid).HasColumnName("MEDICAMENTID");

                entity.Property(e => e.Quantiteentree)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("QUANTITEENTREE");

                entity.Property(e => e.Stockfinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("STOCKFINAL");

                entity.Property(e => e.Stockinitial)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("STOCKINITIAL");

                entity.Property(e => e.Utilisateurid).HasColumnName("UTILISATEURID");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.ToTable("medicament");

                entity.Property(e => e.Medicamentid).HasColumnName("MEDICAMENTID");

                entity.Property(e => e.Designation)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PRESENTATION");

                entity.Property(e => e.Quantite)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("QUANTITE");

                entity.Property(e => e.Stockmin)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("STOCKMIN");
            });

            modelBuilder.Entity<Ordonnance>(entity =>
            {
                entity.ToTable("ordonnance");

                entity.Property(e => e.Ordonnanceid).HasColumnName("ORDONNANCEID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Fichistteid).HasColumnName("FICHISTTEID");

                entity.Property(e => e.Numordonnance).HasColumnName("NUMORDONNANCE");
                entity.Property(e => e.Etat).HasColumnName("ETAT");
            });

            modelBuilder.Entity<OrdonnanceAvoir>(entity =>
            {
                entity.ToTable("ordonnance_avoir");

                entity.Property(e => e.Ordonnanceavoirid).HasColumnName("ORDONNANCEAVOIRID");

                entity.Property(e => e.Medicamentid).HasColumnName("MEDICAMENTID");

                entity.Property(e => e.Ordonnanceid).HasColumnName("ORDONNANCEID");

                entity.Property(e => e.Prescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRESCRIPTION")
                    .IsFixedLength();
                entity.Property(e => e.Matin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATIN")
                    .IsFixedLength();
                entity.Property(e => e.Midi)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIDI")
                    .IsFixedLength();
                entity.Property(e => e.Soir)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOIR")
                    .IsFixedLength();

                entity.Property(e => e.Quantite)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("QUANTITE");

                entity.Property(e => e.Sortie).HasColumnName("SORTIE");
                entity.Property(e => e.Soins).HasColumnName("SOINS");
            });

            modelBuilder.Entity<Sortie>(entity =>
            {
                entity.ToTable("sortie");

                entity.Property(e => e.Sortieid).HasColumnName("SORTIEID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Medicamentid).HasColumnName("MEDICAMENTID");

                entity.Property(e => e.Ordonnanceid).HasColumnName("ORDONNANCEID");

                entity.Property(e => e.Quantitesortie)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("QUANTITESORTIE");

                entity.Property(e => e.Stockfinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("STOCKFINAL");

                entity.Property(e => e.Stockinitial)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("STOCKINITIAL");
            });

            modelBuilder.Entity<AvoirSoins>(entity =>
            {
                entity.HasKey(e => e.Avoirsoinsid);

                entity.ToTable("avoir_soins");

                entity.Property(e => e.Avoirsoinsid).HasColumnName("AVOIRSOINSID");

                entity.Property(e => e.Commentaire).HasColumnName("COMMENTAIRE");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Demande).HasColumnName("DEMANDE");
                entity.Property(e => e.DemandeSup).HasColumnName("DEMANDE_SUP");

                entity.Property(e => e.Frequence).HasColumnName("FREQUENCE");

                entity.Property(e => e.Ordonnanceavoirid).HasColumnName("ORDONNANCEAVOIRID");

                entity.Property(e => e.Presence)
                    .HasMaxLength(32)
                    .HasColumnName("PRESENCE")
                    .IsFixedLength();

                entity.Property(e => e.NombrePresence)
                    .HasColumnName("NOMBRE_PRESENCE");

                entity.Property(e => e.Resultat)
                    .HasMaxLength(50)
                    .HasColumnName("RESULTAT");

                entity.Property(e => e.TypeSoins)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE_SOINS");

                entity.Property(e => e.Etat)
                    .HasMaxLength(50)
                    .HasColumnName("ETAT");

                entity.Property(e => e.Soinsid).HasColumnName("SOINSID");

                entity.Property(e => e.Unitefrequence)
                    .HasMaxLength(32)
                    .HasColumnName("UNITEFREQUENCE")
                    .IsFixedLength();

                entity.Property(e => e.Consommables)
                    .HasColumnName("CONSOMMABLES");
            });

            modelBuilder.Entity<Soins>(entity =>
            {
                entity.HasKey(e => e.Soinsid);

                entity.ToTable("soins");

                entity.Property(e => e.Soinsid).HasColumnName("SOINSID");

                entity.Property(e => e.Affiliationid).HasColumnName("AFFILIATIONID");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORIE");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Fichisteid).HasColumnName("FICHISTEID");

                entity.Property(e => e.Ordonnanceid).HasColumnName("ORDONNANCEID");

                entity.Property(e => e.Urgence)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("URGENCE")
                    .IsFixedLength();

                entity.Property(e => e.Fin)
                    .HasMaxLength(10)
                    .HasColumnName("FIN");
            });

            modelBuilder.Entity<PassageSoin>(entity =>
            {
                entity.HasKey(e => e.PassageSoinsId);

                entity.ToTable("passage_soins");

                entity.Property(e => e.PassageSoinsId).HasColumnName("PASSAGE_SOINS_ID");

                entity.Property(e => e.SoinsId).HasColumnName("SOINS_ID");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE");

                entity.Property(e => e.AvoirSoinsId).HasColumnName("AVOIR_SOINS_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
