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

            ListBooks.ItemsSource = books;
        }

        books[] BookSearch()
        {
            var books = AppConnect.model0db.books.ToList();

            if (SearchBox != null)
            {
                books = books.Where(b => b.b_title.ToLowerInvariant().Contains(SearchBox.Text.ToLowerInvariant())).ToList();
            }

            if (FilterBox != null && FilterBox.SelectedIndex > 0)
            {
                if (int.TryParse(FilterBox.SelectedValue.ToString(), out int selectedGenreId) && selectedGenreId > 0)
                {
                    books = books.Where(b => b.id_g == selectedGenreId).ToList();
                }
            }

            if (SortBox != null && SortBox.SelectedIndex > 0)
            {
                switch (SortBox.SelectedIndex)
                {
                    case 1:
                        books = books.OrderBy(b => b.b_title).ToList();
                        break;
                    case 2:
                        books = books.OrderByDescending(b => b.b_title).ToList();
                        break;
                }
            }

            if (books.Count > 0)
            {
                tbCounter.Text = "Найдено " + books.Count + " книг";
            }
            else
            {
                tbCounter.Text = "В нашей базе данных нет книг, подходящих под введённые параметр";
            }

            return books.ToArray();
        }

        private void LoadGenres()
        {
            var genres = _genreService.GetAllGenres();

            genres.Insert(0, new AppData.genres {  id_g = -1, g_name = "Фильтрация" });

            FilterBox.ItemsSource = genres;
            FilterBox.DisplayMemberPath = "g_name";
            FilterBox.SelectedValuePath = "id_g";

            FilterBox.SelectedIndex = 0;
        }

        private void UpdateBooksList()
        {
            if (ListBooks != null)
            {
                var updatedList = BookSearch();
                if (updatedList != null)
                {
                    ListBooks.ItemsSource = updatedList;
                }
                else
                {
                    MessageBox.Show("Книги с данным названием не найдены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); 
                }
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBooksList();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooksList();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooksList();
        }
        private void ListBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBooks.SelectedItem != null)
            {
                var selectedBook = (books)ListBooks.SelectedItem;
                AppFrame.frameMain.Navigate(new PageAboutBook(selectedBook));
            }
        }
    }
}
