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
            using (Entities2 context = new Entities2())
            {
                var book = context.books.FirstOrDefault(i => i.id_b == id);

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
}
