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
    public partial class FormEndereco : Form, IEnderecoView
    {
        private EnderecoPresenter _presenter;
        public FormEndereco()
        {
            InitializeComponent();
            _presenter = new EnderecoPresenter(this);
            _presenter.LoadEnderecos();
        }
        public string Rua { get => txtRua.Text; set => txtRua.Text = value; }
        public string Numero { get => txtNumero.Text; set => txtNumero.Text = value; }
        public string Bairro { get => txtBairro.Text; set => txtBairro.Text = value; }
        public string Cidade { get => txtCidade.Text; set => txtCidade.Text = value; }
        public string Estado { get => txtEstado.Text; set => txtEstado.Text = value; }
        public int Id { get; set; }
        public DataGridView Enderecos { get => dgvEnderecos; set => dgvEnderecos = value; }
        public void ShowMessage(string message) => MessageBox.Show(message);
        private void btnClear_Click(object sender, EventArgs e) => _presenter.Clear();
        private void btnSave_Click(object sender, EventArgs e) => _presenter.Save();
        private void btnEdit_Click(object sender, EventArgs e) => _presenter.Edit();
        private void btnDelete_Click(object sender, EventArgs e) => _presenter.Delete();
    }
}
