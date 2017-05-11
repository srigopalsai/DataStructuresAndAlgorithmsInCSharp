using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataStructuresAndAlgorithms
{
    public partial class SortingDemo : Window
    {
        SortingSamples SortingSamplesObj = new SortingSamples();

        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.BubbleSortTest();
        }

        private void SelectionSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.SelectionSortTest();
        }

        private void InsertionSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.InsertionSortTest();
        }

        private void QuickSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.RunQuickSortTests();
        }

        private void MergeSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.RunMergeSortTests();
        }

        private void HeapSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.RunHeapSortTests();
        }

        private void CountingSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.CountingSortTest();
        }
        
        private void OddEvenSortButton_Click(object sender, RoutedEventArgs e)
        {
            SortingSamplesObj.OddEvenOrBrickSortTest();
        }

        public SortingDemo()
        {
            InitializeComponent();
        }
    }
}
