using MVP_SQLite_Dapper_UpDB.View;

namespace MVP_SQLite_Dapper_UpDB
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.MdiChildActivate += new EventHandler(FormMain_MdiChildActivate);
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            //FormUsuario formUsuario = new FormUsuario();            
            FormUsuarioSingleton.Instance.WindowState= FormWindowState.Maximized;
            //formUsuario.FormBorderStyle= FormBorderStyle.None;
            FormUsuarioSingleton.Instance.MinimizeBox = false;
            FormUsuarioSingleton.Instance.MaximizeBox = false;
            FormUsuarioSingleton.Instance.ShowIcon = false;
            FormUsuarioSingleton.Instance.Icon = null;
            FormUsuarioSingleton.Instance.ControlBox = false;
            FormUsuarioSingleton.Instance.MdiParent = this;
            FormUsuarioSingleton.Instance.Show();
        }

        private void buttonAddresses_Click(object sender, EventArgs e)
        {
            FormEnderecoSingleton.Instance.WindowState = FormWindowState.Maximized;
            FormEnderecoSingleton.Instance.MinimizeBox = false;
            FormEnderecoSingleton.Instance.MaximizeBox = false;
            FormEnderecoSingleton.Instance.ShowIcon = false;
            FormEnderecoSingleton.Instance.Icon = null;
            FormEnderecoSingleton.Instance.ControlBox = false;
            FormEnderecoSingleton.Instance.MdiParent = this;
            FormEnderecoSingleton.Instance.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_MdiChildActivate(object sender, EventArgs e)
        {
            // Aqui você pode colocar o código para capturar o evento de abertura de qualquer form filho
        }
    }

    public static class FormUsuarioSingleton
    {
        private static FormUsuario _instance;

        public static FormUsuario Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormUsuario();
                }
                return _instance;
            }
        }
    }

    public static class FormEnderecoSingleton
    {
        private static FormEndereco _instance;

        public static FormEndereco Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormEndereco();
                }
                return _instance;
            }
        }
    }
}