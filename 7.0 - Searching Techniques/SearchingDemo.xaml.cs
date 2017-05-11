using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class SearchingDemo : Window
    {
        SearchingAlgorithms SearchingAlgorithmsObj = new SearchingAlgorithms();
        public SearchingDemo()
        {
            InitializeComponent();
        }

        private void BinarySearchDemoButton_Click(object sender, RoutedEventArgs e)
        {
            SearchingAlgorithmsObj.BinarySearchTest();
        }

        private void BinarySearchAdvancedDemoButton_Click(object sender, RoutedEventArgs e)
        {
            int[] nums = { 8, 9, 10, 1, 2, 3, 4, 5, 6, 7 };
            int elementToFind = 10;
            int resultPosition = SearchingAlgorithmsObj.BinarySearchInSortedRandomArray(nums, elementToFind);
            MessageBox.Show("Position of 10 in array is " + resultPosition);
        }


        private void SelectNthLargestDemoButton_Click(object sender, RoutedEventArgs e)
        {
            SearchingAlgorithmsObj.SelectionAlgorithmKthSmallestTest();
        }
    }
}
