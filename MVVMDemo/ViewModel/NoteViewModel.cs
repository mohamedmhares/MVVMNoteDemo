using MVVMDemo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMDemo.ViewModel
{
    public partial class NoteViewModel : ObservableObject
    {
        //Fields
        [ObservableProperty]
         string noteTitle;
        [ObservableProperty]
        string noteDescription;
        [ObservableProperty]
         Note selectedNotes;
        [ObservableProperty]
         ObservableCollection<Note> noteCollection;



      


        public NoteViewModel() 
        {
            NoteCollection = new ObservableCollection<Note>();


        }
        [RelayCommand]
         void EditNotes()
        {
            if (SelectedNotes != null)
            {
                foreach (Note note in NoteCollection.ToList()) 
                {
                    if (note == SelectedNotes) {
                        var newNote = new Note
                        {
                            Id = note.Id,
                            Title = note.Title,
                            Description = note.Description,
                        };


                        NoteCollection.Remove(note);
                        NoteCollection.Add(newNote);
                        
                    }
                }
            }
        }

        [RelayCommand]
        void DeleteNotes()
        {
            if (SelectedNotes != null)
            {
                NoteCollection.Remove(SelectedNotes);
                //Rest Values
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }

        [RelayCommand]
        void AddNotes()
        {
            int newId = NoteCollection.Count > 0 ? NoteCollection.Max(x => x.Id) + 1 : 1;
            var note = new Note
            {
                Id = newId,
                Title = NoteTitle,
                Description = NoteDescription
            };
            NoteCollection.Add(note);

            //RestValues
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }
    }
}
