using Agenda.Domain;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Agenda.DAO
{
    public class ContatosDao
    {
        string _strConnection;
        public ContatosDao()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            _strConnection = configuration.GetConnectionString("con");
        }

        public void InserirContato(Contato contato)
        {
            using (var con = new SqlConnection(_strConnection))
            {
                con.Open();

                string sqlInsert = $"insert into Contatos values ('{contato.Id}', '{contato.Nome}')";

                SqlCommand cmd = new SqlCommand(sqlInsert, con);

                cmd.ExecuteNonQuery();
            }
        }

        public Contato ObterContato(string id)
        {
            var contato = new Contato();
            using (var con = new SqlConnection(_strConnection))
            {
                con.Open();

                string sqlSelect = $"select Id, Nome from Contatos where Id = '{id}'";

                SqlCommand cmd = new SqlCommand(sqlSelect, con);

                var sqlReader = cmd.ExecuteReader();
                sqlReader.Read();

                contato = new Contato()
                {
                    Id = Guid.Parse(sqlReader["Id"].ToString()),
                    Nome = sqlReader["Nome"].ToString()
                };
            }
            return contato;
        }

        public List<Contato> ObterTodosTeste()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strConnection))
            {
                con.Open();
                string sqlSelect = $"select Id, Nome from Contatos";

                SqlCommand cmd = new SqlCommand(sqlSelect, con);

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
            }
            return contatos;
        }

    }
}
