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

namespace DataStructuresAndAlgorithms.OtherAlgorithms
{
    public partial class OtherAlgorithmsDemo : Window
    {
        OtherAlgorithmSamples OtherAlgorithmSamplesObj = new OtherAlgorithmSamples();
        public OtherAlgorithmsDemo()
        {
            InitializeComponent();
        }   
        /*
        char ch1 = 'A';
			char ch2 = ' ';

			int ch3 = ch1 + ch2;
			char ch4 = Convert.ToChar(ch3);

			bool[] charTable = new bool[256];

			charTable[ch1] = true;


			A aObj1 = new A();
			aObj1.i = 10;

			A aObj2 = aObj1;
			aObj2.i = 20;

			A aObj3 = aObj1.GetClone();
			aObj3.i = 30;

			string result = DataStructuresAndAlgorithms.ArraySamples.FindTripletInArray();
			MessageBox.Show("Triplets in Array\n" + result);

			// result = DataStructuresAndAlgorithms.ArraySamples.PrintInSpiral();
			// MessageBox.Show("Triplets in Array\n" + result);
			//System.Collections.Concurrent.

			ArrayList al = new ArrayList(2);
			al.Add("Sai");
			al.Add("SriMahi");
			al.Add("SaiSri");

			System.Collections.Stack stakobj = new Stack(2);
			stakobj.Push("Sai");
			stakobj.Push("SriMahi");
			stakobj.Push("SaiSri");

			Queue queueobj = new Queue(2);
			queueobj.Enqueue("Sai");
			queueobj.Enqueue("SriMahi");
			queueobj.Enqueue("SaiSri");
        */

        private void NextLargestButton_Click(object sender, RoutedEventArgs e)
        {
            OtherAlgorithmSamplesObj.FindNextBiggestNumberTest();
//            OtherAlgorithmSamples.BranchPredictionDemo();
//            OtherAlgorithms.DispalyNumberAsText();


        }
    }
}
