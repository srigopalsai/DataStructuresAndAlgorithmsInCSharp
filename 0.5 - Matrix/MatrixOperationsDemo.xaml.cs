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
    public partial class MatrixOperationsDemo : Window
    {
        MatrixOperations MatrixOperationsObj = new MatrixOperations();
        public MatrixOperationsDemo()
        {
            InitializeComponent();
        }

        private void FloodFillAlgorithmDemoButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.FloodFillOrSeedFillAlgorithmTest();
        }

        private void WinnerInGomukuDemoButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.GomukuOrConnectFiveGameTest();
        }

        private void SearchMatrixDemoButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.SearchSortedMatrixTest();
        }

        private void DisplayMatrixInSpiralDemoButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.DisplayMatrixInSpiralTest();
        }
        private void ReplaceZeroColumnNRows_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.ReplaceZeroRowsAndColumnsTest();
        }

        private void FindBiggestBlockInMatrixDemoButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.FindBiggestBlockInMatrix();
        }



        private void MazePuzzleDemoButton_Click(object sender, RoutedEventArgs e)
        {
            string result = MatrixOperationsObj.RunMazePuzzle();
            MessageBox.Show("Result path from Maze puzzle\n" + result);
        }

        private void TransposeMatrixtton_Click(object sender, RoutedEventArgs e)
        {
            MatrixOperationsObj.TransposeMatrixTest();
        }
    }
}