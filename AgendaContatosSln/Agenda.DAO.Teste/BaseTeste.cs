using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace Agenda.DAO.Teste
{
    [TestFixture]
    public class BaseTeste
    {
        private string _script;
        private string _con;
        private string _catalogTeste;

        public BaseTeste()
        {
            _script = @"ProjetoDB_Create.sql";

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            _con = configuration.GetConnectionString("conSetUpTeste");
            _catalogTeste = configuration["Providers:DefaultConnection"];
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CreateDBTeste();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDBTest();
        }

        private void CreateDBTeste()
        {
            using(var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File
                    .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultLogPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTeste)
                    .Replace("$(DatabaseName)", _catalogTeste)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                    .Replace("GO\r\n", "|");
                ExecuteScriptSql(con, scriptSql);
            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using(var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private void DeleteDBTest() 
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master];
                                        DECLARE @kill varchar(8000) = '';
                                        SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
                                        FROM sys.dm_exec_sessions
                                        WHERE database_id = db_id('{_catalogTeste}')
                                        EXEC(@kill);";

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTeste}";
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
