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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listProducts.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите продукт", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить продукт и все связанные с ним покупки?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmResult != MessageBoxResult.Yes)
            {
                return;
            }
            try
            {
                var selectedProduct = (products)listProducts.SelectedItem;
                int productId = selectedProduct.id_prod;
                var productToDelete = AppConnect.model01.products.FirstOrDefault(p => p.id_prod == productId);
                if (productToDelete != null)
                {
                    var relatedSales = AppConnect.model01.pokupkas.Where(p => p.id_prod == productId).ToList();
                    if (relatedSales.Any())
                    {
                        AppConnect.model01.pokupkas.RemoveRange(relatedSales);
                    }
                    AppConnect.model01.products.Remove(productToDelete);
                    AppConnect.model01.SaveChanges();
                    allProducts.Remove(selectedProduct);
                    listProducts.ItemsSource = null;
                    listProducts.ItemsSource = allProducts;
                    MessageBox.Show("Продукт и все связанные с ним покупки успешно удалены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message + "Подробности: " + ex.InnerException?.Message, "Ошибка базы данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
