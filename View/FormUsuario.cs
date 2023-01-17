﻿using MVP_SQLite_Dapper_UpDB.Model;
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
        public event EventHandler ClearUsuario;
        public event EventHandler DeleteUsuario;
        public event EventHandler UpdateUsuario;

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
            ClearUsuario?.Invoke(sender, e);
        }
    }
}