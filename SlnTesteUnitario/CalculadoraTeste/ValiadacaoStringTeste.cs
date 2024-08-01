using Exemplo;

namespace ExemploTeste
{
    public class ValiadacaoStringTeste
    {
        private ValidacaoString _validacao;

        public ValiadacaoStringTeste()
        {
            _validacao = new ValidacaoString();
        }

        [Fact]
        public void DeveContarCaracteresEmOlaERetornar3()
        {
            //Arrange
            string stringTeste = "Ola";

            //Act
            var resultado = _validacao.ContarCaracter(stringTeste);

            //Assert
            Assert.Equal(3, resultado);
        }
    }
}
