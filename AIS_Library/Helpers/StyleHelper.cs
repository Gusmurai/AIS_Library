using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Helpers
{
    internal class StyleHelper
    {// Метод для настройки ТАБЛИЦ (DataGridView)
        public static void ConfigureGrid(DataGridView grid)
        {
            // --- 1. Внешний вид (Убираем лишнее) ---
            grid.BackgroundColor = Color.White; // Белый фон контейнера
            grid.BorderStyle = BorderStyle.None; // Убираем рамку вокруг таблицы
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Оставляем только горизонтальные линии
            grid.RowHeadersVisible = false; // Убираем серый столбик слева (треугольничек)

            // --- 2. Поведение ---
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выделять строку целиком
            grid.MultiSelect = false; // Запрет выделения нескольких строк
            grid.AllowUserToAddRows = false; // Убираем пустую строку снизу
            grid.AllowUserToDeleteRows = false; // Запрет удаления Delete-ом
            grid.ReadOnly = true; // Запрет редактирования ячеек напрямую
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Растягивать колонки

            // --- 3. Шапка таблицы (Заголовки) ---
            grid.EnableHeadersVisualStyles = false; // Разрешаем свои стили
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // Убираем рамки у заголовков
            grid.ColumnHeadersHeight = 40; // Высота шапки
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // Фиксированная высота

            // Нейтральные цвета шапки (Светло-серый)
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold); // Жирный шрифт
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5); // Отступы текста

            // --- 4. Строки с данными ---
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9); // Обычный шрифт
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Padding = new Padding(5);

            // Цвет выделения (Нейтральный серый, чтобы не рябило в глазах пока)
            grid.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            grid.RowTemplate.Height = 35; // Высота строки (чтобы текст дышал)
        }

        // Метод для настройки КНОПОК
        public static void ConfigureButton(Button btn)
        {
            // Делаем кнопку плоской
            btn.FlatStyle = FlatStyle.Flat;

            // Тонкая серая рамка
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.Silver;

            // Нейтральные цвета
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;

            // Эффект при наведении (чуть темнее)
            btn.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btn.FlatAppearance.MouseDownBackColor = Color.Gainsboro;

            // Шрифт и курсор
            btn.Font = new Font("Segoe UI", 9);
            btn.Cursor = Cursors.Hand; // Курсор-рука
        }
    }
}

