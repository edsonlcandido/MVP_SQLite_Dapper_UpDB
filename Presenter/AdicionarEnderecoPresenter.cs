using MVP_SQLite_Dapper_UpDB.Model;
using MVP_SQLite_Dapper_UpDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_SQLite_Dapper_UpDB.Presenter
{
    public class AdicionarEnderecoPresenter
    {
        private IAdicionarEnderecoView _view;

        public AdicionarEnderecoPresenter(IAdicionarEnderecoView view)
        {
            _view = view;
        }

        internal void Add()
        {
            Usuario_Enderecos.Save(_view.usuario_Id, _view.endereco_Id);
            _view.ShowMessage("Endereço relacionado com sucesso");
        }
    }
}
