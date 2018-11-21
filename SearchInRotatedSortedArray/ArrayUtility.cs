using System;
using System.Collections.Generic;
using System.Text;

namespace SearchInRotatedSortedArray
{
    static class ArrayUtility
    {
        public static int[] GetArrayFromInput() {
            int[] array = null;
            Console.WriteLine("Enter the number of elements in the array");

            try {
                int noOfElements = int.Parse(Console.ReadLine());
                array = new int[noOfElements];
                Console.WriteLine("Enter the elements separated by space");
                String[] allElements = Console.ReadLine().Split(' ');
                for (int i = 0; i < noOfElements; i++) {
                    array[i] = int.Parse(allElements[i]);
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            return array;
        }

        public static void SearchInArray(int[] array, int elementToSearch) {
            int result = ArrayUtility.SearchInRotatedSortedArray(array, elementToSearch);
            if (result > 0)
            {
                Console.WriteLine("The entered element " + elementToSearch + " is present at index " + result);
            }
            else if (result == -999){
                //Input array is not a rotated sorted array case.
                //Do nothing
            }
            else if(result ==-1) {
                Console.WriteLine("The entered element "+elementToSearch+" is not present in the input array!");
            }
        }

        public static int SearchInRotatedSortedArray(int[] array, int element) {
            int index = 0;

            //Check if indeed the input array is a sorted and rotated array
            if (isRotatedSortedArray(array))
            {
                /* Find the pivot element which indicates the point of rotation.
                 * For Example: 2 3 1 {array of 3 elements}
                 * The pivot would be 3 because after this the rotation begins.
                 * In other words, the pivot signals the greatest number in
                 * the array. Meaning, pivot is the last element in the array
                 * if the array was not rotated.
                 */ 
                int pivot = FindPivotInArray(array);

                /* Once pivot is found, it is known that all elements toward the 
                 * left of pivot is a sorted array and that half after the pivot
                 * is a sorted array. In other words, the pivot splits the array
                 * into two sorted arrays.
                 * 
                 * Therefore, if the element to search is less than pivot and
                 * is less than the first element in the array, then it should
                 * lie in the second sorted half.
                 * 
                 * However, if the element to search is less than pivot but 
                 * greater than the first element, then it should lie
                 * somewhere in the first sorted half until pivot
                 */
                if (element < array[pivot] && element < array[0])
                {
                    index = _BinarySearch(array, pivot + 1, array.Length, element);
                }
                else {
                    index = _BinarySearch(array, 0, pivot-1, element);
                }
            }
            else {
                Console.WriteLine("The input array is not a rotated sorted array!");
                return -999;
            }
            return index;
        }

        private static bool isRotatedSortedArray(int[] array) {

            /*If the array is fully rotated, then the number
             * of times, a previous element is greater than 
             * the current element, equal the length of the array.
             * Else, only once the scenario is encountered, where
             * an element is less than the previous element.
             */
            int previousGreaterCount = 0;
            int sortedCount = 1;
            for (int i = 0; i < array.Length; i++) {
                if (i != 0 && array[i - 1] > array[i])
                {
                    previousGreaterCount++;
                }
                else {
                    if (i != 0 && array[i - 1] < array[i]) {
                        sortedCount++;
                    }                  
                }
            }

            if ((previousGreaterCount == array.Length && sortedCount == 0)
                || (previousGreaterCount == 1 && sortedCount == array.Length - 1)) {
                return true;
            }

            return false;
        }

        private static int FindPivotInArray(int[] array) {
            return _FindPivotUtil(array, 0, array.Length);
        }

        private static int _FindPivotUtil(int[] array, int start, int end) {
            while (start <= end) {

                int middle = (start + end) / 2;

                if (middle < array.Length)
                {
                    if (array[middle - 1] > array[middle])
                    {
                        return middle - 1;
                    }
                    if (middle + 1 < array.Length && array[middle] > array[middle + 1])
                    {
                        return middle;
                    }

                    /* If start element is less than middle element,
                     * then the greatest element in the array
                     * cannot lie between start and middle
                     */
                    if (array[start] < array[middle])
                    {
                        return _FindPivotUtil(array, middle + 1, end);
                    }
                    else
                    {
                        return _FindPivotUtil(array, start, middle - 1);
                    }
                }
                else {
                    return -1;
                }

            }
            return -1;
        }

        private static int _BinarySearch(int[] array, int start, int end, int element) {
            while (start <= end) {
                int middle = (start + end) / 2;

                if (middle < array.Length)
                {
                    if (array[middle] == element)
                    {
                        return middle;
                    }
                    if (array[middle] < element)
                    {
                        return _BinarySearch(array, middle + 1, end, element);
                    }
                    else
                    {
                        return _BinarySearch(array, start, middle-1, element);
                    }
                }
                else {
                    return -1;
                }
            }
            return -1;
        }
    }
}
