using System.Collections.Generic;

namespace NoteTakingApp.Domain
{
    public interface IRepository
    {
        Note AddNote(Note note);
        List<Note> GetNotes();
        List<Note> GetNotesWithTag(string tag);
    }
}
