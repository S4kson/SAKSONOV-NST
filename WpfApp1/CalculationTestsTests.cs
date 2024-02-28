using NUnit.Framework;
using WpfApp1;

namespace WpfApp1
{
    [TestFixture]
    public class CalculationTestsTests
    {
        
        [Test]
        public void TestMethod1()
        {
            // Arrange
            MainViewModel t = new MainViewModel();
            double result = t.CalculateFValue(2.0, 3.0);

            Assert.AreEqual(10.0, result);

        }

        [Test]
        public void TestQuadraticFunctionCalculation()
        {
            // Arrange
            MainViewModel t = new MainViewModel();

            // Act
            double result = calculator.CalculateFValue(2.0, 3.0);

            // Assert
            Assert.AreEqual(19.0, result); // Предполагаемый результат для квадратичной функции
        }
    }
}
