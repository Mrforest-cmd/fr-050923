using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _19._09._24WPF
{
    public partial class NotesWindow : Window
    {
        private ObservableCollection<Note> notes;

        public NotesWindow()
        {
            InitializeComponent();
            notes = new ObservableCollection<Note>();
            notesListBox.ItemsSource = notes;
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            Note newNote = new Note { Title = "Новая заметка", Content = "" };
            notes.Add(newNote);
            notesListBox.SelectedItem = newNote;
            UpdateNoteView(newNote);
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                notes.Remove((Note)notesListBox.SelectedItem);
                ClearNoteView();
            }
        }

        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                Note selectedNote = (Note)notesListBox.SelectedItem;
                selectedNote.Title = titleTextBox.Text;
                selectedNote.Content = contentTextBox.Text;
                notesListBox.Items.Refresh();
                UpdateNoteView(selectedNote);
            }
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notesListBox.SelectedItem != null)
            {
                Note selectedNote = (Note)notesListBox.SelectedItem;
                UpdateNoteView(selectedNote);
            }
            else
            {
                ClearNoteView();
            }
        }

        private void UpdateNoteView(Note note)
        {
            titleTextBox.Text = note.Title;
            contentTextBox.Text = note.Content;
            viewTextBlock.Text = note.Content;
        }

        private void ClearNoteView()
        {
            titleTextBox.Text = string.Empty;
            contentTextBox.Text = string.Empty;
            viewTextBlock.Text = string.Empty;
        }
    }
}
