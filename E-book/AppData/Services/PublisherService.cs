using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_book.AppData.Services
{
    internal class PublisherService
    {
        public static string Publisher(int id)
        {
            var publisher = AppConnect.model0db.publishers.FirstOrDefault(p => p.id_p == id);

            if (publisher != null)
            {
                return publisher.p_name;
            }
            else
            {
                return "Издатель не найден";
            }
        }
    }
}
