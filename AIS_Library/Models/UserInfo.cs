using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Models
{
    internal class UserInfo
    {
        //public static string Login { get; set; }
        //public static int Role { get; set; } // 0 - Admin, 1 - Librarian
        //public static int LibrarianId { get; set; } // Табельный номер

      
            // Логин (он же уникальный ID пользователя в таблице users)
            public static string Login { get; set; }

            // Роль: 0 - Администратор, 1 - Библиотекарь
            public static int Role { get; set; }

            // Табельный номер (tabel_number). 
            // Заполняется ТОЛЬКО если вошел Библиотекарь. Если Админ - тут будет 0.
            // Это нужно, чтобы при выдаче книги автоматически подставлять, КТО выдал книгу.
            public static int LibrarianId { get; set; }

            // Вспомогательное свойство, чтобы удобно проверять в коде: if (UserInfo.IsAdmin) ...
            public static bool IsAdmin => Role == 0;
        
    }
}
