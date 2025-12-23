using AIS_Library.Database;
using Npgsql;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text;
namespace AIS_Library.Helpers
{
    public static class BackupService
    {
        private static string PostgreSqlBinPath = @"C:\Program Files\PostgreSQL\17\bin\";


        public static void BackupDatabase(string filePath, Action<string> logger = null)
        {
            try
            {
                var builder = new NpgsqlConnectionStringBuilder(DbHelper.connectionString);
                string args = $"-h {builder.Host} -p {builder.Port} -U {builder.Username} -F c -v -f \"{filePath}\" \"{builder.Database}\"";
                string dumpPath = Path.Combine(PostgreSqlBinPath, "pg_dump.exe");

                ExecuteProcess(dumpPath, args, builder.Password, logger);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка бэкапа: " + ex.Message);
            }
        }


        public static void RestoreDatabase(string filePath, Action<string> logger = null)
        {
            try
            {
                var builder = new NpgsqlConnectionStringBuilder(DbHelper.connectionString);

                logger?.Invoke("--- Начало подготовки к восстановлению ---");
                logger?.Invoke("Сброс активных соединений...");

                NpgsqlConnection.ClearAllPools();
                KillActiveConnections(builder.Database, builder.Host, builder.Port.ToString(), builder.Username, builder.Password);

                logger?.Invoke("Соединения сброшены. Запуск pg_restore...");

                string args = $"-h {builder.Host} -p {builder.Port} -U {builder.Username} -d \"{builder.Database}\" -c -v \"{filePath}\"";
                string restorePath = Path.Combine(PostgreSqlBinPath, "pg_restore.exe");

                ExecuteProcess(restorePath, args, builder.Password, logger);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка восстановления: " + ex.Message);
            }
        }

        private static void KillActiveConnections(string dbName, string host, string port, string user, string password)
        {
            string adminConnString = $"Host={host};Port={port};Username={user};Password={password};Database=postgres";
            using (var conn = new NpgsqlConnection(adminConnString))
            {
                conn.Open();
                string sql = $@"SELECT pg_terminate_backend(pg_stat_activity.pid) 
                                FROM pg_stat_activity 
                                WHERE pg_stat_activity.datname = '{dbName}' AND pid <> pg_backend_pid();";
                using (var cmd = new NpgsqlCommand(sql, conn)) cmd.ExecuteNonQuery();
            }
        }

        private static void ExecuteProcess(string fileName, string arguments, string password, Action<string> logger)
        {
            // 1. Регистрируем кодировки 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 2. Берем кодировку Windows-1251 (Кириллица)
            Encoding win1251 = Encoding.GetEncoding(1251);

            if (!File.Exists(fileName))
            {
                throw new Exception($"Файл не найден: {fileName}");
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,

                // 3. Говорим C#, чтобы читал в 1251
                StandardOutputEncoding = win1251,
                StandardErrorEncoding = win1251
            };

            psi.EnvironmentVariables["PGPASSWORD"] = password;

            // 4. В POSTGRES писать логи в 1251
            psi.EnvironmentVariables["PGCLIENTENCODING"] = "WIN1251";

            using (Process process = new Process())
            {
                process.StartInfo = psi;

                process.OutputDataReceived += (s, e) => { if (e.Data != null) logger?.Invoke(e.Data); };
                process.ErrorDataReceived += (s, e) => { if (e.Data != null) logger?.Invoke(e.Data); };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    // Здесь можно бросать ошибку, а можно просто логировать,
                    // так как pg_restore часто возвращает Warning (код 1), который не страшен.
                }
            }
        }
    }
    }
