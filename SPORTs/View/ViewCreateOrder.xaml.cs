using SPORTs.Model;
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

namespace SPORTs.View
{
    /// <summary>
    /// Логика взаимодействия для ViewCreateOrder.xaml
    /// </summary>
    public partial class ViewCreateOrder : Page
    {
        public ViewCreateOrder(DataView dataView)
        {
            InitializeComponent();
            lstbxProduct.ItemsSource = dataView;
        }
    }
}
