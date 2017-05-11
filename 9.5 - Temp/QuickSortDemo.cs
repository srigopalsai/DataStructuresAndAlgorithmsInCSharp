namespace DataStructuresAndAlgorithms
{
    public class QuickSortDemo1
    {
        static void SwapElement(int leftElement, int rightElement)
        {
            int tempElement = leftElement;
            leftElement = rightElement;
            rightElement = tempElement;
        }

        //public static void QuickSort(int[] elementsArray, int startPosition, int endPosition)
        //{
        //    if (endPosition > startPosition + 1)
        //    {
        //        int tempElement = 0;
        //        int pivotElementValue = elementsArray[startPosition];

        //        int leftSubSetIndex = startPosition + 1;
        //        int rightSubsetIndex = endPosition;

        //        while (leftSubSetIndex < rightSubsetIndex)
        //        {
        //            if (elementsArray[leftSubSetIndex] <= pivotElementValue)
        //            {
        //                leftSubSetIndex++;
        //            }
        //            else
        //            {
        //                SwapElement(elementsArray[leftSubSetIndex], elementsArray[--rightSubsetIndex]);
        //                //--rightSubsetIndex;
        //                //tempElement = elementsArray[leftSubSetIndex];
        //                //elementsArray[leftSubSetIndex] = elementsArray[rightSubsetIndex];
        //                //elementsArray[rightSubsetIndex] = tempElement;
        //            }
        //        }

        //        SwapElement(elementsArray[--leftSubSetIndex], elementsArray[startPosition]);
        //        //--leftSubSetIndex;
        //        //tempElement = elementsArray[leftSubSetIndex];
        //        //elementsArray[leftSubSetIndex] = elementsArray[rightSubsetIndex];
        //        //elementsArray[rightSubsetIndex] = tempElement;

        //        QuickSort(elementsArray, startPosition, leftSubSetIndex);
        //        QuickSort(elementsArray, rightSubsetIndex, endPosition);
        //    }
        //}
    }
}
