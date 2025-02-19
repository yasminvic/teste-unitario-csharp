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

        public void InserirContato(Contato contato)
        {
            _con.Open();

            string sqlInsert = $"insert into Contato values ('{contato.Id}', '{contato.Nome}')";

            SqlCommand cmd = new SqlCommand(sqlInsert, _con);

            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public Contato ObterContato(string id)
        {
            _con.Open();

            string sqlSelect = $"select Id, Nome from Contato where Id = '{id}'";

            SqlCommand cmd = new SqlCommand(sqlSelect, _con);

            var sqlReader = cmd.ExecuteReader();
            sqlReader.Read();

            return new Contato()
            {
                Id = Guid.Parse(sqlReader["Id"].ToString()),    
                Nome = sqlReader["Nome"].ToString()
            };
        }

        public List<Contato> ObterTodosTeste()
        {
            var contatos = new List<Contato>();

            _con.Open();

            string sqlSelect = $"select Id, Nome from Contato";

            SqlCommand cmd = new SqlCommand(sqlSelect, _con);

            var sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read()) 
            {
                var contato = new Contato()
                {
                    Id = Guid.Parse(sqlReader["Id"].ToString()),
                    Nome = sqlReader["Nome"].ToString()
                };
                contatos.Add(contato);
            }

            return contatos;
        }

    }
}
