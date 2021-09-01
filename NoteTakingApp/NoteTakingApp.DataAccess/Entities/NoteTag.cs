using System;
using System.Collections.Generic;

#nullable disable

namespace NoteTakingApp.DataAccess.Entities
{
    public partial class NoteTag
    {
        public int NoteId { get; set; }
        public string Name { get; set; }

        public virtual Tag NameNavigation { get; set; }
        public virtual Note Note { get; set; }
    }
}
