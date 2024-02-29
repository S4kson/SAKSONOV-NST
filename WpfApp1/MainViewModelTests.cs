using NUnit.Framework;

namespace WpfApp1
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
            // Arrange
            var calculator = new MainViewModel();
            calculator.SelectedFunctionType = functionType;
            calculator.CoefficientA = coefficientA;
            calculator.CoefficientB = coefficientB;
            calculator.SelectedCoefficientC = selectedCoefficientC;

            // Act
            double result = calculator.CalculateFValue(x, y);

            return result;
        }
    }
}
