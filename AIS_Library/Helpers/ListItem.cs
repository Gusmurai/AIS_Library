using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Helpers
{
    // Класс для хранения данных в списках (ID + Текст)
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name; // Это то, что увидит пользователь в списке
        }
    }
}
