using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TableBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> products;

        public MainWindow()
        {
            InitializeComponent();

            using (var context = new ShopContext())
            {
                products = new ObservableCollection<Product>(context.Products.ToList());
            }

            dataGrid.ItemsSource = products;

            products.Add(new Product
            {
                Name = "Socks",
                Price = 1000,
                Count = 123
            });
        }

        private void OnRowDeleted(object sender, KeyEventArgs e)
        {
            var currentRow = (DataGridRow)dataGrid
                .ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            var product = products[dataGrid.SelectedIndex];
            if (e.Key == Key.Delete && !currentRow.IsEditing)
            {
                using (var context = new ShopContext())
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                products.Remove(product);
            }
            else if(e.Key == Key.Enter && product != null)
            {
                using (var context = new ShopContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            var currentRow = (DataGridRow)dataGrid
                .ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            var product = products[dataGrid.SelectedIndex];
            if (!currentRow.IsEditing)
            {
                using (var context = new ShopContext())
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                //products.Remove(product);
            }
        }

        private void InsertRow(object sender, RoutedEventArgs e)
        {
            var currentRow = (DataGridRow)dataGrid
                .ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            var product = products[dataGrid.SelectedIndex];
            if (!currentRow.IsEditing)
            {
                using (var context = new ShopContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
        }

        private void UpdateRow(object sender, RoutedEventArgs e)
        {
            var currentRow = (DataGridRow)dataGrid
                .ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            var product = products[dataGrid.SelectedIndex];
            if (!currentRow.IsEditing)
            {
                using (var context = new ShopContext())
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
