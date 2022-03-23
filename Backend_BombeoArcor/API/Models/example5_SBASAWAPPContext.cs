using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class example5_SBASAWAPPContext : DbContext
    {
        public example5_SBASAWAPPContext()
        {
        }

        public example5_SBASAWAPPContext(DbContextOptions<example5_SBASAWAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Instalador> Instalador { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Productsps> Productsps { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<ShoppCart> ShoppCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=wdb4.my-hosting-panel.com;Database=example5_SBASAWAPP;user id=example5_ADMIN;pwd=SistemasDeBombeoArcorSA2022_;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "example5_ADMIN");

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.ToTable("AspNetRoles", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "dbo");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.ToTable("AspNetUserLogins", "dbo");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.ToTable("AspNetUserRoles", "dbo");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.ToTable("AspNetUsers", "dbo");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("CATEGORIES", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("CATEGORY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("PK__FACTURA__F7D4C9C762CF882D");

                entity.ToTable("FACTURA", "dbo");

                entity.Property(e => e.Idfactura).HasColumnName("IDFACTURA");

                entity.Property(e => e.Descuento)
                    .HasColumnName("DESCUENTO")
                    .HasColumnType("money");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("IDUSUARIO")
                    .HasMaxLength(128);

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Numpago).HasColumnName("NUMPAGO");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<Instalador>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__INSTALAD__2A49584C89675C44");

                entity.ToTable("INSTALADOR", "dbo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory", "dbo");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("PRODUCTS", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Category).HasColumnName("CATEGORY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasColumnType("text");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__PRODUCTS__CATEGO__4AB81AF0");
            });

            modelBuilder.Entity<Productsps>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUCTSPS", "dbo");

                entity.Property(e => e.IdProduct).HasColumnName("ID_PRODUCT");

                entity.Property(e => e.IdSale).HasColumnName("ID_SALE");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCTSP__ID_PR__5BE2A6F2");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCTSP__ID_SA__5AEE82B9");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("SALES", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleTotal)
                    .HasColumnName("SALE_TOTAL")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ShoppCart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SHOPP_CART");

                entity.Property(e => e.IdProduct).HasColumnName("ID_PRODUCT");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasMaxLength(128);

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__SHOPP_CAR__ID_PR__6E01572D");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__SHOPP_CAR__ID_US__6D0D32F4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
