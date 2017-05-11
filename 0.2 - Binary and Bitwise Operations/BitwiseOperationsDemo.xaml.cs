using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class BitwiseOperationsDemo : Window
    {
        BinaryAndBitwiseOperations BitwiseOperationsObj = new BinaryAndBitwiseOperations(); 
        public BitwiseOperationsDemo()
        {
            InitializeComponent();
        }

        private void BasicOperations_Click(object sender, RoutedEventArgs e)
        {
            BitwiseOperationsObj.BasicOperations();
        }

        private void ConversionsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            BitwiseOperationsObj.ConversionTest();
        }

        private void NumberOccurringOddNumberOfTimesButton_Click(object sender, RoutedEventArgs e)
        {
            BitwiseOperationsObj.NumberOccurringOddNumberOfTimesTest();
        }
    }
}