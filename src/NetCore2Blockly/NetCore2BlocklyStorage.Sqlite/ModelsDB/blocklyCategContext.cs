using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    internal partial class blocklyCategContext : DbContext
    {
        public blocklyCategContext()
        {
        }

        public blocklyCategContext(DbContextOptions<blocklyCategContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blocks>(entity =>
            {
                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blocks_Category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("FK_Category_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
