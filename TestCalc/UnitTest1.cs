
namespace TestCalc
{
    [TestFixture]
    public class CalculationTests
    {
        [TestCase("линейная", 2, 3, 2, 1, 2, ExpectedResult = 7)]
        [TestCase("квадратичная", 4, 5, 30, 3, 4, ExpectedResult = 86)]
        [TestCase("кубическая", 1, 2, 100, 2, 3, ExpectedResult = 126)]
        [TestCase("4-ой степени", 3, 4, 4000, 1, 2, ExpectedResult = 4035)]
        [TestCase("5-ой степени", 2, 2, 50000, 3, 3, ExpectedResult = 50648)]
        public double TestCalculateFValue(string functionType, double coefficientA, double coefficientB, int selectedCoefficientC, double x, double y)
        {
            // В функции ктр, я сделал задавались только x и y. Остальные переменные функция узнавала прямо из переменных.
            // Поэтому я переделал функцию, специально для теста, сохранив общую логику, чтобы проверить вычисления
           
            // Arrange

            double fx = 0.0;

            if (functionType == "линейная")
                fx = coefficientA * x + coefficientB * 1 + selectedCoefficientC;
            else if (functionType == "квадратичная")
                fx = coefficientA * Math.Pow(x, 2) + coefficientB * y + selectedCoefficientC;
            else if (functionType == "кубическая")
                fx = coefficientA * Math.Pow(x, 3) + coefficientB * Math.Pow(y, 2) + selectedCoefficientC;
            else if (functionType == "4-ой степени")
                fx = coefficientA * Math.Pow(x, 4) + coefficientB * Math.Pow(y, 3) + selectedCoefficientC;
            else if (functionType == "5-ой степени")
                fx = coefficientA * Math.Pow(x, 5) + coefficientB * Math.Pow(y, 4) + selectedCoefficientC;

            return fx;




        }
    }
    
}

