using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace MVP_SQLite_Dapper_UpDB.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public static Usuario GetById(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.QueryFirstOrDefault<Usuario>("SELECT * FROM usuarios WHERE id = @id", new { id });
            }
        }

        public static void Save(Usuario usuario)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                if (usuario.Id == 0)
                {
                    //inserir usuario
                    connection.Execute("INSERT INTO usuarios (nome, sobrenome) VALUES (@nome, @sobrenome)", usuario);
                    usuario.Id = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
                }
                else
                {
                    //atualizar usuario
                    connection.Execute("UPDATE usuarios SET nome = @nome, sobrenome = @sobrenome WHERE id = @id", usuario);
                }
            }
        }

        public static void Delete(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("DELETE FROM usuarios WHERE id = @id", new { id });
            }
        }

        public static IEnumerable<Usuario> GetAll()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.Query<Usuario>("SELECT * FROM usuarios");
            }
        }
    }
}
