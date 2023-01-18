using MVP_SQLite_Dapper_UpDB.Model;
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
    public partial class FormUsuario : Form, IUsuarioView
    {
        private readonly UsuarioPresenter _presenter;
        private BindingSource _bindingSource;
        public FormUsuario()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
            _presenter = new UsuarioPresenter(this);
        }

        public int Id { get ; set ; }
        public string Nome { get => textBoxNome.Text; set => textBoxNome.Text = value; }
        public string Sobrenome { get => textBoxSobrenome.Text; set => textBoxSobrenome.Text=value; }
        
        public event EventHandler SaveEvent;
        public event EventHandler ClearEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;

        public void LoadUsuarios(IEnumerable<Usuario> usuarios)
        {
            _bindingSource.DataSource = usuarios;
            dataGridViewUsuario.DataSource = _bindingSource;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveEvent?.Invoke(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearEvent?.Invoke(sender, e);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.Id ==0)
            {
                Usuario usuario = (Usuario)_bindingSource.Current;
                this.Nome = usuario.Nome;
                this.Sobrenome = usuario.Sobrenome;
                this.Id = usuario.Id;
            }
            else
            {
                UpdateEvent?.Invoke(sender, e);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)_bindingSource.Current;
            this.Id = usuario.Id;
            DeleteEvent?.Invoke(sender, e);
        }
    }
}
