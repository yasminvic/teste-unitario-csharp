namespace Agenda.DAL.Teste
{
    public class ContatosTeste
    {
        private Contatos _contatos;
        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void InserirContatoTeste()
        {
            //Arrange
            var id = Guid.NewGuid();
            string nome = "Pedro";

            //Act
            var resultado = _contatos.InserirContatos(id, nome);

            //Assert
            Assert.AreEqual(nome, resultado.nome);
            Assert.AreEqual(id, resultado.id);
        }

        [Test]
        public void ObterContatoTeste()
        {

        }

        [TearDown]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}