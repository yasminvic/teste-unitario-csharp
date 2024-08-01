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
            //Arrange => � o cen�rio montado, no caso o 5 e o 10
            int x = 5;
            int y = 10;

            //Act => A a��o que ser� tomada com esse cen�rio, no caso Somar
            int resultado = _calc.Somar(x, y);

            //Assert => Validar o resultado esperado, no caso 15
            Assert.Equal(15, resultado);
        }

         
    }
}