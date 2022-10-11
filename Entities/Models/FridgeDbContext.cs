using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public partial class FridgeDbContext : DbContext
    {
        public FridgeDbContext()
        {
        }

        public FridgeDbContext(DbContextOptions<FridgeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fridge> Fridges { get; set; } = null!;
        public virtual DbSet<FridgeModel> FridgeModels { get; set; } = null!;
        public virtual DbSet<FridgeProduct> FridgeProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=GLEBGOL;Database=FridgeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fridge>(entity =>
            {
                entity.ToTable("fridge");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(50)
                    .HasColumnName("owner_name");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Fridges)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fridge_fridge_model");
            });

            modelBuilder.Entity<FridgeModel>(entity =>
            {
                entity.ToTable("fridge_model");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<FridgeProduct>(entity =>
            {
                entity.ToTable("fridge_products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FridgeId).HasColumnName("fridge_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Fridge)
                    .WithMany(p => p.FridgeProducts)
                    .HasForeignKey(d => d.FridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fridge_products_fridge");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FridgeProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fridge_products_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DefaultQuantity).HasColumnName("default_quantity");

                entity.Property(e => e.FridgeId).HasColumnName("fridge_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
