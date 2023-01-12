using MVP_SQLite_Dapper_UpDB.Model;
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
        public FormUsuario()
        {
            InitializeComponent();
        }

        public int Id { get ; set ; }
        public string Nome { get => textBoxNome.Text; set => textBoxNome.Text = value; }
        public string Sobrenome { get => textBoxSobrenome.Text; set => textBoxSobrenome.Text=value; }

        public event EventHandler SaveEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;

        public void LoadUsuarios(IEnumerable<Usuario> usuarios)
        {
            dataGridViewUsuario.DataSource = usuarios;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
