using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> FunctionTypes { get; } =
            new ObservableCollection<string> { "линейная", "квадратичная", "кубическая", "4-ой степени", "5-ой степени" };
        public string SelectedFunctionType { get; set; }



        private double _coefficientA;
        public double CoefficientA
        {
            get { return _coefficientA; }
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
        public double CoefficientB
        {
            get { return _coefficientB; }
            set
            {
                if (_coefficientB != value)
                {
                    _coefficientB = value;
                    OnPropertyChanged(nameof(CoefficientB));
              
                }
            }
        }

        public ObservableCollection<TableValue> TableValues { get; set; } = new ObservableCollection<TableValue>();

        public ObservableCollection<int> CoefficientCOptions { get; set; } = new ObservableCollection<int>();
        public int SelectedCoefficientC { get; set; }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainViewModel()
        {
            FunctionTypes = new ObservableCollection<string> { "линейная", "квадратичная", "кубическая", "4-ой степени", "5-ой степени" };

            TableValues = new ObservableCollection<TableValue>();
            
            CoefficientCOptions = new ObservableCollection<int>();
            SelectedFunctionType = FunctionTypes[0]; 
            UpdateCoefficientCOptions();
            SelectedCoefficientC = CoefficientCOptions[0];
        }

        private void UpdateCoefficientCOptions()
        {
            switch (SelectedFunctionType)
            {
                case "линейная":
                    CoefficientCOptions = new ObservableCollection<int> { 1, 2, 3, 4, 5 };

                    break;
                case "квадратичная":
                    CoefficientCOptions = new ObservableCollection<int> { 10, 20, 30, 40, 50 };
                    break;
                case "кубическая":
                    CoefficientCOptions = new ObservableCollection<int> { 100, 200, 300, 400, 500 };
                    break;
                case "4-ой степени":
                    CoefficientCOptions = new ObservableCollection<int> { 1000, 2000, 3000, 4000, 5000 };
                    break;
                case "5-ой степени":
                    CoefficientCOptions = new ObservableCollection<int> { 10000, 20000, 30000, 40000, 50000 };
                    break;
                default:
                    CoefficientCOptions = new ObservableCollection<int>(); 
                    break;
            }
        }

        public void OnSelectedFunctionTypeChanged()
        {
            UpdateCoefficientCOptions();
            OnPropertyChanged(nameof(CoefficientCOptions)); 

        }

        public void AddRow()
        {
            TableValues.Add(new TableValue());
           
        }
        public void CalculateResults()
        {
            if (TableValues.Count == 0)
            {
                MessageBox.Show("Пожалуйста, заполните значения для x и y перед выполнением вычислений.", "Недостаточно данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TableValues[TableValues.Count - 1].FValue = CalculateFValue(TableValues[TableValues.Count - 1].X, TableValues[TableValues.Count - 1].Y);

        }
        public double CalculateFValue(double x, double y)
        {
            
            
                double fx = 0.0; 

                if (SelectedFunctionType == "линейная")
                    fx = Convert.ToDouble(CoefficientA) * x + Convert.ToDouble(CoefficientB) * 1 + SelectedCoefficientC;
                else if (SelectedFunctionType == "квадратичная")
                    fx = Convert.ToDouble(CoefficientA) * Math.Pow(x,2) + Convert.ToDouble(CoefficientB) * y + SelectedCoefficientC;
                else if (SelectedFunctionType == "кубическая")
                    fx = Convert.ToDouble(CoefficientA) * Math.Pow(x, 3) + Convert.ToDouble(CoefficientB) * Math.Pow(y, 2) + SelectedCoefficientC;
                else if (SelectedFunctionType == "4-ой степени")
                    fx = Convert.ToDouble(CoefficientA) * Math.Pow(x, 4) + Convert.ToDouble(CoefficientB) * Math.Pow(y, 3) + SelectedCoefficientC;
                else if (SelectedFunctionType == "5-ой степени")
                    fx = Convert.ToDouble(CoefficientA) * Math.Pow(x, 5) + Convert.ToDouble(CoefficientB) * Math.Pow(y, 4) + SelectedCoefficientC;

            return fx;
        }
    }
}
