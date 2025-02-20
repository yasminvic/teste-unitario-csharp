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
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Pedro"
            };
            
            //Act
            _contatoDao.InserirContato(contato);

            //Assert
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTeste()
        {
            //Arrange
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Pedro"
            };
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
        public void Test1()
        {
            _contatoDao = null;
        }

        private void AdicionarContatos(List<Contato> lista, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                var contato = new Contato()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pedro"
                };
                lista.Add(contato);
            }
        }
    }
}