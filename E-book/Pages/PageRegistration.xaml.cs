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
using E_book.AppData;

namespace E_book.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAuthorization());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                popRegLog.IsOpen = false;
                popRegPass.IsOpen = false;
            };
            if (string.IsNullOrWhiteSpace(tbRegLog.Text) || AppConnect.model0db.users.Count(x => x.u_login == tbRegLog.Text) > 0)
            {
                popRegLog.IsOpen = true;
                timer.Start();
            }
            else
            {
                if (pbRegPass.SecurePassword.Length == 0 || pbRegPassConf.SecurePassword.Length == 0 || pbRegPass.Password != pbRegPassConf.Password)
                {
                    popRegPass.IsOpen = true;
                    timer.Start();
                }
                else
                {
                    try
                    {
                        users userObj = new users()
                        {
                            u_login = tbRegLog.Text,
                            u_password = pbRegPass.Password,
                            id_ur = 1
                        };
                        AppConnect.model0db.users.Add(userObj);
                        AppConnect.model0db.SaveChanges();
                        MessageBox.Show("Пользователь успешно зарегистрирован!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppFrame.frameMain.Navigate(new PageAuthorization());
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Ошибка:\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
