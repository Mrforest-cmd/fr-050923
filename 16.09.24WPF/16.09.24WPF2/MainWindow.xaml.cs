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

namespace _16._09._24WPF2
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
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double userSum = double.Parse(txtSum.Text);
                double userProc = double.Parse(txtProc.Text);
                double userCommission = double.Parse(txtCommission.Text);
                int userCount = int.Parse(txtCount.Text);

                double otvet = userSum;
                for (int i = 0; i < userCount; i++)
                {
                    otvet = otvet * (userProc - userCommission) / 100 + otvet;
                }

                txtResult.Text = otvet.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных. Пожалуйста, убедитесь, что все поля заполнены корректно.");
            }
        }
    }
}