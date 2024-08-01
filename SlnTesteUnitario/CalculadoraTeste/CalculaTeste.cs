using Calculadora;

namespace CalculadoraTeste
{
    public class CalculaTeste
    {
        private Calcula _calc;

        public CalculaTeste()
        {
            _calc = new Calcula();
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
    }
}