using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{

    /*
    http://www.dsalgo.com/2013/03/get-find-and-delete-all-o1.html
    */
    //    class GetFindDeletOOfOneDLL
//    {
// public static void main(String[] args)
// {
//  Directory directory = new Directory(5);
//  int number1 = directory.getAvailableNumber();
//  Console.WriteLine(number1);
//  int number2 = directory.getAvailableNumber();
//  Console.WriteLine(number2);
//  Console.WriteLine(directory.isAvailable(3));
//  int number3 = directory.getAvailableNumber();
//  Console.WriteLine(number3);
//  Console.WriteLine(directory.isAvailable(3));
//  int number4 = directory.getAvailableNumber();
//  Console.WriteLine(directory.isAvailable(3));
//  Console.WriteLine(number4);
//  int number5 = directory.getAvailableNumber();
//  Console.WriteLine(number5);
//  int number6 = directory.getAvailableNumber();
//  Console.WriteLine(number6);
//  int number7 = directory.getAvailableNumber();
//  Console.WriteLine(number7);
//  directory.release(3);
//  Console.WriteLine(directory.isAvailable(3));
//  int number8 = directory.getAvailableNumber();
//  Console.WriteLine(number8);
//  Console.WriteLine(directory.isAvailable(3));
// }

// private static class Directory
// {
//  Node[] nodes;
//  Node head;

//  public Directory(int maxNumbers)
//  {
//   nodes = new Node[maxNumbers];
//   for (int i = 0; i < maxNumbers; ++i)
//   {
//    nodes[i] = new Node(i);
//    if (i != 0)
//    {
//     nodes[i].previous = nodes[i - 1];
//     nodes[i - 1].next = nodes[i];
//    }
//   }
//   nodes[maxNumbers - 1].next = nodes[0];
//   nodes[0].previous = nodes[maxNumbers - 1];
//   head = nodes[0];
//  }

//  public int getAvailableNumber()
//  {
//   if (head == null)
//    return -1;
//   int temp = head.number;
//   head.available = false;
//   if (head.next == head)
//    head = null;
//   else
//   {
//    head.previous.next = head.next;
//    head.next.previous = head.previous;
//    head = head.next;
//   }
//   return temp;
//  }

//  public boolean isAvailable(int number)
//  {
//   return nodes[number].available;
//  }

//  public void release(int number)
//  {
//   if (nodes[number].available == false)
//   {
//    nodes[number].available = true;
//    if (head == null)
//    {
//     head = nodes[number];
//     nodes[number].next = nodes[number];
//     nodes[number].previous = nodes[number];
//    } else
//    {
//     nodes[number].next = head.next;
//     nodes[number].previous = head;
//     head.next.previous = nodes[number];
//     head.next = nodes[number];
//    }
//   }
//  }

//  private static class Node
//  {
//   boolean available = true;
//   Node next;
//   Node previous;
//   int number;

//   public Node(int number)
//   {
//    this.number = number;
//   }
//  }
// }

//}
}
