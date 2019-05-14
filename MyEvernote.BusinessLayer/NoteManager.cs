using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
    public class NoteManager
    {
        private readonly Repository<Note> _repoNote = new Repository<Note>();

        public List<Note> GetAllNotes()
        {
            return _repoNote.List();
        }
    }
}
