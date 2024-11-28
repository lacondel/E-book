using System.Collections.Generic;
using System.Linq;

namespace E_book.AppData.Services
{
    public class GenreService
    {
        public List<genres> GetAllGenres()
        {
            using (Entities2 context = new Entities2())
            {
                return context.genres.ToList();
            }
        }

        public static string Genre(int id)
        {
            using (Entities2 context = new Entities2())
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
