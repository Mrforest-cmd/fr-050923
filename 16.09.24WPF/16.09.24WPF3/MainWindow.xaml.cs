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

namespace _16._09._24WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentPlayer = "X";
        private int moveCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == null)
            {
                button.Content = currentPlayer;
                moveCount++;

                if (CheckForWinner())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    ResetGame();
                    return;
                }

                if (moveCount == 9)
                {
                    MessageBox.Show("It's a draw!");
                    ResetGame();
                    return;
                }

                currentPlayer = currentPlayer == "X" ? "O" : "X";
            }
        }

        private bool CheckForWinner()
        {
            if (Btn1.Content == Btn2.Content && Btn2.Content == Btn3.Content && Btn1.Content != null) return true;
            if (Btn4.Content == Btn5.Content && Btn5.Content == Btn6.Content && Btn4.Content != null) return true;
            if (Btn7.Content == Btn8.Content && Btn8.Content == Btn9.Content && Btn7.Content != null) return true;

            if (Btn1.Content == Btn4.Content && Btn4.Content == Btn7.Content && Btn1.Content != null) return true;
            if (Btn2.Content == Btn5.Content && Btn5.Content == Btn8.Content && Btn2.Content != null) return true;
            if (Btn3.Content == Btn6.Content && Btn6.Content == Btn9.Content && Btn3.Content != null) return true;

            if (Btn1.Content == Btn5.Content && Btn5.Content == Btn9.Content && Btn1.Content != null) return true;
            if (Btn3.Content == Btn5.Content && Btn5.Content == Btn7.Content && Btn3.Content != null) return true;

            return false;
        }

        private void ResetGame()
        {
            Btn1.Content = null;
            Btn2.Content = null;
            Btn3.Content = null;
            Btn4.Content = null;
            Btn5.Content = null;
            Btn6.Content = null;
            Btn7.Content = null;
            Btn8.Content = null;
            Btn9.Content = null;

            currentPlayer = "X";
            moveCount = 0;
        }
    }
}