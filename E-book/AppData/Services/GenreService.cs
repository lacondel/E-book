using System.Collections.Generic;
using System.Linq;

namespace E_book.AppData.Services
{
    public class GenreService
    {
        public List<genres> GetAllGenres()
        {
            using (Entities context = new Entities())
            {
                return context.genres.ToList();
            }
        }

        public static string Genre(int id)
        {
            using (Entities context = new Entities())
            {
                var genre = context.genres.FirstOrDefault(g => g.id_g == id);

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
}
