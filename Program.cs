using System.Runtime.InteropServices;
using DbUp;
using System.Reflection;
using MVP_SQLite_Dapper_UpDB.View;
using MVP_SQLite_Dapper_UpDB.Presenter;
using MVP_SQLite_Dapper_UpDB.Model;
using NUnit.Framework;

namespace MVP_SQLite_Dapper_UpDB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (args.Length >0)
            {
                AllocConsole();
                switch (args[0])
                {
                    case "updb":
                        switch (args[1])
                        {
                            case "migrate":
                                var connectionString = "Data Source=database.db;";
                                var upgrader = 
                                    DeployChanges.To
                                    .SQLiteDatabase(connectionString)
                                    .WithScriptsFromFileSystem(@".\Migrations")
                                    .LogToConsole()
                                    .Build();
                                var result = upgrader.PerformUpgrade();
                                if (!result.Successful)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(result.Error);
                                    Console.ResetColor();
                                    Console.ReadLine();
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Success!");
                                Console.ResetColor();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
            }
            else
            {
                var fileToBackup = "database.db";
                var backupPath = "backup-db";
                var dateToday = DateTime.Today;
                var dateLastAccess = File.GetLastAccessTime(fileToBackup).Date;
                if (dateToday.CompareTo(dateLastAccess) != 0)
                {
                    var backup = new BackupDatabase(fileToBackup, backupPath);
                    backup.PerformBackup();
                }
                Application.Run(new FormUsuario());
            }            
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}