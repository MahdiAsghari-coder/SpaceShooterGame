namespace SpaceShooterGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // این خط دیتابیس را می‌سازد
            DatabaseManager.InitializeDatabase();

            Application.Run(new MainMenuForm());
        }
    }
}