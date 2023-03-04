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

namespace WriteReadProjectDemo
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static bool UserRole;

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                if (tbLogin.Text != null && tbPassword.Text != null)
                {
                    User user = db.tbe.User.FirstOrDefault(x => x.UserPassword == tbPassword.Text && x.UserLogin == tbLogin.Text);
                    if (user.UserLogin == tbLogin.Text)
                    {
                        if (user.UserPassword == tbPassword.Text)
                        {
                            if (user.UserRole == 1) // админ
                            {
                                NavigationService.Navigate(new PageProducts(user));
                            }
                            else if(user.UserRole == 2) // менеджер
                            {

                            }
                            else if (user.UserRole == 3) // клиент
                            {
                                NavigationService.Navigate(new PageProducts(user));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль в системе отсутствует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин в системе отсутствует");
                    }

                }

            }
            else
            {
                MessageBox.Show("Неверный логин и/или пароль!");
            }
        }
    }
}
