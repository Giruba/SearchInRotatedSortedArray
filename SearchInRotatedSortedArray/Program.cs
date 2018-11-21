using System;

namespace SearchInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Searching in a rotated sorted array!");
            Console.WriteLine("------------------------------------");

            int[] array = ArrayUtility.GetArrayFromInput();
            try
            {
                Console.WriteLine("Enter the element that ought to be searched in the rotated sorted array");
                int elementToSearch = int.Parse(Console.ReadLine());
                ArrayUtility.SearchInArray(array, elementToSearch);
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            Console.ReadLine();
        }
    }
}
