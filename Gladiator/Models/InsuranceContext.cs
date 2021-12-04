using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gladiator.Models
{
    public partial class InsuranceContext : DbContext
    {
        public InsuranceContext()
        {
        }

        public InsuranceContext(DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<ClaimAmount> ClaimAmounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PremiumAmount> PremiumAmounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Insurance;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.ClaimNo)
                    .HasName("PK__Claim__EF2E7A04D44CB1EC");

                entity.ToTable("Claim");

                entity.Property(e => e.ClaimNo).ValueGeneratedNever();

                entity.Property(e => e.Approval)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimDate).HasColumnType("date");

                entity.Property(e => e.ReasonForClaim)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyNoNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PolicyNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Claim__PolicyNo__5DCAEF64");

                entity.HasOne(d => d.ReasonForClaimNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.ReasonForClaim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Claim__ReasonFor__5EBF139D");
            });

            modelBuilder.Entity<ClaimAmount>(entity =>
            {
                entity.HasKey(e => e.ReasonForClaim)
                    .HasName("PK__ClaimAmo__90B7448B5AFC2923");

                entity.ToTable("ClaimAmount");

                entity.Property(e => e.ReasonForClaim)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.PolicyNo)
                    .HasName("PK__Policy__2E1321972E839130");

                entity.ToTable("Policy");

                entity.Property(e => e.PolicyNo).ValueGeneratedNever();

                entity.Property(e => e.ChassisNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrivingLicence)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EngineNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlanDuration)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.VehicleManufacturer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleModel)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleRegistrationNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__Customer__59FA5E80");

                entity.HasOne(d => d.VehicleModelNavigation)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.VehicleModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__VehicleM__5AEE82B9");
            });

            modelBuilder.Entity<PremiumAmount>(entity =>
            {
                entity.HasKey(e => e.VehicleModel)
                    .HasName("PK__PremiumA__D944058C94449E2D");

                entity.ToTable("PremiumAmount");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlanType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumAmount1).HasColumnName("PremiumAmount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
