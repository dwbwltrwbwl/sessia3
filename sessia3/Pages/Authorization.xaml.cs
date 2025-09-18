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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void ButtonVhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model01.users.FirstOrDefault((x => x.login == TBLogin.Text && x.password == PBPassword.Password));
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.id_role)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Ученик " + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, Менеджер " + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
