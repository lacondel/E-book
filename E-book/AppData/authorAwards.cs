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
    
    public partial class authorAwards
    {
        public int id_a_aw { get; set; }
        public int id_a { get; set; }
        public int id_aw { get; set; }
        public int aw_date { get; set; }
    
        public virtual authors authors { get; set; }
        public virtual awards awards { get; set; }
    }
}
