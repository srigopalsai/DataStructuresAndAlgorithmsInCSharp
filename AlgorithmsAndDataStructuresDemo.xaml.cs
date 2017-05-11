using System;
//using System.Collections.Generic;
using System.Collections;
using System.Windows;
using DataStructuresAndAlgorithms.OtherAlgorithms;

namespace DataStructuresAndAlgorithms
{
	public partial class AlgorithmsAndDataStructuresDemo : Window
	{
		public AlgorithmsAndDataStructuresDemo()
		{
			InitializeComponent();
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;

            Console.WriteLine("Some program's output gets displayed here, e.g Graphs Samples");
        }

        private void BasicSamplesDemoButton_Click(object sender, RoutedEventArgs e)
        {
            BasicLogics BasicLogicObj = new BasicLogics();
            BasicLogicObj.Show();
        }

        private void BitwiseOperatorsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            BitwiseOperationsDemo BitwiseOperationsDemoObj = new BitwiseOperationsDemo();
            BitwiseOperationsDemoObj.Show();
        }

        private void ArrayOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
			ArraysDemo ArraysDemoObj = new ArraysDemo();
			ArraysDemoObj.Show();
		}

        //============================================================================================================================================================		
        private void StackOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
			StackOperations StackDemoObj = new StackOperations();
			//StackDemoObj.StackOperationsDemo();

			StackOperations StackOperationsObj = new StackOperations();
			StackOperationsObj.PushPopGetMinWithConstantTime();

			StackOperations.ReturnSameStackInReverseOrder();

			StackOperations.RunTowersOfHanoiMoveWithOutStack();
		}

		private void QueueOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
			QueueSamples.QueueOperationsWithStack();

			QueueOperations QueueOperationsObj = new QueueOperations();
			QueueOperationsObj.SortElementsUsing2Queues();
			/*
		   int will = 1 , queueElement;
	
			printf("\Queue Operations with Arrays\n");

			// 1. Initialize queue .
			InitializeQueue();
	
			while(will == 1)
			{
				printf("\n1. Add Element to queue. \n2. Delete Element from queue.\n  Any other key to exit\n");
				scanf("%d", &will);

				switch(will)
				{
					case 1:

						printf("\nEnter the data... \n");
						scanf("%d" , &queueElement);
						EnQueuequeueElement(queueElement);
						break;

					case 2: 

						queueElement = DeQueuequeueElement();
						printf("\nValue returned from queue is  %d\n" , queueElement );
						break;

					default: 
						printf("\nInvalid Choice ... \n");
				}
			}   */
		}
		
		private void VirtualFunctionButton_Click(object sender, RoutedEventArgs e)
		{
			ClassA AObj = new ClassA();
			AObj.VDisplay();
			AObj.Display();
			AObj = new ClassB();
			AObj.VDisplay();
			AObj.Display();

			ClassB BObj = new ClassB();
			BObj.Display();
			BObj.VDisplay();
			//BObj = new ClassA();
		}

		private void LinkedListDemoButton_Click(object sender, RoutedEventArgs e)
		{
			LinkedListDemo LinkedListDemoWin = new LinkedListDemo();
			LinkedListDemoWin.Show();
		}

		private void SortingDemo_Click(object sender, RoutedEventArgs e)
		{
			SortingDemo SortingDemoObject = new SortingDemo();
			SortingDemoObject.Show();
		}

		private void TreeOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
			TreeDemo TreeDemoObject = new TreeDemo();
			TreeDemoObject.Show();
		}

        //============================================================================================================================================================

        private void SearchingDemo_Click(object sender, RoutedEventArgs e)
		{
			SearchingDemo SearchDemoObj = new SearchingDemo();
			SearchDemoObj.Show();
		}

		private void DemoButton_Click(object sender, RoutedEventArgs e)
		{
            OtherAlgorithmsDemo OtherAlgorithmsDemoObj = new OtherAlgorithmsDemo();
            OtherAlgorithmsDemoObj.Show();
		}

		private void StringAlgorithmsDemo_Click(object sender, RoutedEventArgs e)
		{
			StringAlgorithmsDemo StringAlgorithmsDemoObj = new StringAlgorithmsDemo();
			StringAlgorithmsDemoObj.Show();
		}

		private void DPDemoButton_Click(object sender, RoutedEventArgs e)
		{
			DynamicProgrammnigDemo DynamicProgrammnigDemoObj = new DynamicProgrammnigDemo();
			DynamicProgrammnigDemoObj.Show();
		}

		private void GeneralDemoButton_Click(object sender, RoutedEventArgs e)
		{
			GeneralCodingQustionsDemo GeneralCodingQustionsDemoObj = new GeneralCodingQustionsDemo();
			GeneralCodingQustionsDemoObj.Show();
		}

		private void MatrixOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
			MatrixOperationsDemo MatrixOperationsDemoObj = new MatrixOperationsDemo();
			MatrixOperationsDemoObj.Show();
		}

        //============================================================================================================================================================
		private void GraphOperationsDemoButton_Click(object sender, RoutedEventArgs e)
		{
            Graphs.GraphOperations go = new Graphs.GraphOperations();
            go.Show();
		}

		private void RecursionDemoButton_Click(object sender, RoutedEventArgs e)
		{
			RecursionDemo RecursionDemoWinObj = new RecursionDemo();
			RecursionDemoWinObj.Show();
		}

        private void GreedyAlgorithmsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PVersesNP_Click(object sender, RoutedEventArgs e)
        {

        }

        //============================================================================================================================================================
	}
	partial class SetOperations
	{
		System.Collections.Generic.HashSet<object> hashSetObj = new System.Collections.Generic.HashSet<object>();
		Hashtable hashObject = new Hashtable();
		ArrayList ArrayListObj = new ArrayList(); 
		//System.Collections.ObjectModel.
		int[] intrArr = new int[10];
		int arrayIndex = 0;
		//Hashtable<int, object> objectSet = new Hashtable<int, object>();
		public bool Add(string value)
		{
			//ArrayListObj.IndexOf( 
			if (arrayIndex == 9)
			{
				MessageBox.Show("Stack is full");
				return false;
			}
			//hashSetObj.GetHashCode(
			hashObject.Add(arrayIndex, value);
			arrayIndex++;

			return true;
		}
		public bool Remove(string value)
		{
//int hashKey =           hashObject.
			return false;
		}
	}
}
class A
{
	public int i;
	public A GetClone()
	{
		return (A)this.MemberwiseClone();
	}
}
/*
Text:    abc def ant cow
Regex:   a..
Matches: abc def ant cow
abc
ant

Text:    abc anaconda ant cow apple
Regex:   a\w\w
Matches: abc anaconda ant cow apple
abc
ana
ant
app

Backslash and an uppercase 'W' (\W) will match any non-word character. 

 */