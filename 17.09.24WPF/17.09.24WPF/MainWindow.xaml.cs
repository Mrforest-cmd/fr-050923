using Microsoft.Win32;
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

namespace _17._09._24WPF
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Здесь будет проверка логина и пароля
            if (AuthenticateUser(username, password))
            {
                OpenAppropriateWindow(username);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        private void OpenAppropriateWindow(string username)
        {
            Window window;
            switch (username.ToLower())
            {
                case "склад":
                    window = new WarehouseWindow();
                    break;
                case "админ":
                    window = new AdminWindow();
                    break;
                case "продавец":
                    window = new SellerWindow();
                    break;
                default:
                    MessageBox.Show("Неизвестный тип пользователя");
                    return;
            }
            window.Show();
            this.Close();
        }

        private bool AuthenticateUser(string username, string password)
        {
            return true;
        }
    }
}