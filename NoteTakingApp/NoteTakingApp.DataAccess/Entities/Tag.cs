using System;
using System.Collections.Generic;

#nullable disable

namespace NoteTakingApp.DataAccess.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            NoteTags = new HashSet<NoteTag>();
        }

        public string Name { get; set; }

        public virtual ICollection<NoteTag> NoteTags { get; set; }
    }
}
