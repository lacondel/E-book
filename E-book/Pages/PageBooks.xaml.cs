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
using E_book.AppData.Services;

namespace E_book.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        private readonly GenreService _genreService = new GenreService();

        public PageBooks()
        {
            InitializeComponent();
            LoadGenres();
            List<books> books = AppConnect.model0db.books.ToList();

            if (books.Count > 0)
            {
                tbCounter.Text = "Найдено " + books.Count + " книг";
            }
            ListBooks.ItemsSource = books;
        }

        //Book[] BookSearch()
        //{
        //    using ()
        //}

        private void LoadGenres()
        {
            var genres = _genreService.GetAllGenres();

            genres.Insert(0, new AppData.genres {  id_g = -1, g_name = "Фильтрация" });

            FilterBox.ItemsSource = genres;
            FilterBox.DisplayMemberPath = "g_name";
            FilterBox.SelectedValuePath = "id_g";

            FilterBox.SelectedIndex = 0;
        }
    }
}
