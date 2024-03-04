using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Для отслеживания измений (для функции OnPropertyChanged)
        public ObservableCollection<string> FunctionName { get; set;} =
            new ObservableCollection<string> 
            {
                FunctionTypes[0].FunctionName, 
                FunctionTypes[1].FunctionName, 
                FunctionTypes[2].FunctionName, 
                FunctionTypes[3].FunctionName, 
                FunctionTypes[4].FunctionName,  
            }; // Список из Типов функций

        public TableValue SelectedTable { get; set; } // Выбранная строка, участвует в высчитывании формул

        public static ObservableCollection<FunctionTypes> FunctionTypes { get; set; } =
               new ObservableCollection<FunctionTypes>
               {
                   new FunctionTypes {FunctionName = "линейная"    , CoefficientA = 0, CoefficientB = 0, CoefficientC = 0},
                   new FunctionTypes {FunctionName = "квадратичная", CoefficientA = 0, CoefficientB = 0, CoefficientC = 0},
                   new FunctionTypes {FunctionName = "кубическая"  , CoefficientA = 0, CoefficientB = 0, CoefficientC = 0},
                   new FunctionTypes {FunctionName = "4-ой степени", CoefficientA = 0, CoefficientB = 0, CoefficientC = 0},
                   new FunctionTypes {FunctionName = "5-ой степени", CoefficientA = 0, CoefficientB = 0, CoefficientC = 0},
               };
        public FunctionTypes SelectedFunctionType { get; set; } // Выбранная функция, участвует в высчитывании формул
        public FunctionTypes LineFunctionType { get; set; }   = FunctionTypes[0]; // Прошлая Выбранная функция, участвует в высчитывании формул
        public FunctionTypes KvadroFunctionType { get; set; } = FunctionTypes[1]; // Прошлая Выбранная функция, участвует в высчитывании формул
        public FunctionTypes CubeFunctionType { get; set; }   = FunctionTypes[2]; // Прошлая Выбранная функция, участвует в высчитывании формул
        public FunctionTypes FourFunctionType { get; set; }   = FunctionTypes[3]; // Прошлая Выбранная функция, участвует в высчитывании формул
        public FunctionTypes FiveFunctionType { get; set; }   = FunctionTypes[4]; // Прошлая Выбранная функция, участвует в высчитывании формул


        public ObservableCollection<TableValue> TableValues { get; set; } = new ObservableCollection<TableValue>(); //Список строк в таблице

        public ObservableCollection<int> CoefficientCOptions { get; set; } = new ObservableCollection<int>(); // Список значений коэффа C


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        public MainViewModel()
        {
            TableValues = new ObservableCollection<TableValue>();
            
            CoefficientCOptions = new ObservableCollection<int>();
            SelectedFunctionType = new FunctionTypes { FunctionName = "линейная", CoefficientA = 0, CoefficientB = 0, CoefficientC = 0 };
            OnSelectedFunctionTypeChanged();
            SelectedFunctionType.CoefficientC = CoefficientCOptions[0];
         
        }

        private void UpdateCoefficientCOptions()
        {
            switch (SelectedFunctionType.FunctionName)
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

        public void InfoBase()
        {
            switch (SelectedFunctionType.FunctionName) //При смене функции восстанавливает значения
            {
                case "линейная":
                    SelectedFunctionType.CoefficientA = LineFunctionType.CoefficientA;
                    SelectedFunctionType.CoefficientB = LineFunctionType.CoefficientB;
                    SelectedFunctionType.CoefficientC = LineFunctionType.CoefficientC;

                    break;
                case "квадратичная":
                    SelectedFunctionType.CoefficientA = KvadroFunctionType.CoefficientA;
                    SelectedFunctionType.CoefficientB = KvadroFunctionType.CoefficientB;
                    SelectedFunctionType.CoefficientC = KvadroFunctionType.CoefficientC;
                    break;
                case "кубическая":
                    SelectedFunctionType.CoefficientA = CubeFunctionType.CoefficientA;
                    SelectedFunctionType.CoefficientB = CubeFunctionType.CoefficientB;
                    SelectedFunctionType.CoefficientC = CubeFunctionType.CoefficientC;
                    break;
                case "4-ой степени":
                    SelectedFunctionType.CoefficientA = FourFunctionType.CoefficientA;
                    SelectedFunctionType.CoefficientB = FourFunctionType.CoefficientB;
                    SelectedFunctionType.CoefficientC = FourFunctionType.CoefficientC;
                    break;
                case "5-ой степени":
                    SelectedFunctionType.CoefficientA = FiveFunctionType.CoefficientA;
                    SelectedFunctionType.CoefficientB = FiveFunctionType.CoefficientB;
                    SelectedFunctionType.CoefficientC = FiveFunctionType.CoefficientC;
                    break;
            }
        }
        public void RecordCoefA() 
        {
            switch (SelectedFunctionType.FunctionName) // Запоминает выбор коэфа А
            {
                case "линейная":
                    LineFunctionType.CoefficientA = SelectedFunctionType.CoefficientA;
                    break;
                case "квадратичная":
                    KvadroFunctionType.CoefficientA = SelectedFunctionType.CoefficientA;
                    break;
                case "кубическая":
                    CubeFunctionType.CoefficientA = SelectedFunctionType.CoefficientA;
                    break;
                case "4-ой степени":
                    FourFunctionType.CoefficientA = SelectedFunctionType.CoefficientA;
                    break;
                case "5-ой степени":
                    FiveFunctionType.CoefficientA = SelectedFunctionType.CoefficientA;
                    break;
            }
        }
        public void RecordCoefC() // Запоминает выбор коэфа С
        {
            switch (SelectedFunctionType.FunctionName)
            {
                case "линейная":
                    LineFunctionType.CoefficientC = SelectedFunctionType.CoefficientC;
                    break;
                case "квадратичная":
                    KvadroFunctionType.CoefficientC = SelectedFunctionType.CoefficientC;
                    break;
                case "кубическая":
                    CubeFunctionType.CoefficientC = SelectedFunctionType.CoefficientC;
                    break;
                case "4-ой степени":
                    FourFunctionType.CoefficientC = SelectedFunctionType.CoefficientC;
                    break;
                case "5-ой степени":
                    FiveFunctionType.CoefficientC = SelectedFunctionType.CoefficientC;
                    break;
            }
        }
        public void RecordCoefB() // Запоминает выбор коэфа Б
        {
            switch (SelectedFunctionType.FunctionName)
            {
                case "линейная":
                    LineFunctionType.CoefficientB = SelectedFunctionType.CoefficientB;
                    break;
                case "квадратичная":
                    KvadroFunctionType.CoefficientB = SelectedFunctionType.CoefficientB;
                    break;
                case "кубическая":
                    CubeFunctionType.CoefficientB = SelectedFunctionType.CoefficientB;
                    break;
                case "4-ой степени":
                    FourFunctionType.CoefficientB = SelectedFunctionType.CoefficientB;
                    break;
                case "5-ой степени":
                    FiveFunctionType.CoefficientB = SelectedFunctionType.CoefficientB;
                    break;
            }
        }
        public void OnSelectedFunctionTypeChanged() // Обновление об выбранной функции
        {


            InfoBase();
            UpdateCoefficientCOptions();
            //SelectedFunctionType.CoefficientC = CoefficientCOptions[0];
            OnPropertyChanged(nameof(SelectedFunctionType));
            OnPropertyChanged(nameof(CoefficientCOptions));
        }

        public void AddRow() // Добавить строку в таблицу
        {
            TableValues.Add(new TableValue());
           
        }
        public void CalculateResults() // Для подсчета значений в таблице
        {
            if (TableValues.Count == 0)
            {
                MessageBox.Show("Пожалуйста, заполните значения для x и y перед выполнением вычислений.", "Недостаточно данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectedTable.FValue = CalculateFValue(SelectedTable.X, SelectedTable.Y);
            

        }
        public double CalculateFValue(double x, double y) // Сам калькулятор
        {          
            
                double fx = 0.0; 

                if (SelectedFunctionType.FunctionName == "линейная")
                    fx = SelectedFunctionType.CoefficientA * x + SelectedFunctionType.CoefficientB * 1 + SelectedFunctionType.CoefficientC;
                else if (SelectedFunctionType.FunctionName == "квадратичная")
                    fx = SelectedFunctionType.CoefficientA * Math.Pow(x,2) + SelectedFunctionType.CoefficientB * y + SelectedFunctionType.CoefficientC;
                else if (SelectedFunctionType.FunctionName == "кубическая")
                    fx = SelectedFunctionType.CoefficientA * Math.Pow(x, 3) + SelectedFunctionType.CoefficientB * Math.Pow(y, 2) + SelectedFunctionType.CoefficientC;
                else if (SelectedFunctionType.FunctionName == "4-ой степени")
                    fx = SelectedFunctionType.CoefficientA * Math.Pow(x, 4) + SelectedFunctionType.CoefficientB * Math.Pow(y, 3) + SelectedFunctionType.CoefficientC;
                else if (SelectedFunctionType.FunctionName == "5-ой степени")
                    fx = SelectedFunctionType.CoefficientA * Math.Pow(x, 5) + SelectedFunctionType.CoefficientB * Math.Pow(y, 4) + SelectedFunctionType.CoefficientC;

            return fx;
        }
    }
}



