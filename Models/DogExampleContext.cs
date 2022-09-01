using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DogExample.Models
{
    public partial class DogExampleContext : DbContext
    {
        public DogExampleContext()
        {
        }

        public DogExampleContext(DbContextOptions<DogExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breed> Breeds { get; set; } = null!;
        public virtual DbSet<Dog> Dogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local)\\SQL2017;Initial Catalog=DogExample;User ID=sa;Password=Epicor123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("Breed");

                entity.Property(e => e.BreedId)
                    .ValueGeneratedNever()
                    .HasColumnName("BreedID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("Dog");

                entity.Property(e => e.DogId)
                    .ValueGeneratedNever()
                    .HasColumnName("DogID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BreedId).HasColumnName("BreedID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DogNavigation)
                    .WithOne(p => p.Dog)
                    .HasForeignKey<Dog>(d => d.DogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DogBreed_BreedID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
