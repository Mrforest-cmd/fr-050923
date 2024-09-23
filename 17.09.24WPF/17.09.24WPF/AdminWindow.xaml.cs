using System;
using System.Collections.Generic;
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

namespace _17._09._24WPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(List<Product> products)
        {
            InitializeComponent();
            CalculateAndDisplayStatistics(products);
        }

        private void CalculateAndDisplayStatistics(List<Product> products)
        {
            int totalProducts = products.Count;
            int totalQuantity = products.Sum(p => p.Quantity);
            decimal totalValue = products.Sum(p => p.Quantity * p.Price);
            decimal averagePrice = totalQuantity > 0 ? totalValue / totalQuantity : 0;

            TotalProductsTextBlock.Text = $"Общее количество уникальных товаров: {totalProducts}";
            TotalQuantityTextBlock.Text = $"Общее количество всех товаров: {totalQuantity}";
            TotalValueTextBlock.Text = $"Общая стоимость всех товаров: {totalValue:C2}";
            AveragePriceTextBlock.Text = $"Средняя цена товара: {averagePrice:C2}";

            var mostExpensive = products.OrderByDescending(p => p.Price).Take(5);
            MostExpensiveListBox.ItemsSource = mostExpensive.Select(p => $"{p.Name}: {p.Price:C2}");

            var mostQuantity = products.OrderByDescending(p => p.Quantity).Take(5);
            MostQuantityListBox.ItemsSource = mostQuantity.Select(p => $"{p.Name}: {p.Quantity}");
        }

    }
}
