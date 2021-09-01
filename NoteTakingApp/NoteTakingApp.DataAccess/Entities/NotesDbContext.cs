using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NoteTakingApp.DataAccess.Entities
{
    public partial class NotesDbContext : DbContext
    {
        public NotesDbContext()
        {
        }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<NoteTag> NoteTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<NoteTag>(entity =>
            {
                entity.HasKey(e => new { e.NoteId, e.Name })
                    .HasName("PK__NoteTags__8DF96D108293576C");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.NoteTags)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__NoteTags__Name__60A75C0F");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.NoteTags)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK__NoteTags__NoteId__5FB337D6");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Tags__737584F72B9DE1A0");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
