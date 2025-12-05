using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Models
{

    public class Genre
    {
        public int Id { get; set; } // genre_id
        public string Name { get; set; }
        public string Description { get; set; }
    }
    // Класс для Издательства
    public class Publisher
    {
        public int Id { get; set; }      // publisher_id
        public string Name { get; set; } // Название
        public string City { get; set; } // Город
    }

    // Класс для Автора
    public class Author
    {
        public int Id { get; set; }          // author_id
        public string Surname { get; set; }  // Фамилия
        public string FirstName { get; set; } // Имя
        public string Patronymic { get; set; } // Отчество
        public DateTime? DateOfBirth { get; set; } // Дата рождения 

        // Специальное свойство, которое склеивает ФИО в одну строку.
        // Удобно использовать, когда нужно вывести автора в списке или выпадающем меню.
        public string FullName => $"{Surname} {FirstName} {Patronymic}".Trim();
    }


    // Поставщик
    public class Supplier
    {
        public string Inn { get; set; } // PK (Строка!)
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    // Штрафная статья
    public class FineArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Decimal используем для денег. ? означает, что может быть null (если сумма не фиксирована)
        public decimal? BaseAmount { get; set; }
    }
}
