using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using WpfApp2.DBmodel; 

namespace WpfApp2
{
    public partial class ProductManagerWindow : Window
    {
        private List<Products> _products = new List<Products>();

        public ProductManagerWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var db = new DBmodel.ShopDBEntities()) 
            {
                _products = db.Products.ToList();
                ProductListBox.ItemsSource = _products;
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                
                Products newProduct = new Products
                {
                    ProductName = name,
                    Price = price
                };

                using (var db = new DBmodel.ShopDBEntities())
                {
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                }

                _products.Add(newProduct);
                ProductListBox.ItemsSource = null;
                ProductListBox.ItemsSource = _products;

                Debug.WriteLine(newProduct);

                NameTextBox.Clear();
                PriceTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректное значение цены.");
            }
        }
    }
}
