using Agenda.Domain;
using System.Data.SqlClient;

namespace Agenda.DAO
{
    public class ContatosDao
    {
        public void InserirContato(string id, string nome)
        {
            string strConnection = @"Data Source=localhost\sqlexpress; Initial Catalog=agenda-contatos-testes-unitarios; Integrated Security=True;";
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();

            string sqlInsert = $"insert into Contato values ('{id}', '{nome}')";

            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string ObterContato(string id)
        {
            string strConnection = @"Data Source=localhost\sqlexpress; Initial Catalog=agenda-contatos-testes-unitarios; Integrated Security=True;";
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();

            string sqlSelect = $"select Nome from Contato where Id = '{id}'";

            SqlCommand cmd = new SqlCommand(sqlSelect, con);

            return cmd.ExecuteScalar().ToString();
        }

    }
}
