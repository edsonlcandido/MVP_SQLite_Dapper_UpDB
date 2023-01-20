using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static void Save(Endereco endereco)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("INSERT INTO enderecos (Rua, Numero, Bairro, Cidade, Estado) VALUES (@Rua, @Numero, @Bairro, @Cidade, @Estado)", endereco);
            }
        }

        public static Endereco GetById(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.QueryFirstOrDefault<Endereco>("SELECT * FROM enderecos WHERE Id = @id", new { id });
            }
        }

        public static void Update(Endereco endereco)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("UPDATE enderecos SET Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Id = @Id", endereco);
            }
        }

        public static void Delete(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("DELETE FROM enderecos WHERE Id = @id", new { id });
            }
        }
        public static IEnumerable<Endereco> ListAll()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.Query<Endereco>("SELECT * FROM enderecos");
            }
        }

        internal static object GetEnderecosByRua(string rua)
        {
            using (var connection = new SQLiteConnection("Data Source = database.db"))
            {
                var enderecos = connection.Query<Endereco>(
                    "SELECT * FROM enderecos WHERE Rua LIKE @rua",
                    new { rua = $"%{rua}%" });

                return enderecos;
            }
        }
    }
}
