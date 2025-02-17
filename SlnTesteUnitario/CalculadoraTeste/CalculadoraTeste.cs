using Exemplo;

namespace CalculadoraTeste
{
    public class CalculadoraTeste
    {
        private Calculadora _calc;

        public CalculadoraTeste()
        {
            _calc = new Calculadora();
        }


        [Fact]
        public void DeveSomar5Com10ERetornar15()
        {
            //Arrange => é o cenário montado, no caso o 5 e o 10
            int x = 5;
            int y = 10;

            //Act => A ação que será tomada com esse cenário, no caso Somar
            int resultado = _calc.Somar(x, y);

            //Assert => Validar o resultado esperado, no caso 15
            Assert.Equal(15, resultado);
        }

        [Fact]
        public void DeveVerificarSe4EhParERetornarTrue()
        {
            //Arrange
            int num = 5;

            //Act
            var resultado = _calc.EhPar(num);

            //Assert
            Assert.True(resultado);
        }

        //Executar vários cenários de uma vez
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        public void DeveVerificarSeOsNumerosSaoImparesERetornarFalse(int num)
        {
            //Act
            var resultado = _calc.EhPar(num);

            //Assert
            Assert.False(resultado);
        }

        [Theory]
        [InlineData(new int[] { 2, 4 })]
        [InlineData(new int[] { 14, 10, 26 })]
        public void DeveVerificarSeOArrayDeNumerosSãoParesERetornarTrue(int[] numeros)
        {
            //Act e Assert
            Assert.All(numeros, x => Assert.True(_calc.EhPar(x)));
        }
    }
}