using Agenda.Domain;
using System.Data.SqlClient;

namespace Agenda.DAO
{
    public class ContatosDao
    {
        private string _strConnection;
        private SqlConnection _con;

        public ContatosDao()
        {
            _strConnection = @"Data Source=localhost\sqlexpress; Initial Catalog=agenda-contatos-testes-unitarios; Integrated Security=True;";
            _con = new SqlConnection(_strConnection);
        }

        public void InserirContato(string id, string nome)
        {
            _con.Open();

            string sqlInsert = $"insert into Contato values ('{id}', '{nome}')";

            SqlCommand cmd = new SqlCommand(sqlInsert, _con);

            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public string ObterContato(string id)
        {
            _con.Open();

            string sqlSelect = $"select Nome from Contato where Id = '{id}'";

            SqlCommand cmd = new SqlCommand(sqlSelect, _con);

            return cmd.ExecuteScalar().ToString();
        }

    }
}
