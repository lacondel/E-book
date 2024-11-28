using System.Collections.Generic;
using System.Linq;

namespace E_book.AppData.Services
{
    public class GenreService
    {
        public List<genres> GetAllGenres()
        {
            return AppConnect.model0db.genres.ToList();
        }

        public static string Genre(int id)
        {
            var genre = AppConnect.model0db.genres.FirstOrDefault(g => g.id_g == id);

            if (genre != null)
            {
                return genre.g_name;
            }
            else
            {
                return "Жанр не найден";
            }
        }
    }
}
