using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.View
{
    public interface IEnderecoView
    {
        string Rua { get; set; }
        string Numero { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        string RuaPesquisa { get; set; }
        int Id { get; set; }
        DataGridView Enderecos { get; set; }
        void ShowMessage(string message);
    }
}
