using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SPORTs.Model;

namespace SPORTs.View
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        Product product = new Product();
        public Catalog()
        {
            InitializeComponent();
            FrameForOrder.Navigate(product);
        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            if (product.lstbxProduct.SelectedItems != null)
            {
                FrameForOrder.Navigate(new ViewCreateOrder(product.lstbxProduct.SelectedItems as DataView));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void saleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            product.lstbxProduct.ItemsSource = Model.Catalog.SaleCB(saleCB.SelectedIndex);
        }

        private void priceCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            product.lstbxProduct.ItemsSource = Model.Catalog.PriceCB(priceCB.SelectedIndex);
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            product.lstbxProduct.ItemsSource = Model.Catalog.SearchTB(searchTB.Text + "%");
        }
    }
}
