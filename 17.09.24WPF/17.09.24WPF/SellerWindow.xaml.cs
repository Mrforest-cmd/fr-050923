using System;
using System.Collections.Generic;
using System.Windows;

namespace _17._09._24WPF
{
    public partial class SellerWindow : Window
    {
        private List<Product> products;

        public SellerWindow(List<Product> products)
        {
            InitializeComponent();
            this.products = products;
            ProductsDataGrid.ItemsSource = this.products;
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар.");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное количество.");
                return;
            }

            if (quantity > selectedProduct.Quantity)
            {
                MessageBox.Show("Недостаточно товара на складе.");
                return;
            }

            selectedProduct.Quantity -= quantity;
            ProductsDataGrid.Items.Refresh();
            QuantityTextBox.Clear();
            MessageBox.Show($"Продано {quantity} единиц товара '{selectedProduct.Name}'.");
        }
    }
}