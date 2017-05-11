using System;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    Parentheses Balancing:
    Write a function which verifies parentheses are balanced in a string. Each open parentheses should have a corresponding close parentheses and they should correspond correctly.
    
    E.g. 1: The function should return true for the following strings:
    (if (any? x) sum (/1 x))
    I said (it's not (yet) complete). (she didn't listen)

    E.g. 2: The function should return false for the following strings:
    :-)
    ())(

    ===================================================================================================================================================================================================
    */
    partial class StringAlgorithms
    {
        public void AreParenthesesBalancedTest()
        {
            strBldr = new StringBuilder();

            bool result = false;
            result = AreParenthesesBalanced("(if (any? x) sum (/1 x))");
            strBldr.Append("\n1. if (any? x) sum (/1 x)) Result : " + result);

            result = AreParenthesesBalanced("I said (it's not (yet) complete). (she didn't listen)");
            strBldr.Append("\n2. I said (it's not (yet) complete). (she didn't listen) Result : " + result);

            result = AreParenthesesBalanced(":-)");
            strBldr.Append("\n3. :-) Result : " + result);

            result = AreParenthesesBalanced("())(");
            strBldr.Append("\n4. ())( Result : " + result);


            result = AreParenthesesBalancedRecursive("(if (any? x) sum (/1 x))", 0, 0);
            strBldr.Append("\n1. if (any? x) sum (/1 x)) Result : " + result);

            result = AreParenthesesBalancedRecursive("I said (it's not (yet) complete). (she didn't listen)", 0, 0);
            strBldr.Append("\n2. I said (it's not (yet) complete). (she didn't listen) Result : " + result);

            result = AreParenthesesBalancedRecursive(":-)", 0, 0);
            strBldr.Append("\n3. :-) Result : " + result);

            result = AreParenthesesBalancedRecursive("())(", 0, 0);
            strBldr.Append("\n4. ())( Result : " + result);

            /*
            for s in ["()", "(()", "(())", "()()", ")("]:
                print "{}: {}".format(s, AreParenthesesBalanced(s))
            */
            MessageBox.Show(strBldr.ToString());
        }

        public bool AreParenthesesBalanced(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new Exception("inputString cannot be null or empty");
            }

            if (inputString.Length > Int32.MaxValue)
            {
                throw new Exception("No of Open Paranthses allowed in string is " + Int64.MaxValue);
            }

            Int64 leftParenthesesCnt = 0;

            foreach (char inputChar in inputString)
            {
                if (inputChar == '(')
                {
                    leftParenthesesCnt++;
                }

                else if (inputChar == ')')
                {
                    if (leftParenthesesCnt > 0)
                    {
                        leftParenthesesCnt--;
                    }
                    else
                    {
                        // There are more right Paratheses than left.
                        return false;
                    }
                }
            }

            // There are more left Paratheses than right.
            return leftParenthesesCnt == 0 ? true : false;
        }

        public bool AreParenthesesBalancedRecursive(string inputString, int currentPosition, int leftParenthesesCnt)
        {
            // Base Conditions.
            // 1. Once visited all chars in string and if leftParenthesesCnt is zero then return true else return false.
            if (currentPosition == inputString.Length)
            {
                return leftParenthesesCnt == 0;
            }

            // 2. Found ')' more than '('. Or found ')' before '(' 
            if (leftParenthesesCnt < 0)
            {
                return false;
            }

            // 3. Visit each char in string linearly and call recursively by increasing the leftParenthesesCnt if '(' found or decreasing the leftParenthesesCnt.  
            // For general characters do not increment the leftParenthesesCnt.
            if (inputString[currentPosition] == '(')
            {
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt + 1);

            }
            else if (inputString[currentPosition] == ')')
            {
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt - 1);
            }
            else
            {
                // For general characters in the inputString.
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt);
            }
        }

        //for (int lpCnt = 0; lpCnt < inputString.Length; lpCnt++)
        //{
        //    if (inputString[lpCnt] == '(')
        //    {
        //        leftParenthesesCnt++;
        //    }

        //    else if (inputString[lpCnt] == ')')
        //    {
        //        if (leftParenthesesCnt > 0)
        //        {
        //            leftParenthesesCnt--;
        //        }
        //        else
        //        {
        //            // There are more right Paratheses than left.
        //            return false;
        //        }
        //    }
        //}
        
    }
}