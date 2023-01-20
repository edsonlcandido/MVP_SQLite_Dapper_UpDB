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
    public class EnderecoPresenter
    {
        private readonly IEnderecoView _view;
        public EnderecoPresenter(IEnderecoView view) => _view = view;
        public void Save()
        {
            var endereco = new Endereco
            {
                Rua = _view.Rua,
                Numero = int.Parse(_view.Numero),
                Bairro = _view.Bairro,
                Cidade = _view.Cidade,
                Estado = _view.Estado
            };
            Endereco.Save(endereco);
            _view.ShowMessage("Endereco salvo com sucesso!");
            Clear();
            LoadEnderecos();
        }
        public void Delete()
        {
            Endereco.Delete(_view.Id);
            _view.ShowMessage("Endereco excluido com sucesso!");
            LoadEnderecos();
        }
        public void Edit()
        {
            if (_view.Id == 0)
            {
                int selectedId = (int)_view.Enderecos.SelectedRows[0].Cells["Id"].Value;
                _view.Id = selectedId;
                LoadEndereco();
            }
            else
            {
                var endereco = new Endereco
                {
                    Id = _view.Id,
                    Rua = _view.Rua,
                    Numero = int.Parse(_view.Numero),
                    Bairro = _view.Bairro,
                    Cidade = _view.Cidade,
                    Estado = _view.Estado
                };
                Endereco.Update(endereco);
                _view.ShowMessage("Endereco atualizado com sucesso!");
                Clear();
                LoadEnderecos();
            }

        }
        public void LoadEndereco()
        {
            var endereco = Endereco.GetById(_view.Id);
            _view.Rua = endereco.Rua;
            _view.Numero = endereco.Numero.ToString();
            _view.Bairro = endereco.Bairro;
            _view.Cidade = endereco.Cidade;
            _view.Estado = endereco.Estado;
        }
        public void LoadEnderecos()
        {
            var enderecos = Endereco.ListAll();
            _view.Enderecos.DataSource = enderecos;
        }
        public void Clear()
        {
            _view.Id = 0;
            _view.Rua = "";
            _view.Numero = "";
            _view.Bairro = "";
            _view.Cidade = "";
            _view.Estado = "";
            _view.RuaPesquisa = "";
        }

        internal void SearchByRua()
        {
            string rua = _view.RuaPesquisa;
            var enderecos = Endereco.GetEnderecosByRua(rua);
            _view.Enderecos.DataSource = enderecos;
        }
    }
}
