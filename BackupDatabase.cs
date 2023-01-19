using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB
{
    internal class BackupDatabase
    {
        private readonly string _fileTobackup;
        private readonly string _backupPath;

        public BackupDatabase(string fileTobackup, string backupPath)
        {
            _fileTobackup = fileTobackup;
            _backupPath = backupPath;
        }

        public void PerformBackup()
        {
            //var backupScript = File.ReadAllBytes(_fileTobackup);
            DirectoryInfo backupFolder = new DirectoryInfo(_backupPath);
            if (!backupFolder.Exists)
            {
                backupFolder.Create();
            }
            var backupFile = Path.Combine(_backupPath, "database.db");
            File.Copy(_fileTobackup, backupFile,true);
        }
    }
}
