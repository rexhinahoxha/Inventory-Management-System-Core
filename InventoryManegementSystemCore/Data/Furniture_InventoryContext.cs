using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InventoryManegementSystemCore.Model;
using Microsoft.Extensions.Configuration;


namespace InventoryManegementSystemCore.Data
{
    public partial class Furniture_InventoryContext : DbContext
    {
        public Furniture_InventoryContext()
        {
        }

        public Furniture_InventoryContext(DbContextOptions<Furniture_InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Users> Users { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer("user Id=fuser; password=Furniture!2;Pooling=false;Data Source=(LocalDB)\\LocalDB;Initial Catalog=Furniture_Inventory;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdCatergory).HasColumnName("idCatergory");

                entity.Property(e => e.IdSales).HasColumnName("idSales");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("ImgURL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StareRating).HasColumnType("decimal(18, 1)");

                entity.HasOne(d => d.IdSalesNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdSales)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.IdSales);

                entity.Property(e => e.DateOfSale).HasColumnType("datetime");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.ProductList)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Sales_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
