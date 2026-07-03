using System;
using System.Data.SQLite;
using System.IO;

namespace SpaceShooterGame
{
    public static class DatabaseManager
    {
        private static string dbFile = "GameData.sqlite"; // نام فایل دیتابیس
        private static string connectionString = "Data Source=" + dbFile + ";Version=3;";

        // این متد در ابتدای اجرای برنامه صدا زده می‌شود تا دیتابیس را بسازد
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open(); string createTable = "CREATE TABLE IF NOT EXISTS PlayerStats (Id INTEGER PRIMARY KEY, HighScore INTEGER, TotalCoins INTEGER, ExtraHP INTEGER DEFAULT 0, ShipSkin INTEGER DEFAULT 0, BgSkin INTEGER DEFAULT 0, BulletSkin INTEGER DEFAULT 0)";
                    using (var cmd = new SQLiteCommand(createTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // ایجاد مقادیر اولیه (صفر) برای اولین بار که بازی اجرا می‌شود
                    string insertDefault = "INSERT INTO PlayerStats (Id, HighScore, TotalCoins) VALUES (1, 0, 0)";
                    using (var cmd = new SQLiteCommand(insertDefault, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // متد برای ذخیره رکورد جدید و اضافه کردن سکه‌های جمع شده
        public static void SaveGameResult(int currentScore, int earnedCoins)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // ابتدا رکورد قبلی را می‌خوانیم تا ببینیم رکورد جدید زده شده یا نه
                int currentHighScore = GetHighScore();
                int newHighScore = currentScore > currentHighScore ? currentScore : currentHighScore;

                // آپدیت کردن دیتابیس
                string updateQuery = "UPDATE PlayerStats SET HighScore = @hp, TotalCoins = TotalCoins + @coins WHERE Id = 1";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@hp", newHighScore);
                    cmd.Parameters.AddWithValue("@coins", earnedCoins);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // خواندن بالاترین رکورد
        public static int GetHighScore()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HighScore FROM PlayerStats WHERE Id = 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // خواندن کل سکه‌ها برای نمایش در فروشگاه
        public static int GetTotalCoins()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TotalCoins FROM PlayerStats WHERE Id = 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        //  متد خواندن تعداد جان‌های خریداری شده
        public static int GetExtraHP()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ExtraHP FROM PlayerStats WHERE Id = 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        //  متد خرید جان و کسر سکه از دیتابیس
        public static bool BuyExtraHP(int cost)
        {
            int currentCoins = GetTotalCoins();
            if (currentCoins >= cost)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE PlayerStats SET TotalCoins = TotalCoins - @cost, ExtraHP = ExtraHP + 1 WHERE Id = 1";
                    using (var cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@cost", cost);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            return false;
        }

        // خرید و تغییر اسکین
        public static bool BuyAndEquipSkin(string skinType, int skinId, int cost)
        {
            int currentCoins = GetTotalCoins();
            if (currentCoins >= cost)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // کم کردن پول و ثبت اسکین جدید
                    string updateQuery = $"UPDATE PlayerStats SET TotalCoins = TotalCoins - @cost, {skinType} = @id WHERE Id = 1";
                    using (var cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@cost", cost);
                        cmd.Parameters.AddWithValue("@id", skinId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            return false;
        }

        // خواندن اطلاعات اسکین‌های انتخاب شده
        public static int GetSkin(string skinType)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT {skinType} FROM PlayerStats WHERE Id = 1";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

    }
}