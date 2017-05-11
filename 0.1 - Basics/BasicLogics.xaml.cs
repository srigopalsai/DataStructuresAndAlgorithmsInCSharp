using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class BasicLogics : Window
    {
        BinaryAndBitwiseOperations BasicLogicSamplesObj = new BinaryAndBitwiseOperations(); 
        public BasicLogics()
        {
            InitializeComponent();
        }

        private void OperatorsPrecedenceDemoButton_Click(object sender, RoutedEventArgs e)
        {
            BasicLogicSamplesObj.OperatorsPrecedenceTest();
        }

        private void LargeNumMultiplicationDemoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
