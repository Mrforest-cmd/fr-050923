using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _19._09._24WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NotesButton_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow notesWindow = new NotesWindow();
            notesWindow.Show();
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow calendarWindow = new CalendarWindow();
            calendarWindow.Show();
        }

        private void RemindersButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функционал напоминаний пока не реализован.");
        }
    }

    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}