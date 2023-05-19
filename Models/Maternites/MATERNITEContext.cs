using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LYRA.Models.Maternites
{
    public partial class MATERNITEContext : DbContext
    {

        public MATERNITEContext(DbContextOptions<MATERNITEContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EchoMaternite> EchoMaternites { get; set; } = null!;

        public virtual DbSet<Maternite> Maternites { get; set; } = null!;
        public virtual DbSet<AvoirEcho> AvoirEchoes { get; set; } = null!;
        public virtual DbSet<AvoirMaternite> AvoirMaternites { get; set; } = null!;
        public virtual DbSet<Bebe> Bebes { get; set; } = null!;
        public virtual DbSet<Cpn> Cpns { get; set; } = null!;
        public virtual DbSet<Mere> Meres { get; set; } = null!;
        public virtual DbSet<VaccinEnfant> VaccinEnfants { get; set; } = null!;
        public virtual DbSet<VaccinMere> VaccinMeres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EchoMaternite>(entity =>
            {
                entity.HasKey(e => e.EhoMaterniteId)
                    .HasName("PK_ECHO_MATERNITE");

                entity.ToTable("echo_maternite");

                entity.Property(e => e.EhoMaterniteId).HasColumnName("EHO_MATERNITE_ID");

                entity.Property(e => e.AvoirEchoId).HasColumnName("AVOIR_ECHO_ID");

                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");
                entity.Property(e => e.MaterniteId).HasColumnName("MATERNITE_ID");

                entity.Property(e => e.PerimetreBrachiale)
                    .HasMaxLength(128)
                    .HasColumnName("PERIMETRE_BRACHIALE");

                entity.Property(e => e.PerimetreCranienne)
                    .HasMaxLength(128)
                    .HasColumnName("PERIMETRE_CRANIENNE");

                entity.Property(e => e.PerimetreThoracique)
                    .HasMaxLength(128)
                    .HasColumnName("PERIMETRE_THORACIQUE");

                entity.Property(e => e.QuantiteLiquideAmniotique)
                    .HasMaxLength(128)
                    .HasColumnName("QUANTITE_LIQUIDE_AMNIOTIQUE");

                entity.Property(e => e.Statut)
                    .HasMaxLength(32)
                    .HasColumnName("STATUT")
                    .IsFixedLength();

                entity.Property(e => e.TypeLiquideAmniotique)
                    .HasMaxLength(128)
                    .HasColumnName("TYPE_LIQUIDE_AMNIOTIQUE");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.BatementCoeur)
                    .HasMaxLength(10)
                    .HasColumnName("BATEMENT_COEUR");

                entity.Property(e => e.MouvementActif)
                    .HasMaxLength(10)
                    .HasColumnName("MOUVEMENT_ACTIF");

                entity.Property(e => e.EtatBebe)
                    .HasMaxLength(10)
                    .HasColumnName("ETAT_BEBE");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");
            });

            modelBuilder.Entity<AvoirEcho>(entity =>
            {
                entity.ToTable("avoir_echo");

                entity.Property(e => e.AvoirEchoId).HasColumnName("AVOIR_ECHO_ID");

                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");
                entity.Property(e => e.MaterniteId).HasColumnName("MATERNITE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.EchoId).HasColumnName("ECHO_ID");

                entity.Property(e => e.LaboratoireId).HasColumnName("LABORATOIRE_ID");

                entity.Property(e => e.VaccinBebeId).HasColumnName("VACCIN_BEBE_ID");

                entity.Property(e => e.VaccinMereId).HasColumnName("VACCIN_MERE_ID");
            });

            modelBuilder.Entity<Maternite>(entity =>
            {
                entity.ToTable("maternite");

                entity.Property(e => e.MaterniteId).HasColumnName("MATERNITE_ID");

                entity.Property(e => e.AgeMere).HasColumnName("AGE_MERE");

                entity.Property(e => e.AvoirMaterniteId).HasColumnName("AVOIR_MATERNITE_ID");
                entity.Property(e => e.Affiliationid).HasColumnName("AFFILIATION_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DateDernierRegle)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_DERNIER_REGLE");

                entity.Property(e => e.DateProbableAccouchement)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_PROBABLE_ACCOUCHEMENT");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.Grossesse)
                    .HasMaxLength(10)
                    .HasColumnName("GROSSESSE")
                    .IsFixedLength();

                entity.Property(e => e.NombreAccouchement).HasColumnName("NOMBRE_ACCOUCHEMENT");

                entity.Property(e => e.NumeroBebe).HasColumnName("NUMERO_BEBE");

                entity.Property(e => e.TypeAccouchement)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE_ACCOUCHEMENT")
                    .IsFixedLength();

                entity.Property(e => e.Categorie)
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORIE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<AvoirMaternite>(entity =>
            {
                entity.ToTable("avoir_maternite");

                entity.Property(e => e.AvoirMaterniteId).HasColumnName("AVOIR_MATERNITE_ID");

                entity.Property(e => e.Commentaire)
                    .HasMaxLength(255)
                    .HasColumnName("COMMENTAIRE");

                entity.Property(e => e.Etat)
                    .HasMaxLength(50)
                    .HasColumnName("ETAT");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.Validation).HasColumnName("VALIDATION");
            });

            modelBuilder.Entity<Bebe>(entity =>
            {
                entity.ToTable("bebe");

                entity.Property(e => e.BebeId).HasColumnName("BEBE_ID");

                entity.Property(e => e.BatementCoeur)
                    .HasMaxLength(32)
                    .HasColumnName("BATEMENT_COEUR")
                    .IsFixedLength();

                entity.Property(e => e.Commentaire)
                    .HasMaxLength(255)
                    .HasColumnName("COMMENTAIRE")
                    .IsFixedLength();

                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");

                entity.Property(e => e.Etat)
                    .HasMaxLength(32)
                    .HasColumnName("ETAT")
                    .IsFixedLength();

                entity.Property(e => e.MouvementActif)
                    .HasMaxLength(32)
                    .HasColumnName("MOUVEMENT_ACTIF")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cpn>(entity =>
            {
                entity.HasKey(e => new { e.CpnId, e.Date })
                    .HasName("PK_CPN");

                entity.ToTable("cpn");

                entity.Property(e => e.CpnId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CPN_ID");

                entity.Property(e => e.MaterniteId)
                    .HasColumnName("MATERNITE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.NumeroCpn).HasColumnName("NUMERO_CPN");
            });

            modelBuilder.Entity<Mere>(entity =>
            {
                entity.ToTable("mere");

                entity.Property(e => e.MereId).HasColumnName("MERE_ID");

                entity.Property(e => e.BassinPelvienne)
                    .HasMaxLength(32)
                    .HasColumnName("BASSIN_PELVIENNE")
                    .IsFixedLength();

                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");

                entity.Property(e => e.HauteurUterine)
                    .HasMaxLength(32)
                    .HasColumnName("HAUTEUR_UTERINE")
                    .IsFixedLength();

                entity.Property(e => e.Ictere)
                    .HasMaxLength(128)
                    .HasColumnName("ICTERE");

                entity.Property(e => e.Leucorrhee)
                    .HasMaxLength(32)
                    .HasColumnName("LEUCORRHEE")
                    .IsFixedLength();

                entity.Property(e => e.Mamelon)
                    .HasMaxLength(128)
                    .HasColumnName("MAMELON");

                entity.Property(e => e.Oeoedeme)
                    .HasMaxLength(32)
                    .HasColumnName("OEOEDEME")
                    .IsFixedLength();

                entity.Property(e => e.Taille)
                    .HasMaxLength(32)
                    .HasColumnName("TAILLE")
                    .IsFixedLength();

                entity.Property(e => e.Varice)
                    .HasMaxLength(32)
                    .HasColumnName("VARICE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VaccinEnfant>(entity =>
            {
                entity.ToTable("vaccin_enfant");

                entity.Property(e => e.VaccinEnfantId)
                    .ValueGeneratedNever()
                    .HasColumnName("VACCIN_ENFANT_ID");

                entity.Property(e => e.CpnId).HasColumnName("CPN_ID");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Etat)
                    .HasMaxLength(32)
                    .HasColumnName("ETAT")
                    .IsFixedLength();

                entity.Property(e => e.NomVaccin)
                    .HasMaxLength(128)
                    .HasColumnName("NOM_VACCIN");
            });

            modelBuilder.Entity<VaccinMere>(entity =>
            {
                entity.ToTable("vaccin_mere");

                entity.Property(e => e.VaccinMereId).HasColumnName("VACCIN_MERE_ID");

                entity.Property(e => e.MaterniteId).HasColumnName("MATERNITE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Etat)
                    .HasMaxLength(128)
                    .HasColumnName("ETAT");

                entity.Property(e => e.FichisteId).HasColumnName("FICHISTE_ID");

                entity.Property(e => e.NomVaccin)
                    .HasMaxLength(128)
                    .HasColumnName("NOM_VACCIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
