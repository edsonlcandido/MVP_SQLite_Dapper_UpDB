using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.Model
{
    public class Usuario_Enderecos
    {
        public static IEnumerable<Endereco> GetEnderecosByUsuario(int usuario_id)
        {
            
            using (var connection = new SQLiteConnection("Data Source = database.db"))
            {
                List<Endereco> enderecos = new List<Endereco>();
                var enderecosId = connection.Query<int>(
                    "SELECT endereco_Id FROM usuarios_enderecos WHERE usuario_Id LIKE @usuario_id",
                    new { usuario_id = $"%{usuario_id}%" });
                foreach (var id in enderecosId)
                {
                    enderecos.Add(Endereco.GetById(id));
                }
                return enderecos;
            }
            
        }
    }
}
