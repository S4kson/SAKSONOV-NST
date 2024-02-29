using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;


namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).CalculateResults();
        }



        private void TextBox1_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox2_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void FunctionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainViewModel)DataContext).OnSelectedFunctionTypeChanged();

        }
    }
}
