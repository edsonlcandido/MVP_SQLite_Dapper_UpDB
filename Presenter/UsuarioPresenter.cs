﻿using MVP_SQLite_Dapper_UpDB.Model;
using MVP_SQLite_Dapper_UpDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_SQLite_Dapper_UpDB.Presenter
{
    public class UsuarioPresenter
    {
        private readonly IUsuarioView _view;
        public UsuarioPresenter(IUsuarioView view)
        {
            _view = view;
            _view.SaveEvent += SaveUsuario;
            _view.ClearEvent += ClearUsuario;
            _view.UpdateEvent += UpdateUsuario;
            _view.DeleteEvent += DeleteUsuario;
            _view.DetailsEvent += DetailsUsuario;
            LoadUsuarios();
        }

        private void DetailsUsuario(object? sender, EventArgs e)
        {
            FormUsuarioDetalhes formUsuarioDetalhes = new FormUsuarioDetalhes(_view.Id);
            formUsuarioDetalhes.ShowDialog();
        }

        public void LoadUsuarios()
        {
            IEnumerable<Usuario> usuarios = Usuario.GetAll();
            _view.LoadUsuarios(usuarios);
        }

        private void UpdateUsuario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Id = _view.Id,
                Nome = _view.Nome,
                Sobrenome = _view.Sobrenome
            };
            Usuario.Save(usuario);
            LoadUsuarios();
            ClearUsuario(sender, e);
        }

        private void DeleteUsuario(object sender, EventArgs e)
        {
            Usuario.Delete(_view.Id);
            LoadUsuarios();
            ClearUsuario(sender, e);
        }

        public void SaveUsuario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Id = 0,
                Nome = _view.Nome,
                Sobrenome = _view.Sobrenome
            };

            Usuario.Save(usuario);
            LoadUsuarios();
            ClearUsuario(sender,e);
        }
        private void ClearUsuario(object sender, EventArgs e)
        {
            _view.Id= 0;
            _view.Nome = "";
            _view.Sobrenome = "";
        }
    }
}
