namespace MVP_SQLite_Dapper_UpDB.View
{
    public interface IUsuarioDetalhesView
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        DataGridView Enderecos { get; set; }
    }
}