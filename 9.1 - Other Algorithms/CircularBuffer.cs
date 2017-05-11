using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Circular Buffer:

    A circular buffer, cyclic buffer or ring buffer is a data structure that uses a single, fixed-size buffer as if it were connected end-to-end.

    The useful property of a circular buffer is that it does not need to have its elements shuffled around when one is consumed.
        If a non-circular buffer were used then it would be necessary to shift all elements when one is consumed

    The circular buffer is well-suited as a FIFO buffer while a standard, non-circular buffer is well suited as a LIFO buffer

    If fixed size queue is good implementation strategy, for variable lenght Linked List
    http://en.wikipedia.org/wiki/Circular_buffer
    http://www.sanfoundry.com/java-program-circular-buffer/

    */
    class CircularBuffer
    {
        //        /**

        // ** Java Program to implement Circular Buffer

        // **/

 

        // import java.util.Scanner;

        ///** Class Circular Buffer **/

        //class CircularBuffer

        //{

        //    private int maxSize;

        //    private int front = 0;  

        //    private int rear = 0;  

        //    private int bufLen = 0;  

        //    private char[] buf;    

 

        //    /** constructor **/

        //    public CircularBuffer(int size) 

        //    {

        //        maxSize = size;

        //        front = rear = 0;

        //        rear = 0;

        //        bufLen = 0;

        //        buf = new char[maxSize];

        //    }

        //    /** function to get size of buffer **/

        //    public int getSize()

        //    {

        //        return bufLen;

        //    }

        //    /** function to clear buffer **/

        //    public void clear()

        //    {

        //        front = rear = 0;

        //        rear = 0;

        //        bufLen = 0;

        //        buf = new char[maxSize];

        //    }

        //    /** function to check if buffer is empty **/

        //    public boolean isEmpty() 

        //    {

        //        return bufLen == 0;

        //    }

        //    /** function to check if buffer is full **/

        //    public boolean isFull() 

        //    {

        //        return bufLen == maxSize;

        //    } 

        //    /** insert an element **/

        //    public void insert(char c) 

        //    {

        //        if (!isFull() ) 

        //        {

        //            bufLen++;

        //            rear = (rear + 1) % maxSize;

        //            buf[rear] = c;

        //        }

        //        else

        //            Console.WriteLine("Error : Underflow Exception");

        //    }

        //    /** delete an element **/

        //    public char delete() 

        //    {

        //        if (!isEmpty() ) 

        //        {

        //            bufLen--;

        //            front = (front + 1) % maxSize;

        //            return buf[front];

        //        }

        //        else 

        //        {

        //            Console.WriteLine("Error : Underflow Exception");

        //            return ' ';

        //        }

        //    }       

        //    /** function to print buffer **/

        //    public void display() 

        //    {

        //        System.out.print("\nBuffer : ");

        //        for (int i = 0; i < maxSize; i++)

        //            System.out.print(buf[i] +" ");

        //        Console.WriteLine();    

        //    }

        //}

        ///** Class CircularBufferTest  **/

        //public class CircularBufferTest

        //{

        //    public static void main(String[] args)

        //    {

        //        Scanner scan = new Scanner(System.in);

 

        //        Console.WriteLine("Circular Buffer Test\n");

        //        Console.WriteLine("Enter Size of Buffer ");

        //        int n = scan.nextInt();

        //        /* creating object of class CircularBuffer */

        //        CircularBuffer cb = new CircularBuffer(n); 

 

        //        /* Perform Circular Buffer Operations */        

        //        char ch;

 

        //        do

        //        {

        //            Console.WriteLine("\nCircular Buffer Operations");

        //            Console.WriteLine("1. insert");

        //            Console.WriteLine("2. remove");

        //            Console.WriteLine("3. size");

        //            Console.WriteLine("4. check empty");

        //            Console.WriteLine("5. check full");

        //            Console.WriteLine("6. clear");

 

        //            int choice = scan.nextInt();

        //            switch (choice)

        //            {

        //            case 1 : 

        //                Console.WriteLine("Enter character to insert");

        //                cb.insert( scan.next().charAt(0) );                                        

        //                break;                         

        //            case 2 : 

        //                Console.WriteLine("Removed Element = "+ cb.delete());

        //                break;                         

        //            case 3 : 

        //                Console.WriteLine("Size = "+ cb.getSize());

        //                break;                            

        //            case 4 : 

        //                Console.WriteLine("Empty status = "+ cb.isEmpty());

        //                break;                

        //            case 5 : 

        //                Console.WriteLine("Full status = "+ cb.isFull());

        //                break; 

        //            case 6 : 

        //                Console.WriteLine("\nBuffer Cleared\n");

        //                cb.clear();

        //                break;                                    

        //            default : Console.WriteLine("Wrong Entry \n ");

        //                break;

        //            }

        //            /* display Buffer */

        //            cb.display();     

 

        //            Console.WriteLine("\nDo you want to continue (Type y or n) \n");

        //            ch = scan.next().charAt(0);

 

        //        } while (ch == 'Y'|| ch == 'y');                                                        

        //    }    

        //}
    }
}
