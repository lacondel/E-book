using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_book.AppData.Services
{
    internal class ImageService
    {
        public static string Image(int id)
        {
            var book = AppConnect.model0db.books.FirstOrDefault(i => i.id_b == id);

            if (book != null)
            {
                return book.b_photo;
            }
            else
            {
                return "Изображение не найдено";
            }
        }
    }
}
