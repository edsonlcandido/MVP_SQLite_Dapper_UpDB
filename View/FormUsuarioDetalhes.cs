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
    public partial class FormUsuarioDetalhes : Form, IUsuarioDetailsView
    {
        public FormUsuarioDetalhes(int id)
        {
            InitializeComponent();
            Usuario usuario = Usuario.GetById(id);
            Nome = usuario.Nome;
            Sobrenome = usuario.Sobrenome;
            Id = usuario.Id;
        }

        public int Id { get ; set ; }
        public string Nome { get=> labelFirstName.Text ; set => labelFirstName.Text = value ; }
        public string Sobrenome { get => labelLastName.Text; set => labelLastName.Text = value; }


        private void FormUsuarioDetalhes_Load(object sender, EventArgs e)
        {

        }
    }
}
