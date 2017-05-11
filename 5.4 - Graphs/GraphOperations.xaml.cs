using DataStructuresAndAlgorithms.Graphs.AdjacencyList;
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

namespace DataStructuresAndAlgorithms.Graphs
{
    /// <summary>
    /// Interaction logic for GraphOperations.xaml
    /// </summary>
    public partial class GraphOperations : Window
    {
        public GraphOperations()
        {
            InitializeComponent();
        }

        MatrixOperations matrixOperations = new MatrixOperations();

        private void TraverseButton_Click(object sender, RoutedEventArgs e)
        {
            matrixOperations.TraversalTest();
        }

        private void ShortestPathButton_Click(object sender, RoutedEventArgs e)
        {
            //DataStructuresAndAlgorithms.Graphs.Matrix.UnDirectedUnWeightedGraphOperations
            //UnDirectedUnWeightedGraphOperationsObj = new Graphs.Matrix.UnDirectedUnWeightedGraphOperations();
            //UnDirectedUnWeightedGraphOperationsObj.BuildGraph();

            matrixOperations.ShortestPathTest();
        }

        private void DijkstraSPButton_Click(object sender, RoutedEventArgs e)
        {
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.DijkstraSPTest();
        }

        private void LargestRegionLengthButton_Click(object sender, RoutedEventArgs e)
        {
            matrixOperations.GetLargestRegionLengthTest();
        }
    }
}