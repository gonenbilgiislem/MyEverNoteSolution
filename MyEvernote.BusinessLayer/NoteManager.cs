using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyEvernote.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> _repo_note = new Repository<Note>();

        public List<Note> GetAllNotes()
        {
            return _repo_note.List();
        }  
        
        public IQueryable<Note> GetAllNotesQueryable()
        {
            return _repo_note.ListQueryable();
        }
    }
}
