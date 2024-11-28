﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_book.AppData.Services
{
    internal class AuthorService
    {
        public static string Author(int id)
        {
            using (Entities2 context = new Entities2())
            {
                var author = context.authors.FirstOrDefault(a => a.id_a == id);

                if (author != null)
                {
                    return author.a_name;
                }
                else
                {
                    return "Автор не найден";
                }

            }
        }
    }
}