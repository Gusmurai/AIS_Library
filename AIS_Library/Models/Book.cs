using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Models
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int? PublicationYear { get; set; }
        public string PublisherName { get; set; }
        public string Authors { get; set; } // Строка "Толстой Л.Н., Пушкин А.С."
        public string Genres { get; set; }  // Строка "Роман, Классика"

        // Статистика экземпляров
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        // Дополнительные поля (для формы редактирования, загрузим позже отдельно)
        public string Bbk { get; set; }
        public string AuthorMark { get; set; }
        public int PageCount { get; set; }
        public byte[] CoverImage { get; set; }
        public int? PublisherId { get; set; }

        public bool IsActive { get; set; } // <--- Добавь

        // Для таблицы
        public string StatusText => IsActive ? "Активна" : "Архив";
    }

    public class Copy
    {
        public int InventoryNumber { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; } // "В наличии", "Выдан", "Списан"
    }
}
