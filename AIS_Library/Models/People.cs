using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Models
{
    public class Librarian
    {
        public int TabelNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string UserLogin { get; set; }

        // Новое поле
        public bool IsActive { get; set; }

        public string FullName => $"{Surname} {FirstName} {Patronymic}".Trim();

        // Вспомогательное свойство для отображения в таблице текстом
        public string StatusText => IsActive ? "Работает" : "Уволен";
    }

    public class Reader
    {
        public int TicketNumber { get; set; } // PK
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte[] Photo { get; set; } // Фото

        // Вспомогательное свойство для полного имени (для списков)
        public string FullName => $"{Surname} {FirstName} {Patronymic}".Trim();

        // Вспомогательное свойство для паспорта
        public string PassportFull => $"{PassportSeries} {PassportNumber}";

        public bool IsActive { get; set; } // <--- НОВОЕ ПОЛЕ

        // Вспомогательное свойство для таблицы
        public string StatusText => IsActive ? "Активен" : "Архив";
    }
}
