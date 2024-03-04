using System.ComponentModel;


namespace WpfApp1
{
    public class FunctionTypes : INotifyPropertyChanged //Для записи данных об каждой функции
    {
        private string _functionName;
        public string FunctionName
        {
            get => _functionName;
            set
            {
                if (_functionName != value)
                {
                    _functionName = value;
                    OnPropertyChanged(nameof(FunctionName));

                }
            }
        }

        private double _coefficientA;

        public double CoefficientA // Нужно чтобы заполнить приватную переменную _coefficientA и настроить свойства
        {
            get => _coefficientA;     
            set
            {
                if (_coefficientA != value)
                {
                    _coefficientA = value;
                    OnPropertyChanged(nameof(CoefficientA));

                }
            }
        }

        private double _coefficientB;
        public double CoefficientB // Нужно чтобы заполнить приватную переменную _coefficientB и настроить свойства
        {
            get => _coefficientB;
            set
            {
                if (_coefficientB != value)
                {
                    _coefficientB = value;
                    OnPropertyChanged(nameof(CoefficientB));

                }
            }
        }
        
        private int _coefficientC;
        public int CoefficientC //Нужно чтобы заполнить приватную переменную _coefficientС и настроить свойства
        {
            get => _coefficientC;
            set
            {
                if (_coefficientC != value)
                {
                    _coefficientC = value;
                    OnPropertyChanged(nameof(_coefficientC));

                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
