using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TableValue: INotifyPropertyChanged
    {
        private double _fvalue;
        public double X { get; set; }
        public double Y { get; set; }
        public double FValue 
        { get => _fvalue; 
            set 
            { 
                _fvalue = value;
                OnPropertyChanged(nameof(FValue)); 
            } 
        }

        private bool _isEditable = true;
        public bool IsEditable
        {
            get => _isEditable;
            set
            {
                _isEditable = value;
                OnPropertyChanged(nameof(IsEditable));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
