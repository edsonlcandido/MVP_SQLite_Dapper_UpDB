using System.Runtime.InteropServices;
using DbUp;
using System.Reflection;
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
                                var connectionString = "Data Source=databse.db;";
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
                Application.Run(new Form1());
            }            
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}