using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductManagment.Models
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSet> ProductSets { get; set; }
        public virtual DbSet<Tab1> Tab1s { get; set; }
        public virtual DbSet<Tab2> Tab2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Database=Product;user id=sa; password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NameData)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nameData");
            });

            modelBuilder.Entity<ProductSet>(entity =>
            {
                entity.ToTable("productSet");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nameinfo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nameinfo");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSets)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__productSe__produ__5070F446");
            });

            modelBuilder.Entity<Tab1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tab1");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.NameData)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nameData");
            });

            modelBuilder.Entity<Tab2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tab2");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.NameData)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nameData");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
