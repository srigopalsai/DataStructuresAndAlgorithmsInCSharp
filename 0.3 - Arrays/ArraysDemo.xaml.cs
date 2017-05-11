using System.Collections.Generic;
using System.Windows;
using Keys = DataStructuresAndAlgorithms.TestData.Keys;
namespace DataStructuresAndAlgorithms
{
    public partial class ArraysDemo : Window
    {
        IDictionary<string, int[]> ArraysCollection = TestData.ArraysCollection;
        ArraySamples ArraySamplesObj = new ArraySamples();

        public ArraysDemo()
        {
            InitializeComponent();
        }

        private void LocalMinimaAndMaximaDemoButton_Click(object sender, RoutedEventArgs e)
        {
            int result = ArraySamples.FindLocalMinima();
            MessageBox.Show("Local Minima in the array is " + result);       
        }
        
        private void GetArrayPositionsBasedOnItsElements_Click(object sender, RoutedEventArgs e)
        {
            ArraySamples.GetArrayPositionsBasedOnItsElements();
        }

        private void FindMissingNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamples.FindMissingNumberInArray();
        }

        private void FindMissingAndRepeatedNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamples.FindMissingAndRepeatedNumbersInArray();
        }

        private void OtherProgramsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.Rotate(ArraysCollection[Keys.Sorted9Elements], 3);
            ArraySamplesObj.ProductExceptSelf(ArraysCollection[Keys.Sorted4Elements]);
        }

        private void FindAllTripplets_Click(object sender, RoutedEventArgs e)
        {
            string result = ArraySamples.FindTripletInArray();
            MessageBox.Show("Tripplet in Array result\n" + result);
        }

        private void KandaneMaxSubArrayDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.MaxSubArrayWithLargestSumTest();
        }

        private void RemoveDuplicatesButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.RemoveDuplicatesTest();
        }

        private void MinJumpsToArrayEnd_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.MinimumNumberOfJumpsToReachEndTest();
        }

        private void Missing2NumbersButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.GetTwoMissingNumbersTest();
        }

        private void Compare2ArraysButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.Compare2ArraysTest();
        }

        private void MaxSumPath_Click(object sender, RoutedEventArgs e)
        {
            ArraySamplesObj.MaximumSumPathIn2ArraysTest();
        }

        private void DebugSamplesButton_Click(object sender, RoutedEventArgs e)
        {
            ArraySamples aSamples = new ArraySamples();
            //int[] result = aSamples.IsSumOf2NumsExistsInUnSortedInArray(new int[] {6,4,2,1,3,5,8,7,9 },17);

            int[] result = aSamples.TwoSum(new int[]{ 1,2,3,4,5,6,7,8,9,10}, 19);

            RandomArrayProblems raprbs = new RandomArrayProblems();
            raprbs.Test();


        }
    }
}
