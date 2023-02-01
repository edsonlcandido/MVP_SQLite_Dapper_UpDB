using MVP_SQLite_Dapper_UpDB.Model;
using MVP_SQLite_Dapper_UpDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.Presenter
{
    public class UsuarioDetalhesPresenter
    {
        private readonly IUsuarioDetailsView _view;
        public UsuarioDetalhesPresenter(IUsuarioDetailsView view)
        {
            _view = view;
        }
        public void LoadEnderecos()
        {
            var enderecos = Usuario_Enderecos.GetEnderecosByUsuario(_view.Id);
            _view.Enderecos.DataSource = enderecos;
        }
    }
}
