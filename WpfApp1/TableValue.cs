using System.ComponentModel;


namespace WpfApp1
{
    public class TableValue: INotifyPropertyChanged // Данные для заполнения строк в таблице
    {
        private double _fvalue;
        public double X { get; set; }
        public double Y { get; set; }
        public double FValue // Для заполнения переменной приватной _fvalue
        { get => _fvalue; 
            set 
            { 
                _fvalue = value;
                OnPropertyChanged(nameof(FValue)); 
            } 
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
