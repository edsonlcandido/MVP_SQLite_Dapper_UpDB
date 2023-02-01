using MVP_SQLite_Dapper_UpDB.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_SQLite_Dapper_UpDB.View
{
    public partial class FormAdicionarEndereco : Form, IEnderecoView, IAdicionarEnderecoView
    {
        private EnderecoPresenter _presenter;
        private AdicionarEnderecoPresenter _adicionarEnderecoPresenter;
        private Model.Usuario _usuario;
        private Model.Endereco _endereco;

        public FormAdicionarEndereco(Model.Usuario usuario)
        {
            InitializeComponent();
            _presenter = new EnderecoPresenter(this);
            _adicionarEnderecoPresenter = new AdicionarEnderecoPresenter(this);
            _presenter.LoadEnderecos();
            _usuario = usuario;
            _endereco = new Model.Endereco();
        }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string RuaPesquisa { get => txtSearchRua.Text; set => txtSearchRua.Text = value; }
        public int Id { get; set; }
        public DataGridView Enderecos { get => dgvEnderecos; set => dgvEnderecos = value; }
        public int usuario_Id { get 
            { 
                return _usuario.Id;
            } set {
                _usuario.Id = value;    
            } 
        }
        public int endereco_Id { get
            {
                return (int)Enderecos.SelectedRows[0].Cells["Id"].Value;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void btnSearchByRua_Click(object sender, EventArgs e)
        {
            _presenter.SearchByRua();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            _presenter.Clear();
            _presenter.LoadEnderecos();
        }

        private void buttonAddAddress_Click(object sender, EventArgs e)
        {
            _adicionarEnderecoPresenter.Add();
            this.Close();
        }

        private void FormAdicionarEndereco_Load(object sender, EventArgs e)
        {

        }
    }
}
