using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _16._09._24WPF3
{
    public partial class MainWindow : Window
    {
        private string currentPlayer = "X";
        private int moveCount = 0;
        private bool isPlayerVsBot = false;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            DisableGameButtons();
        }

        private void BtnPlayerVsPlayer_Click(object sender, RoutedEventArgs e)
        {
            isPlayerVsBot = false;
            ResetGame();
            EnableGameButtons();
        }

        private void BtnPlayerVsBot_Click(object sender, RoutedEventArgs e)
        {
            isPlayerVsBot = true;
            ResetGame();
            EnableGameButtons();
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
                    MessageBox.Show($"Гравець {currentPlayer} переміг!");
                    ResetGame();
                    return;
                }
                if (moveCount == 9)
                {
                    MessageBox.Show("Нічия!");
                    ResetGame();
                    return;
                }
                currentPlayer = currentPlayer == "X" ? "O" : "X";

                if (isPlayerVsBot && currentPlayer == "O")
                {
                    MakeBotMove();
                }
            }
        }

        private void MakeBotMove()
        {
            var emptyButtons = new[] { Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9 }
                .Where(b => b.Content == null)
                .ToList();

            if (emptyButtons.Any())
            {
                var randomButton = emptyButtons[random.Next(emptyButtons.Count)];
                randomButton.Content = currentPlayer;
                moveCount++;

                if (CheckForWinner())
                {
                    MessageBox.Show($"Бот переміг!");
                    ResetGame();
                    return;
                }
                if (moveCount == 9)
                {
                    MessageBox.Show("Нічия!");
                    ResetGame();
                    return;
                }
                currentPlayer = "X";
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

        private void EnableGameButtons()
        {
            Btn1.IsEnabled = true;
            Btn2.IsEnabled = true;
            Btn3.IsEnabled = true;
            Btn4.IsEnabled = true;
            Btn5.IsEnabled = true;
            Btn6.IsEnabled = true;
            Btn7.IsEnabled = true;
            Btn8.IsEnabled = true;
            Btn9.IsEnabled = true;
        }

        private void DisableGameButtons()
        {
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
            Btn5.IsEnabled = false;
            Btn6.IsEnabled = false;
            Btn7.IsEnabled = false;
            Btn8.IsEnabled = false;
            Btn9.IsEnabled = false;
        }
    }
}