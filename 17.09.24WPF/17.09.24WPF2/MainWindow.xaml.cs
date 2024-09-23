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
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _17._09._24WPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product> products = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = products;
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    products.Clear();

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string name = parts[0].Trim();
                            int quantity = int.Parse(parts[1].Trim());
                            decimal price = decimal.Parse(parts[2].Trim());

                            AddOrUpdateProduct(name, quantity, price);
                        }
                    }

                    RefreshDataGrid();
                    StatusTextBlock.Text = $"Загружено и обработано {products.Count} товаров";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("Сначала загрузите файл с товарами или добавьте товары вручную.");
                return;
            }

            if (!decimal.TryParse(ProfitPercentageTextBox.Text, out decimal profitPercentage))
            {
                MessageBox.Show("Введите корректный процент прибыли.");
                return;
            }

            foreach (var product in products)
            {
                product.PriceWithProfit = product.Price * (1 + profitPercentage / 100);
            }

            RefreshDataGrid();
            StatusTextBlock.Text = $"Обработано {products.Count} товаров";
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateProductInput())
            {
                string name = NameTextBox.Text;
                int quantity = int.Parse(QuantityTextBox.Text);
                decimal price = decimal.Parse(PriceTextBox.Text);

                AddOrUpdateProduct(name, quantity, price);
                RefreshDataGrid();
                ClearProductInputs();
                StatusTextBlock.Text = "Товар добавлен или обновлен";
            }
        }

        private void AddOrUpdateProduct(string name, int quantity, decimal price)
        {
            var existingProduct = products.FirstOrDefault(p => p.Name == name);
            if (existingProduct != null)
            {
                int newTotalQuantity = existingProduct.Quantity + quantity;
                decimal newTotalValue = (existingProduct.Quantity * existingProduct.Price) + (quantity * price);
                existingProduct.Quantity = newTotalQuantity;
                existingProduct.Price = newTotalValue / newTotalQuantity;
            }
            else
            {
                products.Add(new Product { Name = name, Quantity = quantity, Price = price });
            }
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct != null && ValidateProductInput())
            {
                string name = NameTextBox.Text;
                int quantity = int.Parse(QuantityTextBox.Text);
                decimal price = decimal.Parse(PriceTextBox.Text);

                products.Remove(selectedProduct);
                AddOrUpdateProduct(name, quantity, price);

                RefreshDataGrid();
                StatusTextBlock.Text = "Товар обновлен";
            }
            else
            {
                MessageBox.Show("Выберите товар для обновления");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                products.Remove(selectedProduct);
                RefreshDataGrid();
                ClearProductInputs();
                StatusTextBlock.Text = "Товар удален";
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления");
            }
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                NameTextBox.Text = selectedProduct.Name;
                QuantityTextBox.Text = selectedProduct.Quantity.ToString();
                PriceTextBox.Text = selectedProduct.Price.ToString();
            }
        }

        private bool ValidateProductInput()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                !int.TryParse(QuantityTextBox.Text, out _) ||
                !decimal.TryParse(PriceTextBox.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для товара");
                return false;
            }
            return true;
        }

        private void ClearProductInputs()
        {
            NameTextBox.Clear();
            QuantityTextBox.Clear();
            PriceTextBox.Clear();
        }

        private void RefreshDataGrid()
        {
            ProductsDataGrid.ItemsSource = null;
            ProductsDataGrid.ItemsSource = products;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithProfit { get; set; }
    }
}