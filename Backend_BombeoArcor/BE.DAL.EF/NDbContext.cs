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

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
