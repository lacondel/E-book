using System.Windows;
using E_book.AppData;
using E_book.Pages;

namespace E_book
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.model0db = new Entities3();
            AppFrame.frameMain = FrmMain;

            FrmMain.Navigate(new PageAuthorization());
        }
    }
}
