using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoteTakingApp.DataAccess.Entities
{
    //partial class NotesDbContext
    //{
    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<NoteTag>(entity =>
    //        {
    //            entity.HasOne(d => d.NameNavigation)
    //                .WithMany(t => t.NoteTags)
    //                .HasForeignKey(d => d.Name)
    //                .HasConstraintName("FK__NoteTags__Name__60A75C0F");

    //            entity.HasOne(d => d.Note)
    //                .WithMany(t => t.NoteTags)
    //                .HasForeignKey(d => d.NoteId)
    //                .HasConstraintName("FK__NoteTags__NoteId__5FB337D6");
    //        });
    //    }
    //}

    //partial class Note
    //{
    //    public ICollection<NoteTag> NoteTags { get; set; } = new HashSet<NoteTag>();
    //}

    //partial class Tag
    //{
    //    public ICollection<NoteTag> NoteTags { get; set; } = new HashSet<NoteTag>();
    //}
}
