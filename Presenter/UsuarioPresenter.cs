using MVP_SQLite_Dapper_UpDB.Model;
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
            _view.SaveEvent += OnSaveUsuario;
            _view.DeleteEvent += OnDeleteUsuario;
            _view.EditEvent += OnEditUsuario;

            LoadUsuario();
        }

        private void LoadUsuario()
        {
            var usuarios = Usuario.GetAll();
            _view.LoadUsuarios(usuarios);
        }

        private void OnEditUsuario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Id = _view.Id,
                Nome = _view.Nome,
                Sobrenome = _view.Sobrenome
            };

            Usuario.Save(usuario);
        }

        private void OnDeleteUsuario(object sender, EventArgs e)
        {
            Usuario.Delete(_view.Id);
        }

        private void OnSaveUsuario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Id = 0,
                Nome = _view.Nome,
                Sobrenome = _view.Sobrenome
            };

            Usuario.Save(usuario);
        }
    }
}
