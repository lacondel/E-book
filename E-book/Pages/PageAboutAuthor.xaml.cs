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
    /// Логика взаимодействия для PageAboutAuthor.xaml
    /// </summary>
    public partial class PageAboutAuthor : Page
    {
        public PageAboutAuthor(authors selectedAuthor)
        {
            InitializeComponent();
            DataContext = new AuthorInformation(selectedAuthor);
            UpdateAuthorDODVisibility();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppFrame.frameMain.CanGoBack)
            {
                AppFrame.frameMain.GoBack();
            }
        }

        private void UpdateAuthorDODVisibility()
        {
            var authorInfo = DataContext as AuthorInformation;
            if (authorInfo != null && !authorInfo.AuthorDOD.HasValue)
            {
                AuthorDODTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }

    public class AuthorInformation
    {
        public string AuthorName { get; set; }
        public DateTime AuthorDOB { get; set; }
        public DateTime? AuthorDOD { get; set; }
        public string AuthorBiography { get; set; }
        public string AuthorNationality { get; set; }
        public string AuthorPhoto { get; set; }
        public List<awards> AuthorAwards { get; set; }

        public AuthorInformation(authors selectedAuthor)
        {
            AuthorName = selectedAuthor.a_name;
            AuthorDOB = selectedAuthor.dob.HasValue ? selectedAuthor.dob.Value : DateTime.MinValue;
            AuthorDOD = selectedAuthor.dod.HasValue ? (DateTime?)selectedAuthor.dod.Value : null;
            AuthorBiography = selectedAuthor.biography;
            AuthorNationality = selectedAuthor.nationality;
            AuthorPhoto = selectedAuthor.a_photo;
            AuthorAwards = GetAuthorAwards(selectedAuthor.id_a);
        }

        private List<awards> GetAuthorAwards(int authorId)
        {
            var awards = AppConnect.model0db.authorAwards
                .Where(aa => aa.id_a == authorId)
                .Select(aa => aa.awards)
                .ToList();
            return awards;
        }
    }
}
