using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppC21.Models;

namespace ToDoAppC21.Controllers
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } 
            = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            //Get the folder where the notes are saved
            var appDirPath = FileSystem.AppDataDirectory;
            var notes = Directory
                .EnumerateFiles(appDirPath, "*.notes.txt")
                .Select(filename => new Note()
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })
                .OrderBy(note => note.Date);

            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
