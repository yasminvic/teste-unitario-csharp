using Agenda.Domain;
using AutoFixture;

namespace Agenda.DAO.Teste
{
    [TestFixture]
    public class ContatosDaoTeste : BaseTeste
    {
        private ContatosDao _contatoDao;
        private Fixture _fixture;
        [SetUp]
        public void Setup()
        {
            _contatoDao = new ContatosDao();
            _fixture = new Fixture();
        }

        [Test]
        public void InserirContatoTeste()
        {
            //Arrange
            var contato = CriarContato();

            //Act
            _contatoDao.InserirContato(contato);

            //Assert
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTeste()
        {
            //Arrange
            var contato = CriarContato();
            _contatoDao.InserirContato(contato);

            //Act
            var resultado = _contatoDao.ObterContato(contato.Id.ToString());

            //Assert
            Assert.AreEqual(contato.Id, resultado.Id);
            Assert.AreEqual(contato.Nome, resultado.Nome);
        }

        [Test]
        public void ObterTodosTeste()
        {
            var listaContatos = new List<Contato>();
            AdicionarContatos(listaContatos, 5);

            listaContatos.ForEach(c => _contatoDao.InserirContato(c));

            var resultadoLista = _contatoDao.ObterTodosTeste();
            var contatoResultado = resultadoLista.Where(c => c.Id == listaContatos.First().Id).First();

            Assert.IsNotNull(resultadoLista);
            Assert.IsTrue(resultadoLista.Count >= listaContatos.Count);
            Assert.AreEqual(listaContatos.First().Id, contatoResultado.Id);
            Assert.AreEqual(listaContatos.First().Nome, contatoResultado.Nome);
        }

        [TearDown] //executa ao final de cada teste
        public void Limpar()
        {
            _contatoDao = null;
        }

        private void AdicionarContatos(List<Contato> lista, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                var contato = CriarContato();
                lista.Add(contato);
            }
        }

        private Contato CriarContato()
        {
            return _fixture.Create<Contato>();
        }
    }
}

