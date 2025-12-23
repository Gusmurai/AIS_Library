using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Helpers
{
    public static class ImageHelper
    {
        // Метод 1: Превращает Картинку (Image) в массив байтов (byte[])
        // Используется при СОХРАНЕНИИ в базу
        public static byte[] ImageToBytes(Image img)
        {
            if (img == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Сохраняем картинку в поток в формате PNG (чтобы не терять качество)
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray(); // Возвращаем массив байтов
            }
        }

        // Метод 2: Превращает массив байтов (byte[]) обратно в Картинку (Image)
        // Используется при ЗАГРУЗКЕ из базы для отображения в PictureBox
        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                // Создаем картинку из потока байтов
                return Image.FromStream(ms);
            }
        }

        //public static Image LoadImageFromFile(string fileName)
        //{
        //    // 1. Строим путь: Папка_с_программой + Имя_файла
        //    // Application.StartupPath — это путь к папке, где лежит ваш .exe
        //    string path = Path.Combine(Application.StartupPath, fileName);

        //    // 2. Проверяем, существует ли файл
        //    if (File.Exists(path))
        //    {
        //        try
        //        {
        //            // Загружаем картинку
        //            // Используем MemoryStream, чтобы не блокировать файл на диске
        //            byte[] bytes = File.ReadAllBytes(path);
        //            using (var ms = new MemoryStream(bytes))
        //            {
        //                return Image.FromStream(ms);
        //            }
        //        }
        //        catch
        //        {
        //            return null; // Если файл битый - вернем пустоту
        //        }
        //    }

        //    return null; // Если файла нет
        //}

        public static Image GeneratePlaceholder(int width, int height, string text)
        {
            // Создаем картинку нужного размера
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 1. Заливаем фон светло-серым
                g.Clear(Color.FromArgb(240, 240, 240));

                // 2. Рисуем рамку (пунктирную, для стиля)
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(pen, 1, 1, width - 2, height - 2);
                }

                // 3. Рисуем текст по центру
                using (Font font = new Font("Segoe UI", 9, FontStyle.Regular))
                {
                    // Вычисляем размер текста, чтобы он был ровно по центру
                    SizeF textSize = g.MeasureString(text, font, width - 10); // Ограничиваем шириной

                    // Рисуем
                    g.DrawString(text, font, Brushes.DimGray,
                        new RectangleF(0, (height - textSize.Height) / 2, width, height),
                        new StringFormat { Alignment = StringAlignment.Center });
                }
            }
            return bmp;
        }
    }
}
