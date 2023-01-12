using MVP_SQLite_Dapper_UpDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.View
{
    public interface IUsuarioView
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }

        void LoadUsuarios(IEnumerable<Usuario> usuarios);
    }
}
