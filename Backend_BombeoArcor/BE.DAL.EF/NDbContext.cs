using System;
using System.Collections.Generic;
using System.Text;
using BE.DAL.DO.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BE.DAL.EF
{
    public partial class NDbContext: DbContext
    {
        public NDbContext()
        {
        }
        public NDbContext(DbContextOptions<NDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categories> Categories { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Sales> Sales { get; set; }

        public virtual DbSet<Instalador> Instalador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("SALES", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleTotal).HasColumnName("SALE_TOTAL");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("PRODUCTS", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("PRICE");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .IsUnicode(false);

                entity.Property(e => e.Category).HasColumnName("CATEGORY");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");
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



            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
