using System.Collections.Generic;
using System.Windows;
using Keys = DataStructuresAndAlgorithms.TestData.Keys;
namespace DataStructuresAndAlgorithms
{
    public partial class ArraysDemo : Window
    {
        IDictionary<string, int[]> ArraysCollection = TestData.ArraysCollection;
        ArrayProblems ArrayProblemsObj = new ArrayProblems();

        public ArraysDemo()
        {
            InitializeComponent();
        }

        private void LocalMinimaAndMaximaDemoButton_Click(object sender, RoutedEventArgs e)
        {
            int result = ArrayProblems.FindLocalMinima();
            MessageBox.Show("Local Minima in the array is " + result);       
        }
        
        private void GetArrayPositionsBasedOnItsElements_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblems.GetArrayPositionsBasedOnItsElements();
        }

        private void FindMissingNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblems.FindMissingNumberInArray();
        }

        private void FindMissingAndRepeatedNumberDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblems.FindMissingAndRepeatedNumbersInArray();
        }

        private void OtherProgramsDemoButton_Click(object sender, RoutedEventArgs e)
        {
           // ArrayProblemsObj.Rotate(ArraysCollection[Keys.Sorted9Elements], 3);
            ArrayProblemsObj.ProductExceptSelf(ArraysCollection[Keys.Sorted4Elements]);
        }

        private void FindAllTripplets_Click(object sender, RoutedEventArgs e)
        {
            string result = ArrayProblems.FindTripletInArray();
            MessageBox.Show("Tripplet in Array result\n" + result);
        }

        private void KandaneMaxSubArrayDemoButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblemsObj.MaxSubArrayWithLargestSumTest();
        }

        private void RemoveDuplicatesButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblemsObj.RemoveDuplicatesTest();
        }

        private void MinJumpsToArrayEnd_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblemsObj.MinimumNumberOfJumpsToReachEndTest();
        }

        private void Missing2NumbersButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblemsObj.GetTwoMissingNumbersTest();
        }

        private void Compare2ArraysButton_Click(object sender, RoutedEventArgs e)
        {
            //ArrayProblemsObj.Compare2ArraysTest();
        }

        private void MaxSumPath_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblemsObj.MaximumSumPathIn2ArraysTest();
        }

        private void DebugSamplesButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayProblems aSamples = new ArrayProblems();
            //int[] result = aSamples.IsSumOf2NumsExistsInUnSortedInArray(new int[] {6,4,2,1,3,5,8,7,9 },17);

            int[] result = aSamples.TwoSum(new int[]{ 1,2,3,4,5,6,7,8,9,10}, 19);

            RandomArrayProblems raprbs = new RandomArrayProblems();
            raprbs.Test();


        }
    }
}
