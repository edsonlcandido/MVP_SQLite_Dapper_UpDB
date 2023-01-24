# MVP_SQLite_Dapper_UpDB

[pt-br](./README.pt-br.md)

This repository was created with the intention of applying my studies in C#, MVP pattern, SQLite, Dapper and UpDb.

I decided to create this repository after creating some small applications and seeing how difficult it is to add features when the requests from clients are not clear.

To start applying the MVP pattern from the beginning, I consulted ChatGPT for initial insights, the transcription of the conversation can be found in the [ChatGTP.md](./ChatGPT.md) file (conversation in portuguese)

## Create the database

One problem I faced was controlling the local SQLite database via git, as it is a binary file and could overwrite the database already in production. 

To solve this, I learned about the UpDB library, with it is possible to create the database and update it with .sql files contained in the ./Migrations folder. To do this, I created in the Program.cs an option to run the executable via command line with the following arguments 'updb migrate', part of the code in the Program.cs.

```C#
// Arquivo Program.cs
using DbUp;
internal static class Program
{
  [STAThread]
  static void Main(string[] args)
  {
    case "updb":
        switch (args[1])
        {
            case "migrate":
                var connectionString = "Data Source=database.db;";
                var upgrader = 
                    DeployChanges.To
                    .SQLiteDatabase(connectionString)
                    .WithScriptsFromFileSystem(@".\Migrations")
                    .LogToConsole()
                    .Build();
                var result = upgrader.PerformUpgrade();
                if (!result.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.ResetColor();
                    Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
                break;
            default:
                break;
        }
    }
}
```

## Add Usuario to database

In the MVP pattern, we have the following sequence when clicking on an action button in the form:

1. The user fills in the new user information in the text fields (first name, last name) on the graphical interface.
1. The user clicks the "Save" button on the graphical interface.
1. The "Save" button triggers the "SaveEvent" event in the "UsuarioForm" class, which implements the "IUsuarioView" interface.
1. The "UsuarioPresenter" class captures the "SaveEvent" event and creates a new "Usuario" object based on the information filled in by the user.
1. The "UsuarioPresenter" class calls the "Save" method of the "Usuario" object to save the information in the database.
1. The "Save" method performs the INSERT operation in the database to add the new user.
1. The "Save" method returns and the "UsuarioPresenter" class calls the "LoadUsuarios" method to update the list of users shown on the graphical interface.

```C#
// File FormUsuario.cs
public partial class FormUsuario : Form, IUsuarioView
  {
    private readonly UsuarioPresenter _presenter;
    public FormUsuario()
      {
          InitializeComponent();
          _presenter = new UsuarioPresenter(this);
      }

    public int Id { get ; set ; }
    public string Nome { get => textBoxNome.Text; set => textBoxNome.Text = value; }
    public string Sobrenome { get => textBoxSobrenome.Text; set => textBoxSobrenome.Text=value; }

    public event EventHandler SaveEvent;

    private void buttonSave_Click(object sender, EventArgs e)
      {
          SaveEvent?.Invoke(sender, e);
      }
  }      
```
```C#
// File IUsuarioView
public interface IUsuarioView
{
    int Id { get; set; }
    string Nome { get; set; }
    string Sobrenome { get; set; }
    void LoadUsuarios(IEnumerable<Usuario> usuarios);
    event EventHandler SaveEvent;
    event EventHandler ClearEvent;
    event EventHandler DeleteEvent;
    event EventHandler UpdateEvent;
}
```

```C#
// File UsuarioPresenter.cs
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
            LoadUsuarios();
        }
        public void LoadUsuarios()
        {
            IEnumerable<Usuario> usuarios = Usuario.GetAll();
            _view.LoadUsuarios(usuarios);
        }
        public void SaveUsuario(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Id =0,
                Nome = _view.Nome,
                Sobrenome = _view.Sobrenome
            };

            Usuario.Save(usuario);
            LoadUsuarios();
            ClearUsuario(sender,e);
        }
    }
}
```

```C#
// File Model.Usuario

using Dapper;
using System.Data.SQLite;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public static void Save(Usuario usuario)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                if (usuario.Id == 0)
                {
                    //inserir usuario
                    connection.Execute("INSERT INTO usuarios (nome, sobrenome) VALUES (@nome, @sobrenome)", usuario);
                    usuario.Id = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
                }
                else
                {
                    //atualizar usuario
                    connection.Execute("UPDATE usuarios SET nome = @nome, sobrenome = @sobrenome WHERE id = @id", usuario);
                }
            }
        } 
}
```
