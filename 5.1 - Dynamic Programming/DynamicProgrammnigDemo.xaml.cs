using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class DynamicProgrammnigDemo : Window
    {
        DynamicProgrammingSamples DynamicProgrammingSamplesObj = new DynamicProgrammingSamples();
        public DynamicProgrammnigDemo()
        {
            InitializeComponent();
        }

        private void FactorialDemoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FibonacciNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            DynamicProgrammingSamplesObj.FibonacciSequenceTest();
        }

        private void LCSDemoButton_Click(object sender, RoutedEventArgs e)
        {
            DynamicProgrammingSamplesObj.LongestCommonSubSequenceDPTest(); 
        }

        private void MinimumCoinChangeButton_Click(object sender, RoutedEventArgs e)
        {
            DynamicProgrammingSamplesObj.MinimumCoinsTest();
        }

        private void LongestPalindromeStrDemoButton_Click(object sender, RoutedEventArgs e)
        {
            DynamicProgrammingSamplesObj.LargestPalindromeManacherAlgorithmTest();
        }
    }
}