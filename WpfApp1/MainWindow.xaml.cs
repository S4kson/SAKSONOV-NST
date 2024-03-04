using System;
using System.Windows;
using System.Windows.Controls;



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


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainViewModel)DataContext).OnSelectedFunctionTypeChanged();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((MainViewModel)DataContext).RecordCoefA();
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((MainViewModel)DataContext).RecordCoefB();
        }

        private void CoefCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainViewModel)DataContext).RecordCoefC();
        }
    }
}
