using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server
{
    public partial class jonathanmccaffreyContext : DbContext
    {
        public jonathanmccaffreyContext()
        {
        }

        public jonathanmccaffreyContext(DbContextOptions<jonathanmccaffreyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDos { get; set; } = null!;
        public virtual DbSet<ToDoStatus> ToDoStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Ex");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ToDo", "ex");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StatusKey).HasMaxLength(50);

                entity.HasOne(d => d.StatusKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StatusKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusKey_ToDoStatus_Key");
            });

            modelBuilder.Entity<ToDoStatus>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("ToDoStatus", "ex");

                entity.Property(e => e.Key).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
