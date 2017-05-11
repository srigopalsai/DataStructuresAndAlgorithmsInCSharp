using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    //http://www.careercup.com/question?id=5203498857660416
    partial class OtherAlgorithmSamples
    {
        /*
        Given a number give its english form 
        1-> One 
        999 -> Nine hundred and ninety nine 

        Max number is: 999, 999, 999
        */
        static Dictionary<int, string> numCollection = new Dictionary<int, string>();

        private static void FillNumCollection()
        {
            numCollection.Add(0, "Zero");
            numCollection.Add(1, "One");
            numCollection.Add(2, "Two");
            numCollection.Add(3, "Three");
            numCollection.Add(4, "Four");
            numCollection.Add(5, "Five");
            numCollection.Add(6, "Six");
            numCollection.Add(7, "Seven");
            numCollection.Add(8, "Eight");
            numCollection.Add(9, "Nine");
            numCollection.Add(10, "Ten");//10 Power 1
            numCollection.Add(11, "Eleven");
            numCollection.Add(12, "Twelve");
            numCollection.Add(13, "Thirteen");
            numCollection.Add(14, "Fourteen");
            numCollection.Add(15, "Fiveteen");
            numCollection.Add(16, "Sixteen");
            numCollection.Add(17, "Seventeen");
            numCollection.Add(18, "Eighteen");
            numCollection.Add(19, "Nineteen");
            numCollection.Add(20, "Twenty");

            numCollection.Add(30, "Thirty");
            numCollection.Add(40, "Fourty");
            numCollection.Add(50, "Fifty");
            numCollection.Add(60, "Sixty");
            numCollection.Add(70, "Seventy");
            numCollection.Add(80, "Eighty");
            numCollection.Add(90, "Ninty");

            numCollection.Add(100, "Hundred");      // 10 Power of 2
            numCollection.Add(1000, "Thousand");    // 10 Power of 3
            numCollection.Add(10000, "Thousand");   // 10 Power of 4
            numCollection.Add(100000, "Lakh");      // 10 Power of 5  -> Hundred thousand
            //numCollection.Add(1000000, "Ten Lakh");  // 10 Power of 6
            numCollection.Add(1000000, "Million");  // 10 Power of 6
            //numCollection.Add(10000000, "10 Million or 1 Crore");  // 10 Power of 6
            //numCollection.Add(1000000000, "Billion");
            //numCollection.Add(1000000000000, "Trillion");
            //1,000,000,000
        }

        public static void DispalyNumberAsText()
        {
            FillNumCollection();
            Int32 inputNumber = 9999;
            Int32 OriginalNumber = inputNumber;
            StringBuilder numInText = new StringBuilder();

            int reminder = 0;
            int firstNumPart = 0;
            while (inputNumber > 0)
            {
                if (inputNumber <= 20 || (inputNumber <= 100 && inputNumber % 10 == 0))
                {
                    numInText.Append(numCollection[inputNumber]);
                    reminder = 0;
                }
                else if (inputNumber > 20 && inputNumber < 100)
                {
                    reminder = inputNumber % 10;
                    firstNumPart = inputNumber - reminder;
                    numInText.Append(numCollection[firstNumPart] + " ");
                }
                else if (inputNumber >= 100 && inputNumber <= 999)
                {
                    reminder = inputNumber % 100;
                    firstNumPart = (inputNumber - reminder) / 100;
                    numInText.Append(numCollection[firstNumPart] + " " + numCollection[100] + " and ");
                }
                else if (inputNumber >= 1000 && inputNumber <= 9999)
                {
                    reminder = inputNumber % 1000;
                    firstNumPart = (inputNumber - reminder) / 1000;
                    numInText.Append(numCollection[firstNumPart] + " " + numCollection[1000] + " and ");
                }

                // Need to fix the below logic
                //else if (inputNumber >= 10000 && inputNumber <= 99999)
                //{
                //    reminder = inputNumber % 10000;
                //    firstNumPart = (inputNumber - reminder) / 10000;
                //    numInText.Append(numCollection[firstNumPart] + " " + numCollection[10000] + " and ");
                //}
                //else if (inputNumber >= 100000 && inputNumber <= 999999)
                //{
                //    reminder = inputNumber % 100000;
                //    firstNumPart = (inputNumber - reminder) / 100000;
                //    numInText.Append(numCollection[firstNumPart] + " " + numCollection[100000] + " and ");
                //}
                //else if (inputNumber >= 1000000 && inputNumber <= 9999999)
                //{
                //    reminder = inputNumber % 1000000;
                //    firstNumPart = (inputNumber - reminder) / 1000000;
                //    numInText.Append(numCollection[firstNumPart] + " " + numCollection[1000000] + " and ");
                //}
                //else if (inputNumber >= 100000000 && inputNumber <= 99999999)
                //{
                //    reminder = inputNumber % 100000000;
                //    firstNumPart = (inputNumber - reminder) / 100000000;
                //    numInText.Append(numCollection[firstNumPart] + " " + numCollection[100000000] + " and ");
                //}
                //else if (inputNumber >= 100000000 && inputNumber <= 999999999)
                //{
                //    reminder = inputNumber % 100000000;
                //    firstNumPart = (inputNumber - reminder) / 100000000;
                //    numInText.Append(numCollection[firstNumPart] + " " + numCollection[100000000] + " and ");
                //}

                inputNumber = reminder;
            }

            MessageBox.Show("The Given Number is " + OriginalNumber + " and its text form is \n" + Convert.ToString(numInText));
        }

        public static void DisplayText()
        {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] thousands = { "", "thousand", "million", "billion", "trillion" };
            //int num = 9999;

            //def num_words(num):
            //       StringBuilder words = new StringBuilder();
            //if (num == 0)
            //{
            //    words.Append("zero");
            //}
            //else
            //{
            //    numstr = str(num);
            //    groups = (len(numstr) + 2) / 3;
            //    numstr = numstr.zfill(groups * 3);
            //    for i in range(0, groups * 3, 3):
            //        h = int(numstr[i])
            //        t = int(numstr[i+1])
            //        u = int(numstr[i+2])
            //        g = groups - (i / 3 + 1)
            //        if (h >= 1)
            //        {
            //            words.Append(units[h])
            //            words.Append("hundred")
            //        }
            //        if (t > 1)
            //        {
            //            words.Append(tens[t])
            //            if u >= 1:
            //                words.Append(units[u])
            //        }
            //        elif t == 1:
            //    {
            //        if u >= 1:
            //                words.Append(teens[u])
            //            else:
            //                words.Append(tens[t])
            //    }
            //    else
            //    {
            //            if u >= 1:
            //                words.Append(units[u])
            //    }
            //        if g >= 1 and (h + t + u) > 0:
            //            words.Append(thousands[g])
            //return " ".join(words)
        }
    }
}