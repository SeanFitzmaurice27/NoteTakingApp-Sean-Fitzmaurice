using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteTakingApp.Domain
{
    public class NoteService
    {
        private readonly IRepository _repo;

        public NoteService(IRepository repo)
        {
            _repo = repo;
        }

        public int RemoveDuplicateNotes()
        {
            return 0;
        }
    }
}
