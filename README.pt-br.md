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

Após a operação de criação de usuario, iniciei as demais operações de ler, atualizar e deletar, abaixo vai estar somente os trechos de cada operação como o link para o arquivo.

Para leitura e atualização do modelo deixei no mesmo botão do form, onde a leitura ocorre recuperando o objeto do BidingSource.

Para a atualização é enviado os dados da view para o presenter e após enviado para o evento save usuario do model, q verifica se o model tem id diferente de 0.

```C#
// Arquivo FormUsuario.cs
public partial class FormUsuario : Form, IUsuarioView
  {
    ...  
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
      ...
  } 
```

```C#
// Arquivo UsuarioPresenter.cs
public class UsuarioPresenter
{
    ...
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
    ...
}
```

A operação de excluir o usuario é mais simples que a operação de edição e fica similar a operação de salvar o usurio.

```C#
// Arquivo FormUsuario.cs
public partial class FormUsuario : Form, IUsuarioView
    {
    ...
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)_bindingSource.Current;
            this.Id = usuario.Id;
            DeleteEvent?.Invoke(sender, e);
        }
    ...
    }
```

```C#
// Arquivo UsuarioPresenter.cs
 public class UsuarioPresenter
    {
    ...
        private void DeleteUsuario(object sender, EventArgs e)
        {
            Usuario.Delete(_view.Id);
            LoadUsuarios();
            ClearUsuario(sender, e);
        }
    ...
    }
```

```C#
// Arquivo Usuario.cs
public class Usuario
    {
    ...
        public static void Delete(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("DELETE FROM usuarios WHERE id = @id", new { id });
            }
        }
    ...
    }
```

Para criar as operações de CRUD para o modelo endereco, pedi ao CHATGPT para ler esse repositorio e criar os arquivos IEnderecoView.cs, EnderecoPresenter.cs e o Endereco.cs

Copiei o código gerado e fui verificar inconsistências, o código teve bem pouco erro.

Solicitei que ele criar a parte parcial do form onde ele definiu os nomes dos textboxes, botão e eventos dos cliques dor forms.

Nessa abordagem o arquivos criado ficaram da seguinte maneira, ele modificou a estrategia retirando os events do View, achei essa maneira mais enxuta, porém não sei dizer se é melhor que a outra.

```C#
// arquivo View/FormEndereco.cs
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
```

```C#
// Arquivos View/IEnderecoView.cs
    public interface IEnderecoView
    {
        string Rua { get; set; }
        string Numero { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        int Id { get; set; }
        DataGridView Enderecos { get; set; }
        void ShowMessage(string message);
    }
```

```C#
// Arquivo Presenter/EnderecoPresenter.cs
  public class EnderecoPresenter
    {
        private readonly IEnderecoView _view;
        public EnderecoPresenter(IEnderecoView view) => _view = view;
        public void Save()
        {
            var endereco = new Endereco
            {
                Rua = _view.Rua,
                Numero = int.Parse(_view.Numero),
                Bairro = _view.Bairro,
                Cidade = _view.Cidade,
                Estado = _view.Estado
            };
            Endereco.Save(endereco);
            _view.ShowMessage("Endereco salvo com sucesso!");
            Clear();
            LoadEnderecos();
        }
        public void Delete()
        {
            Endereco.Delete(_view.Id);
            _view.ShowMessage("Endereco excluido com sucesso!");
            LoadEnderecos();
        }
        public void Edit()
        {
            if (_view.Id == 0)
            {
                int selectedId = (int)_view.Enderecos.SelectedRows[0].Cells["Id"].Value;
                _view.Id = selectedId;
                LoadEndereco();
            }
            else
            {
                var endereco = new Endereco
                {
                    Id = _view.Id,
                    Rua = _view.Rua,
                    Numero = int.Parse(_view.Numero),
                    Bairro = _view.Bairro,
                    Cidade = _view.Cidade,
                    Estado = _view.Estado
                };
                Endereco.Update(endereco);
                _view.ShowMessage("Endereco atualizado com sucesso!");
                Clear();
                LoadEnderecos();
            }

        }
        public void LoadEndereco()
        {
            var endereco = Endereco.GetById(_view.Id);
            _view.Rua = endereco.Rua;
            _view.Numero = endereco.Numero.ToString();
            _view.Bairro = endereco.Bairro;
            _view.Cidade = endereco.Cidade;
            _view.Estado = endereco.Estado;
        }
        public void LoadEnderecos()
        {
            var enderecos = Endereco.ListAll();
            _view.Enderecos.DataSource = enderecos;
        }
        public void Clear()
        {
            _view.Id = 0;
            _view.Rua = "";
            _view.Numero = "";
            _view.Bairro = "";
            _view.Cidade = "";
            _view.Estado = "";
        }
    }
```

```C#
// Arquivo Model/Endereco.cs
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static void Save(Endereco endereco)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("INSERT INTO Enderecos (Rua, Numero, Bairro, Cidade, Estado) VALUES (@Rua, @Numero, @Bairro, @Cidade, @Estado)", endereco);
            }
        }

        public static Endereco GetById(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.QueryFirstOrDefault<Endereco>("SELECT * FROM Enderecos WHERE Id = @id", new { id });
            }
        }

        public static void Update(Endereco endereco)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("UPDATE Enderecos SET Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Id = @Id", endereco);
            }
        }

        public static void Delete(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Execute("DELETE FROM Enderecos WHERE Id = @id", new { id });
            }
        }
        public static IEnumerable<Endereco> ListAll()
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                return connection.Query<Endereco>("SELECT * FROM Enderecos");
            }
        }
```
