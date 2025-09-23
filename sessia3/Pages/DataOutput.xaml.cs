using sessia3.ApplicationData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sessia3.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataOutput.xaml
    /// </summary>
    public partial class DataOutput : Page
    {
        private List<products> allProducts;
        public DataOutput()
        {
            InitializeComponent();
            allProducts = AppConnect.model01.products.ToList();
            listProducts.ItemsSource = allProducts;
        }
    }
}
