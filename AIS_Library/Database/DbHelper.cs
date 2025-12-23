using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Database
{
    public static class DbHelper
    {
        // Строка подключения. 
        // Host - адрес сервера (обычно localhost)
        // Port - порт (по умолчанию 5432)
        // Username - пользователь (обычно postgres)
        // Password - ТВОЙ пароль, который ты задавал при установке Postgres
        // Database - имя твоей базы данных
       public static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1405;Database=AILibrary";

        /// <summary>
        /// Метод возвращает новое подключение к базе.
        /// Мы не держим одно открытое подключение, а создаем новое для каждого запроса — это надежнее.
        /// </summary>
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        /// <summary>
        /// Простой метод для проверки, работает ли подключение.
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true; // Успех!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
