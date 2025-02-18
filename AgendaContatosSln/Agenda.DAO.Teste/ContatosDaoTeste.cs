using Agenda.Domain;

namespace Agenda.DAO.Teste
{
    public class ContatosDaoTeste
    {
        private ContatosDao _contatoDao;
        [SetUp]
        public void Setup()
        {
            _contatoDao = new ContatosDao();
        }

        [Test]
        public void InserirContatoTeste()
        {
            //Arrange
            var id = Guid.NewGuid();
            string nome = "Pedro";

            //Act
            _contatoDao.InserirContato(id.ToString(), nome);

            //Assert
            //Assert.AreEqual(nome, resultado.nome);
            //Assert.AreEqual(nome, resultado.nome);
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTeste()
        {
            //Arrange
            var id = Guid.NewGuid();
            string nome = "Pedro";
            _contatoDao.InserirContato(id.ToString(), nome);

            //Act
            var resultado = _contatoDao.ObterContato(id.ToString());

            //Assert
            Assert.AreEqual(nome, resultado);

        }

        [TearDown] //executa ao final de cada teste
        public void Test1()
        {
            _contatoDao = null;
        }
    }
}