using SPORTs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            login.Focus();
            captcha.Text = MyCaptcha();
        }

        private void ghost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog());
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (captcha.Visibility == Visibility.Visible)
            {
                if (checkCaptcka.Text != captcha.Text)
                {
                    MessageBox.Show("ВЫ ТОЧНО РОБОТ, БАН", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Error);
                    checkCaptcka.Text = "";
                    Thread.Sleep(10000);
                    captcha.Text = MyCaptcha();
                }
                else
                {
                    if (Authoriz.auth(login.Text, password.Password) == true)
                    {
                        if (Role.role == "Клиент")
                            NavigationService.Navigate(new Catalog());
                        if (Role.role == "Администратор")
                            NavigationService.Navigate(new MenuAdmin());
                        if (Role.role == "Менеджер")
                            NavigationService.Navigate(new MenuManager());
                    }
                    else
                    {
                        MessageBox.Show("НЕ ВЕРНЫЙ ЛОГИН ИЛИ ПАРОЛЬ", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Error);
                        checkCaptcka.Text = "";
                        captcha.Text = MyCaptcha();
                    }
                }
            }
            else
            {
                if (Authoriz.auth(login.Text, password.Password) == true)
                {
                    if (Role.role == "Клиент")
                        NavigationService.Navigate(new Catalog());
                    if (Role.role == "Администратор")
                        NavigationService.Navigate(new MenuAdmin());
                    if (Role.role == "Менеджер")
                        NavigationService.Navigate(new MenuManager());
                }
                else
                {
                    MessageBox.Show("НЕ ВЕРНЫЙ ЛОГИН ИЛИ ПАРОЛЬ", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Error);
                    captcha.Visibility = Visibility.Visible;
                    checkCaptcka.Visibility = Visibility.Visible;
                    checkCaptcka.Text = "";
                    captcha.Text = MyCaptcha();
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private static Random random = new Random();

        public static string MyCaptcha()
        {
            string textCaptcha;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return textCaptcha = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void captcha_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            captcha.Text = MyCaptcha();
        }
    }
}
