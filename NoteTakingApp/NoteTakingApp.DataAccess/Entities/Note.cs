using System;
using System.Collections.Generic;

#nullable disable

namespace NoteTakingApp.DataAccess.Entities
{
    public partial class Note
    {
        public Note()
        {
            NoteTags = new HashSet<NoteTag>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<NoteTag> NoteTags { get; set; }
    }
}
