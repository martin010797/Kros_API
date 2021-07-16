using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api_Firma.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BelongsTo> BelongsTos { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3SVE3LJ\\SQLEXPRESS;Initial Catalog=Structure_of_company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BelongsTo>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BelongsTos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BelongsTo__emplo__2E1BDC42");

                entity.HasOne(d => d.Structure)
                    .WithMany(p => p.BelongsTos)
                    .HasForeignKey(d => d.StructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BelongsTo__struc__2F10007B");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.Degree).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.HasKey(e => e.StructureCode)
                    .HasName("PK__Structur__155F8CA672D007E7");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.Structures)
                    .HasForeignKey(d => d.BossId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Structure__bossI__2A4B4B5E");

                entity.HasOne(d => d.UpperStructure)
                    .WithMany(p => p.InverseUpperStructure)
                    .HasForeignKey(d => d.UpperStructureId)
                    .HasConstraintName("FK__Structure__upper__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
