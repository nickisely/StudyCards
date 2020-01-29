using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudyCards.Sql.Entities
{
    public partial class StudyCardsContext : DbContext
    {
        public StudyCardsContext()
        {
        }

        public StudyCardsContext(DbContextOptions<StudyCardsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<StudyCard> StudyCard { get; set; }
        public virtual DbSet<SubGroup> SubGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudyCards;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Category");
            });

            modelBuilder.Entity<StudyCard>(entity =>
            {
                entity.Property(e => e.Answer).IsRequired();

                entity.Property(e => e.Question).IsRequired();

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.StudyCard)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudyCard_SubGroup");
            });

            modelBuilder.Entity<SubGroup>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubGroup_Group");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
