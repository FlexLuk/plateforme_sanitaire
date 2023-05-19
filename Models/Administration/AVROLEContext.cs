using Microsoft.EntityFrameworkCore;

namespace LYRA.Models.Administration
{
    public partial class AVROLEContext : DbContext
    {

        public AVROLEContext(DbContextOptions<AVROLEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvoirRole> AvoirRoles { get; set; } = null!;
        public virtual DbSet<Urole> Uroles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvoirRole>(entity =>
            {
                entity.ToTable("avoir_role");

                entity.Property(e => e.Avoirroleid)
                     .HasColumnName("AVOIRROLEID");

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");

                entity.Property(e => e.Utilisateurid).HasColumnName("UTILISATEURID");
            });

            modelBuilder.Entity<Urole>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("PK_ROLE");

                entity.ToTable("urole");

                entity.Property(e => e.Roleid)
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
