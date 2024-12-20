//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_book.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class books
    {
        public int id_b { get; set; }
        public string b_title { get; set; }
        public int id_a { get; set; }
        public string isbn { get; set; }
        public int publish_year { get; set; }
        public string b_desc { get; set; }
        public string b_photo { get; set; }
        public int id_p { get; set; }
        public int id_g { get; set; }
    
        public virtual authors authors { get; set; }
        public virtual genres genres { get; set; }
        public virtual publishers publishers { get; set; }
        
        public string BookGenre
        {
            get
            {
                return Services.GenreService.Genre(genres.id_g);
            }
        }
        public string BookAuthor
        {
            get
            {
                return Services.AuthorService.Author(authors.id_a);
            }
        }
        public string BookPublisher
        {
            get
            {
                return Services.PublisherService.Publisher(publishers.id_p);
            }
        }
    }
}
