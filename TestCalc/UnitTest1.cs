
namespace TestCalc
{
    [TestFixture]
    public class CalculationTests
    {
        [TestCase("��������", 2, 3, 2, 1, 2, ExpectedResult = 7)]
        [TestCase("������������", 4, 5, 30, 3, 4, ExpectedResult = 86)]
        [TestCase("����������", 1, 2, 100, 2, 3, ExpectedResult = 126)]
        [TestCase("4-�� �������", 3, 4, 4000, 1, 2, ExpectedResult = 4035)]
        [TestCase("5-�� �������", 2, 2, 50000, 3, 3, ExpectedResult = 50648)]
        public double TestCalculateFValue(string functionType, double coefficientA, double coefficientB, int selectedCoefficientC, double x, double y)
        {
            // � ������� ���, � ������ ���������� ������ x � y. ��������� ���������� ������� �������� ����� �� ����������.
            // ������� � ��������� �������, ���������� ��� �����, �������� ����� ������, ����� ��������� ����������
           
            // Arrange

            double fx = 0.0;

            if (functionType == "��������")
                fx = coefficientA * x + coefficientB * 1 + selectedCoefficientC;
            else if (functionType == "������������")
                fx = coefficientA * Math.Pow(x, 2) + coefficientB * y + selectedCoefficientC;
            else if (functionType == "����������")
                fx = coefficientA * Math.Pow(x, 3) + coefficientB * Math.Pow(y, 2) + selectedCoefficientC;
            else if (functionType == "4-�� �������")
                fx = coefficientA * Math.Pow(x, 4) + coefficientB * Math.Pow(y, 3) + selectedCoefficientC;
            else if (functionType == "5-�� �������")
                fx = coefficientA * Math.Pow(x, 5) + coefficientB * Math.Pow(y, 4) + selectedCoefficientC;

            return fx;




        }
    }
    
}

