using System;
using System.Collections.Generic;
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
    }
}