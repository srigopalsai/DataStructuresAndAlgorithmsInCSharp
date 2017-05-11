using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class RecursionDemo : Window
    {
        RecursionSamples RecursionSamplesObj = new RecursionSamples();
        public RecursionDemo()
        {
            InitializeComponent();
        }

        private void CalculatePowerDemoButton_Click(object sender, RoutedEventArgs e)
        {
            RecursionSamplesObj.PowerTest();
        }

        private void FibonacciNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            RecursionSamplesObj.FibonacciSequenceTest();
        }

        private void RecursionDemoButton_Click(object sender, RoutedEventArgs e)
        {
            RecursionSamplesObj.RecursionInLoopTest();
        }

        private void RecursiveRecursionDemoButton_Click(object sender, RoutedEventArgs e)
        {
            RecursionSamplesObj.ReverseArrayTest();
        }
    }
}