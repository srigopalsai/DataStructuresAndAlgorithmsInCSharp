using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class GeneralAlgorithms
    {
        public static double ConvertStringToFloat(string stringToConvert)
        {
            if (string.IsNullOrWhiteSpace(stringToConvert))
            {
                throw new Exception("Input string cannot be null or empty or white space");
            }

            int charPos = 0;

            //Can repeat loop till string length or 
            int strLen = stringToConvert.Length;

            bool invalidInput = false;
            bool negativeNum = false;

            //float f =  123,4;

            // If input is negative number.
            if (stringToConvert[charPos] == '-')
            {
                negativeNum = true;
                charPos++;
            }

            int integralPart = 0;
            float fractionPart = 0.0f;

            // First half 
            while (stringToConvert[charPos] != '.' && stringToConvert[charPos] != '\n')
            {
                if (stringToConvert[charPos] >= '0' || stringToConvert[charPos] <= '9')
                {
                    integralPart = (integralPart * 10) + (int)Char.GetNumericValue(stringToConvert[charPos]);
                }
                else if (stringToConvert[charPos] == ',')
                {
                    //Need to implement.
                }
                else
                {
                    invalidInput = true;
                    break;
                }
                charPos++;
            }

            if (stringToConvert[charPos] == '.')
            {
                charPos = stringToConvert.Length - 1;

                while (stringToConvert[charPos] != '.' && charPos > 0)
                {
                    if (stringToConvert[charPos] >= '0' || stringToConvert[charPos] <= '9')
                    {
                        fractionPart = fractionPart + (int)Char.GetNumericValue(stringToConvert[charPos]);
                        fractionPart = fractionPart / 10;
                    }
                    else if (stringToConvert[charPos] == ',')
                    {
                        //Need to implement.
                    }
                    else
                    {
                        invalidInput = true;
                        break;
                    }
                    charPos--;
                }
            }

            if (invalidInput == true)
            {
                throw new Exception("Invalid Input");
            }

            double resultNum = integralPart + fractionPart;
            if (negativeNum == true)
            {
                resultNum = (-resultNum);
            }
            return resultNum;
        }
        public static void ConvertStringToFloatTest()
        {
            double result = ConvertStringToFloat("-1234.5678");
            // null or Empty String
            // Max , Min Lenght
            // Thread Culture
            // With +, - Operators
            // With Multiple dots 
        }
    }
}
