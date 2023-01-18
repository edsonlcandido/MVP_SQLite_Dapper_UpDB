# MVP_SQLite_Dapper_UpDB

Esse repositorio foi criado com a intenção de aplicar meus estudos em C#, padrão MVP, SQLite, Dapper e UpDb.

Decidi criar esse repositorio após crias algumas aplicações pequenas e ver como é dificil adicionar recursos, quando as features solicitadas pelos cleintes não ficam claras.

Para iniciar aplicando o padrão MVP desde o inicio consultei o ChatGPT para os insghts iniciais, transcrição da conversa [ChatGTP.md](./ChatGPT.md)

## Criando o banco de dados

Um problema que enfrentei foi controlar o banco de dados local do SQLite via git, pois é um aruivo binario  e poderia sobrescrever o banco de dado já em produção, para resolver isso conheci a biblioteca UpDB, com ela é possivel criamos o banco de dados e atualizar com arquivos .sql contidas na pasta ./Migrations

Para isso criei no Program.cs uma opção de rodar o executavel via linha de comando os os seguintes argumentos 'updb migrate', parte do código no Program.cs

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

## Operação de adicionar Usuario ao banco de dados

No padrão MVP temos a seguinte sequencia ao clicarmos num botão de ação no form.

1. O usuário preenche as informações do novo usuário nos campos de texto (first name, last name) na interface gráfica.
2. O usuário clica no botão "Save" na interface gráfica.
3. O botão "Save" dispara o evento "SaveEvent" na classe "UsuarioForm", que implementa a interface "IUsuarioView".
4. A classe "UsuarioPresenter" captura o evento "SaveEvent" e cria um novo objeto "Usuario" com base nas informações preenchidas pelo usuário.
5. A classe "UsuarioPresenter" chama o método "Save" do objeto "Usuario" para salvar as informações no banco de dados.
6. O método "Save" executa a operação de INSERT no banco de dados para adicionar o novo usuário.
7. O método "Save" retorna e "UsuarioPresenter" chama o método "LoadUsuarios" para atualizar a lista de usuários mostrada na interface gráfica.

Trechos dos códigos

```C#
// Arquivo FormUsuario.cs
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
// Arquivo IUsuarioView
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
// Arquivo UsuarioPresenter.cs
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
// Arquivo Model.Usuario

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
