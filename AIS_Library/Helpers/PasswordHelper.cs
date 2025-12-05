using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Library.Helpers
{
    public static class PasswordHelper
    {
        // Константы, как в твоем старом проекте
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32;  // 256 bit
        private const int Iterations = 10000;

        /// <summary>
        /// Метод для проверки пароля.
        /// Берет введенный пароль и соль из БД, хеширует и сравнивает с хешем из БД.
        /// </summary>
        public static bool VerifyPassword(string password, string hash, string salt)
        {
            // Преобразуем соль из строки Base64 обратно в байты
            var saltBytes = Convert.FromBase64String(salt);

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                saltBytes,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                var hashBytes = Convert.FromBase64String(hash);

                return FixedTimeEquals(keyToCheck, hashBytes);
            }
        }

        // Собственный безопасный метод сравнения (защита от тайминг-атак)
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }

        // Метод для создания хеша (понадобится позже для создания новых сотрудников)
        public static (string hash, string salt) HashPassword(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return (key, salt);
            }
        }
    }
}
