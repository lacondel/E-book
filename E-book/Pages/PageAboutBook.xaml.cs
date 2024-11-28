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
    /// Логика взаимодействия для PageAboutBook.xaml
    /// </summary>
    public partial class PageAboutBook : Page
    {
        public PageAboutBook(books selectedBook)
        {
            InitializeComponent();
            DataContext = new BookInformation(selectedBook);
        }
    }

    public class BookInformation
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookISBN { get; set; }
        public int BookPublishYear { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public string BookPublisher { get; set; }
        public string BookGenre { get; set; }

        public BookInformation(books selectedBook)
        {
            BookTitle = selectedBook.b_title;
            BookAuthor = AuthorService.Author(selectedBook.id_a);
            BookISBN = selectedBook.isbn;
            BookPublishYear = selectedBook.publish_year;
            BookDescription = selectedBook.b_desc;
            BookImage = selectedBook.b_photo;
            BookPublisher = PublisherService.Publisher(selectedBook.id_p);
            BookGenre = GenreService.Genre(selectedBook.id_g);
        }
    }
}
