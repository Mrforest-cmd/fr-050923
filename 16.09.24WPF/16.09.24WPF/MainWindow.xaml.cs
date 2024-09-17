using System.Data;
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

namespace _16._09._24WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DisplayTextBox.Text += button.Content.ToString();
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(DisplayTextBox.Text))
            {
                string lastChar = DisplayTextBox.Text[DisplayTextBox.Text.Length - 1].ToString();
                if (lastChar != " " && !IsOperator(lastChar))
                {
                    DisplayTextBox.Text += " " + button.Content.ToString() + " ";
                }
                else if (IsOperator(lastChar))
                {
                    return;
                }
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = DisplayTextBox.Text;
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                DisplayTextBox.Text = result.ToString();
            }
            catch (Exception)
            {
                DisplayTextBox.Text =  $"Ошибка: {e.ToString()}";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = string.Empty;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(DisplayTextBox.Text))
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Substring(0, DisplayTextBox.Text.Length - 1);
            }
        }

        private bool IsOperator(string character)
        {
            return character == "+" || character == "-" || character == "*" || character == "/" ;
        }
    }
}