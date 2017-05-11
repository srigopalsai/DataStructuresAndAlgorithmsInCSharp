using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace DataStructuresAndAlgorithms
{
    public class TestData
    {
        public class Keys
        {
            public const string Null = "Null";
            public const string Empty = "Empty";
            public const string Zero = "Zero";
            public const string OneElement = "OneElement";
            public const string OneAndOne = "OneAndOne";
            public const string OneElementMinus = "OneElementMinus";
            public const string IntMinVal = "IntMinVal";
            public const string IntMaxVal = "IntMaxVal";
            public const string IntMinMaxVal = "IntMinMaxVal";

            public const string Sorted2Elements = "Sorted2Elements";
            public const string Sorted3Elements = "Sorted3Elements";
            public const string Sorted4Elements = "Sorted4Elements";
            public const string Sorted5Elements = "Sorted5Elements";
            public const string sorted6Elements = "sorted6Elements";
            public const string Sorted7Elements = "Sorted7Elements";
            public const string Sorted8Elements = "Sorted8Elements";
            public const string Sorted9Elements = "Sorted9Elements";
            public const string Sorted10Elements = "Sorted10Elements";
            public const string Sorted11Elements = "Sorted11Elements";
            public const string Sorted12Elements = "Sorted12Elements";
            public const string Sorted13Elements = "Sorted13Elements";

            public const string BestCaseNearlySortedArry = "BestCaseNearlySortedArry";

            public const string AverageCaseFewSortedArry1 = "AverageCaseFewSortedArry1";
            public const string AverageCaseFewSortedArry2 = "AverageCaseFewSortedArry2";
            public const string AverageCaseFewSortedArry3 = "AverageCaseFewSortedArry3";
            public const string AverageCaseFewSortedArry4 = "AverageCaseFewSortedArry4";
            public const string AverageCaseFewSortedArry5 = "AverageCaseFewSortedArry5";
            public const string AverageCaseFewSortedArry6 = "AverageCaseFewSortedArry6";

            public const string WorstCaseReversedArry1 = "WorstCaseReversedArry1";
            public const string WorstCaseFewDuplsArry2 = "WorstCaseFewDuplsArry2";
            public const string WorstCaseMoreDuplsArry3 = "WorstCaseMoreDuplsArry3";
            public const string WorstCaseMoreDuplsArry4 = "WorstCaseMoreDuplsArry4";

            public const string RandomElementsArray1 = "RandomElementsArray1";
            public const string RandomElementsArray2 = "RandomElementsArray2";
            public const string RandomElementsArray3 = "RandomElementsArray3";
            public const string RandomElementsArray4 = "RandomElementsArray4";

            public const string UnSorted5Elements = "UnSorted5Elements";
            public const string TenTo70DecOddNums = "TenTo70DecOddNums";
            public const string TwentyTo60DecEvenNums = "TwentyTo60DecEvenNums";
            public const string SeventyTo90DecNums = "SeventyTo90DecNums";

            public const string Sorted8DecElements = "Sorted8DecElements";
            public const string Sorted10DecElements = "Sorted10DecElements";

            public const string Palindrome2Elements = "Palindrome2Elements";
            public const string Palindrome2ElementsNve = "Palindrome2ElementsNve";
            public const string Palindrome2ElementsMinus = "Palindrome2ElementsMinus";
            public const string Palindrome3ElementsMinus = "Palindrome3ElementsMinus";
            public const string Palindrome3Elements = "Palindrome3Elements";
            public const string Palindrome3ElementsNve = "Palindrome3ElementsNve";
            public const string Palindrome4Elements = "Palindrome4Elements";
            public const string Palindrome4ElementsNve = "Palindrome4ElementsNve";
            public const string Palindrome5Elements = "Palindrome5Elements";
            public const string Palindrome6Elements = "Palindrome6Elements";
            public const string Palindrome9Elements = "Palindrome9Elements";
            public const string Palindrome9ElementsNve = "Palindrome9ElementsNve";

            public const string SortedDup2Of2Elements = "SortedDup2Of2Elements";
            public const string SortedDup3Of3Elements = "SortedDup3Of3Elements";
            public const string SortedDup2Of3Elements = "SortedDup2Of3Elements";
            public const string SortedDup4Of4Elements = "SortedDup4Of4Elements";
            public const string SortedDup5Of5Elements = "SortedDup5Of5Elements";
            public const string SortedDup6Of6Elements = "SortedDup6Of6Elements";
            public const string SortedDup3Of6Elements = "SortedDup3Of6Elements";
            public const string SortedDup5Of11Elements = "SortedDup5Of11Elements";

            public const string Random10Numbers = "Random10Numbers";
            public const string Random100Numbers = "Random100Numbers";
            public const string Random1000Numbers = "Random1000Numbers";
            public const string Random10000Numbers = "Random10000Numbers";

            public const string Random9Till4Numbers = "Random9Till4Numbers";
            public const string Random6Till45Numbers = "Random6Till45Numbers";
            public const string Plus20AndPlus10 = "Plus20AndPlus10";
            public const string Minus20AndPlus10 = "Minus20AndPlus10";

            public const string Minus10nd20nd10 = "Minus10nd20nd10";
            public const string Ninty9nd99 = "Ninty9nd99";
            public const string Thirty10nd20nd40 = "Thirty10nd20nd40";
            public const string Random00To60 = "Random00To60";

            public const string FiveByFive1 = "FiveByFive1";
            public const string FiveByFive2 = "FiveByFive2";
            public const string SevenBySeven1 = "SevenBySeven1";
            public const string SevenBySeven2 = "SevenBySeven2";
            public const string TenByTen1 = "TenByTen1";
        }

        static int[] RandomList = null;
        static int RandomListPos = 0;

        public static int TestCaseNo = 0;
        public static int TestCasesCount = 0;
        public static int TestCasesFailed = 0;
        public static int TestCasesPassed = 0;

        public static StringBuilder StrBldrMessage = new StringBuilder();
        public static IDictionary<string, int[]> ArraysCollection = new Dictionary<string, int[]>();
        public static IDictionary<string, int[,]> BinaryMatrixCollection = new Dictionary<string, int[,]>();
        public static IDictionary<string, int[,]> MatrixCollection = new Dictionary<string, int[,]>();
        public static IDictionary<string, KeyValuePair<int, int[]>> ArraysWithKthPosition = new Dictionary<string, KeyValuePair<int, int[]>>();

        static TestData()
        {
            try
            {
                ArraysCollection.Add(Keys.Null, null);
                ArraysCollection.Add(Keys.Empty, new int[] { });
                ArraysCollection.Add(Keys.Zero, new int[] { 0 });
                ArraysCollection.Add(Keys.OneElement, new int[] { 1 });
                ArraysCollection.Add(Keys.OneAndOne, new int[] { 1, 1 });
                ArraysCollection.Add(Keys.OneElementMinus, new int[] { -1 });
                ArraysCollection.Add(Keys.IntMinVal, new int[] { int.MinValue });
                ArraysCollection.Add(Keys.IntMaxVal, new int[] { int.MaxValue });
                ArraysCollection.Add(Keys.IntMinMaxVal, new int[] { int.MinValue, int.MaxValue });
                ArraysCollection.Add(Keys.Sorted2Elements, new int[] { 1, 2 });
                ArraysCollection.Add(Keys.Sorted3Elements, new int[] { 1, 2, 3 });
                ArraysCollection.Add(Keys.Sorted4Elements, new int[] { 1, 2, 3, 4 });
                ArraysCollection.Add(Keys.Sorted5Elements, new int[] { 1, 2, 3, 4, 5 });
                ArraysCollection.Add(Keys.sorted6Elements, new int[] { 1, 2, 3, 4, 5, 6 });
                ArraysCollection.Add(Keys.Sorted7Elements, new int[] { 1, 2, 3, 4, 5, 6, 7 });
                ArraysCollection.Add(Keys.Sorted8Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
                ArraysCollection.Add(Keys.Sorted9Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                ArraysCollection.Add(Keys.Sorted10Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                ArraysCollection.Add(Keys.Sorted11Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
                ArraysCollection.Add(Keys.Sorted12Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
                ArraysCollection.Add(Keys.Sorted13Elements, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });

                ArraysCollection.Add(Keys.BestCaseNearlySortedArry, new int[] { 1, 2, 3, 4, 6, 5 });

                ArraysCollection.Add(Keys.AverageCaseFewSortedArry1, new int[] { 3, 2, 1, 4, 5, 6 });
                ArraysCollection.Add(Keys.AverageCaseFewSortedArry2, new int[] { 6, 2, 3, 1, 5, 4 });

                ArraysCollection.Add(Keys.WorstCaseReversedArry1, new int[] { 6, 5, 4, 3, 2, 1 });
                ArraysCollection.Add(Keys.WorstCaseMoreDuplsArry4, new int[] { 4, 5, 6, 1, 2, 3 });
                ArraysCollection.Add(Keys.UnSorted5Elements, new int[] { 5, 4, 1, 3, 2 });
                ArraysCollection.Add(Keys.WorstCaseFewDuplsArry2, new int[] { 1, 3, 1, 2, 1, 3 });
                ArraysCollection.Add(Keys.WorstCaseMoreDuplsArry3, new int[] { 1, 1, 2, 2, 1, 2 });

                ArraysCollection.Add(Keys.AverageCaseFewSortedArry3, new int[] { 1, 12, 5, 26, 7, 14, 3, 7, 2 });
                ArraysCollection.Add(Keys.AverageCaseFewSortedArry4, new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 });
                ArraysCollection.Add(Keys.AverageCaseFewSortedArry5, new int[] { 40, 30, 50, 20, 60, 10 });
                ArraysCollection.Add(Keys.AverageCaseFewSortedArry6, new int[] { 30, 20, 10, 50, 60, 40 });

                ArraysCollection.Add(Keys.RandomElementsArray1, new int[] { -6, -6, 2, 2, 2, 10, 10, 10, 6, -6, 2, 2, 2, 2, 2 });
                ArraysCollection.Add(Keys.RandomElementsArray2, new int[] { -6, -6, 2, 2, 2, 10, 10, 10, -6, 6, 2, 2, 2, 2, 2 });
                ArraysCollection.Add(Keys.RandomElementsArray3, new int[] { -6, -6, 2, 2, 2, 10, 10, 10, -6, -6, 2, 2, 2, 2, 2 });
                ArraysCollection.Add(Keys.RandomElementsArray4, new int[] { 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 15 });

                ArraysCollection.Add(Keys.TenTo70DecOddNums, new int[] { 10 });
                ArraysCollection.Add(Keys.TwentyTo60DecEvenNums, new int[] { 20, 40 });
                ArraysCollection.Add(Keys.SeventyTo90DecNums, new int[] { 80, 90 });

                ArraysCollection.Add(Keys.Sorted8DecElements, new int[] { 10, 20, 30, 40, 50, 60, 70, 80 });
                ArraysCollection.Add(Keys.Sorted10DecElements, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 });

                ArraysCollection.Add(Keys.Palindrome2Elements, new int[] { 1, 1 });
                ArraysCollection.Add(Keys.Palindrome2ElementsNve, new int[] { 1, 2 });
                ArraysCollection.Add(Keys.Palindrome2ElementsMinus, new int[] { -1, -1 });
                ArraysCollection.Add(Keys.Palindrome3ElementsMinus, new int[] { -1, 0, 1 });
                ArraysCollection.Add(Keys.Palindrome3Elements, new int[] { 1, 2, 1 });
                ArraysCollection.Add(Keys.Palindrome3ElementsNve, new int[] { 1, 0, 0 });
                ArraysCollection.Add(Keys.Palindrome4Elements, new int[] { 1, 2, 2, 1 });
                ArraysCollection.Add(Keys.Palindrome4ElementsNve, new int[] { 1, 2, 2, 2 });
                ArraysCollection.Add(Keys.Palindrome5Elements, new int[] { 1, 2, 3, 2, 1 });
                ArraysCollection.Add(Keys.Palindrome6Elements, new int[] { 1, 2, 3, 3, 2, 1 });
                ArraysCollection.Add(Keys.Palindrome9Elements, new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 });
                ArraysCollection.Add(Keys.Palindrome9ElementsNve, new int[] { 1, 2, 3, 4, 5, 5, 3, 2, 1 });

                ArraysCollection.Add(Keys.SortedDup2Of2Elements, new int[] { 1, 1 });
                ArraysCollection.Add(Keys.SortedDup3Of3Elements, new int[] { 1, 1, 1 });
                ArraysCollection.Add(Keys.SortedDup2Of3Elements, new int[] { 1, 2, 2 });
                ArraysCollection.Add(Keys.SortedDup4Of4Elements, new int[] { 1, 1, 1, 1 });
                ArraysCollection.Add(Keys.SortedDup5Of5Elements, new int[] { 1, 1, 1, 1, 1 });
                ArraysCollection.Add(Keys.SortedDup6Of6Elements, new int[] { 1, 1, 1, 1, 1, 1 });
                ArraysCollection.Add(Keys.SortedDup3Of6Elements, new int[] { 1, 2, 2, 3, 3, 1 });
                ArraysCollection.Add(Keys.SortedDup5Of11Elements, new int[] { 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5 });

                ArraysCollection.Add(Keys.Random9Till4Numbers, new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });//Useful in Max Sum Array:
                ArraysCollection.Add(Keys.Random6Till45Numbers, new int[] { 1, 4, 45, 6, 0, 19 });

                ArraysCollection.Add(Keys.Plus20AndPlus10, new int[] { 20, 10 });
                ArraysCollection.Add(Keys.Minus20AndPlus10, new int[] { -20, 10 });
                ArraysCollection.Add(Keys.Minus10nd20nd10, new int[] { -10, 20, 10 });
                ArraysCollection.Add(Keys.Ninty9nd99, new int[] { 99, 99 });
                ArraysCollection.Add(Keys.Thirty10nd20nd40, new int[] { 30, 10, 20, 40 });
                ArraysCollection.Add(Keys.Random00To60, new int[] { 50, 20, 40, 10, 30, 60, 00 });

                foreach (KeyValuePair<string, int[]> arrayItem in ArraysCollection)
                {
                    if (arrayItem.Value == null)
                        continue;

                    int nthNum = GetRandom(arrayItem.Value.Length);
                    ArraysWithKthPosition.Add(arrayItem.Key, new KeyValuePair<int, int[]>(nthNum, arrayItem.Value));
                }

                GenerateRandomArray(ArraysCollection, Keys.Random10Numbers, 10 , 1, 100);
                GenerateRandomArray(ArraysCollection, Keys.Random100Numbers, 100, 1, 1000);
                GenerateRandomArray(ArraysCollection, Keys.Random1000Numbers, 1000, 1, 10000);

                //====================================================================================================================

                BinaryMatrixCollection.Add(Keys.Null, null);
                BinaryMatrixCollection.Add(Keys.Empty, new int[,] { { } });
                BinaryMatrixCollection.Add(Keys.Zero, new int[,] { { 0 }, { 0 } });
                BinaryMatrixCollection.Add(Keys.OneElement, new int[,] { { 1 } });
                BinaryMatrixCollection.Add(Keys.OneAndOne, new int[,] { { 1 }, { 1 } });
                BinaryMatrixCollection.Add(Keys.OneElementMinus, new int[,] { { -1 } });

                BinaryMatrixCollection.Add("FourByFour2", new int[,] {
                                                                { 1, 1, 0, 0 },
                                                                { 1, 1, 0, 0 },
                                                                { 0, 0, 1, 0 },
                                                                { 0, 1, 1, 0 },
                                                                { 1, 0, 1, 1 }});

                BinaryMatrixCollection.Add("FiveByFive1", new int[,] {
                                                                { 1, 1, 1, 0, 0 },
                                                                { 0, 0, 1, 1, 0 },
                                                                { 0, 0, 0, 1, 0 },
                                                                { 0, 0, 0, 1, 1 },
                                                                { 0, 0, 0, 0, 1 }});

                BinaryMatrixCollection.Add("FiveByFive2", new int[,]{
                                                                { 1, 1, 0, 0, 0 },
                                                                { 1, 0, 1, 1, 1 },
                                                                { 1, 1, 1, 0, 1 },
                                                                { 1, 0, 0, 0, 1 },
                                                                { 1, 0, 0, 0, 1 }});

                BinaryMatrixCollection.Add(Keys.SevenBySeven1, new int[,] {      //   0, 1, 2, 3, 4, 5, 6  DFS    0, 1, 3, 6, 2, 4, 5
                                                                                    { 0, 1, 1, 0, 0, 0, 0},
                                                                                    { 1, 0, 0, 1, 1, 1, 0},
                                                                                    { 1, 0, 0, 0, 0, 0, 1},
                                                                                    { 0, 1, 0, 0, 0, 0, 1},
                                                                                    { 0, 1, 0, 0, 0, 0, 1},
                                                                                    { 0, 1, 0, 0, 0, 0 ,0},
                                                                                    { 0, 0, 1, 1, 1, 0, 0}
                                                                                });

                                                                            //0, 1, 2, 3, 4, 5, 6 Refer here http://wikistack.com/c-program-for-bfs-using-adjacency-matrix/
                BinaryMatrixCollection.Add(Keys.SevenBySeven2, new int[,] { { 0, 1, 1, 0, 0, 0, 0 }, // 0
                                                                            { 0, 0, 0, 0, 0, 0, 1 }, // 1
                                                                            { 0, 0, 0, 1, 0, 0, 1 }, // 2
                                                                            { 0, 0, 0, 0, 1, 0, 0 }, // 3
                                                                            { 0, 0, 0, 0, 0, 0, 1 }, // 4
                                                                            { 1, 0, 0, 1, 0, 0, 0 }, // 5
                                                                            { 0, 0, 0, 0, 0, 0, 0 }, // 6
                                                                            });

                BinaryMatrixCollection.Add(Keys.TenByTen1, new int[,] {
                                                                { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                                                                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
                                                                { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                                                                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                                                                { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
                                                                { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 },
                                                                { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                                                                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                                                                { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
                                                                { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 }});

                //====================================================================================================================

                MatrixCollection.Add(Keys.Null, null);
                MatrixCollection.Add(Keys.Empty, new int[,] { { } });
                MatrixCollection.Add(Keys.Zero, new int[,] { { 0 }, { 0 } });
                MatrixCollection.Add(Keys.OneElement, new int[,] { { 1 } });
                MatrixCollection.Add(Keys.OneAndOne, new int[,] { { 1 }, { 1 } });

                MatrixCollection.Add(Keys.TenByTen1, new int[,] {
                                                                { 00, 10, 20, 1, 1, 1, 0, 1, 1, 1 },
                                                                { 10, 00, 30, 0, 1, 1, 1, 0, 1, 1 },
                                                                { 20, 30, 00, 0, 1, 1, 0, 1, 0, 1 },
                                                                { 00, 00, 00, 0, 1, 0, 0, 0, 0, 1 },
                                                                { 01, 01, 01, 0, 1, 1, 1, 0, 1, 0 },
                                                                { 01, 00, 01, 1, 1, 1, 0, 1, 0, 0 },
                                                                { 01, 00, 00, 0, 1, 0, 0, 0, 0, 1 },
                                                                { 01, 00, 01, 1, 1, 1, 0, 1, 1, 1 },
                                                                { 01, 01, 00, 0, 0, 0, 1, 0, 0, 1 },
                                                                { 01, 01, 00, 0, 0, 0, 1, 0, 0, 1 }});

                //====================================================================================================================
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised while creating test data" + ex.Message + " " + ex.StackTrace.ToString());
            }
        }

        public static void GenerateRandomArray(IDictionary<string, int[]> collection, string key, int size, int minVal, int maxVal)
        {
            int[] array = new int[size];
            Random RandomObj = new Random();

            for (int lpCnt = 0; lpCnt < size; lpCnt++)
            {
                array[lpCnt] = RandomObj.Next(minVal, maxVal);
            }

            collection.Add(key, array);
        }

        public static void AppendArrayToStrBldrMessage(int[] array, string preMessage = "", string postMessage = "")
        {
            if (array == null || array.Length == 0)
                return;

            if (preMessage != string.Empty)
                StrBldrMessage.Append(preMessage);

            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                StrBldrMessage.Append(array[lpCnt] + " ");
            }

            if (postMessage != string.Empty)
                StrBldrMessage.Append(postMessage);
        }
        
        public static void AppendMatrixToStrBldrMessage(int[,] matrix, string preMessage = "", string postMessage = "")
        {
            if (matrix == null || matrix.Length == 0)
                return;

            if (string.IsNullOrWhiteSpace(preMessage))
                StrBldrMessage.Append(preMessage);

            for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
                {
                    StrBldrMessage.Append(matrix[lpRCnt, lpCCnt] + "\t");
                }
                StrBldrMessage.AppendLine("");
            }

            if (string.IsNullOrWhiteSpace(postMessage))
                StrBldrMessage.Append(preMessage);
        }
            
        public static void AppendMessageToStrBldrMessage(string message)
        {
            StrBldrMessage.Append(message);
        }

        public static string ConvertArrayToString(int[] array, string message = "")
        {
            if (array == null || array.Length == 0)
                return message;
               
            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                message +=  array[lpCnt] + " ";
            }
            return message;
        }

        public static bool ValidateSort(int[] array, bool ascending = true)
        {
            if (array == null)
                return false;

            int leftIndx = 0;
            if (ascending == true)
            {
                for (int lpCnt = 1; lpCnt < array.Length; lpCnt++, leftIndx++)
                {
                    if (array[leftIndx] > array[lpCnt])
                        return false;
                }
            }
            else
            {
                for (int lpCnt = 1; lpCnt < array.Length; lpCnt++, leftIndx++)
                {
                    if (array[leftIndx] < array[lpCnt])
                        return false;
                }
            }
            return true;
        }

        public static bool ValidateDuplicates(int[] array)
        {
            if (array == null)
                return false;

            int itemCnt = 0;
            for (int srcLpCnt = 0; srcLpCnt < array.Length; srcLpCnt++)
            {
                itemCnt = 0;
                for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
                {
                    if (array[srcLpCnt] == array[lpCnt])
                        itemCnt++;
                }
                if (itemCnt > 1)
                    return false;
            }
            return false;
        }

        public static string ShowSummary()
        {
            return string.Format("Total Test Cases : {0}, Passed : {1}, Failed : {2}\n\n", TestCasesCount, TestCasesPassed, TestCasesFailed);
        }

        public static void ShowResultsFromTestData(string message ="")
        {
            OutputWindow ow = new OutputWindow();

            ow.ResultBox.Text = ShowSummary();

            ow.ResultBox.Text += message;
            ow.ResultBox.Text += StrBldrMessage.ToString();
            ow.ShowDialog();
        }

        public static void ShowResults(string message , bool includeResultsSummary = true)
        {
            OutputWindow ow = new OutputWindow();

            if (includeResultsSummary == true)
                ow.ResultBox.Text = ShowSummary();

            ow.ResultBox.Text += message;
            if (TestCasesFailed > 0)
                ow.ResultBox.Foreground = Brushes.DarkRed;

            ow.ShowDialog();
        }
        
        public static int GetRandom(int maxVal)
        {
            if (maxVal < 1)
                return maxVal;
            Random rnd = new Random();
            return rnd.Next(1, maxVal);
        }

        public static void CreateDistinctRandomList(int maxSeed)
        {
            RandomList = Enumerable.Range(0, maxSeed).ToArray();
            Random rnd = new Random();

            for (int lpCnt = 0; lpCnt < RandomList.Length; ++lpCnt)
            {
                int randomIndex = rnd.Next(RandomList.Length);
                int temp = RandomList[randomIndex];
                RandomList[randomIndex] = RandomList[lpCnt];
                RandomList[lpCnt] = temp;
            }
        }

        public static int GetNextDistinctRandom()
        {
            if (RandomListPos == RandomList.Length)
                return -1;

            return RandomList[RandomListPos++];
        }

        public static void Reset()
        {
            StrBldrMessage.Clear();
            TestCaseNo = 0;
            TestCasesCount = 0;
            TestCasesPassed = 0;
            TestCasesFailed = 0;
        }
    }
}