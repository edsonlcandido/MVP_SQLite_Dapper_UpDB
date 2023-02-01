using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.View
{
    public interface IAdicionarEnderecoView
    {
        int usuario_Id { get;set; }
        int endereco_Id { get; }
        void ShowMessage(string message);
    }
}
