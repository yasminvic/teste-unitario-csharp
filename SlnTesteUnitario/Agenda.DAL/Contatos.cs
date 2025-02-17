using Agenda.Domain;
using System.Data.SqlClient;

namespace Agenda.DAL
{
    public class Contatos
    {
        public Contato InserirContato()
        {
            string strConnection = @"Data Source=localhost\sqlexpress; Initial Catalog=agenda-contatos-testes-unitarios; Integrated Security=True;";
            sql
            con.Open();

            string sqlInsert = $"insert into Contatos values ('{id}', '{nome}')";
            string sqlSelect = $"select Nome from Contatos where Id = '{id}'";

            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();
        }

    }
}
