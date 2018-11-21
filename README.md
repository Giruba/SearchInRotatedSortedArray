Author: Giruba Beulah SE

# SearchInRotatedSortedArray
C# program for finding an element in a rotated sorted array


Logic: 
------

1. Find the Pivot element in the array
   Pivot: The greatest element in the array
          [The last element in the array if the array was not rotated]
          
          In a rotated array, the pivot element divides the array into two sorted halves.
          One sorted half lies to the left of the pivot element
          The other sorted half lies to the right of the pivot element
          
          Once pivot element is identified, the problem reduces to standard Binary Search,
          as we have to identify in which sorted half, the element to search lies.
          
          
          Any element to search in the specified array will be less than the pivot,
          as already mentioned, the pivot is the largest element in the array.
          
          Thus, if the element to search is less than start element, then the element to search cannot lie
          in firs sorted half.
          If the element to search is greater than start element in the array, then it will lie between the
          start element and the pivot.
                    
   
2. Depending upon whether the entered element to search is less than or greater than pivot, navigate
  2.a If the entered element is less than pivot but greater than the first element in the array,
      navigate left 'betweeen the first element and the pivot'
      
      For an element to lie in the first sorted half, it should be equal or greater than the first
      element in the array and less than pivot
      
  2.b If the entered element is less than pivot but less than the first element in the array,
      navigate right 'between privot and end of the array'
      
      For an element to lie in the second sorted half, it should be less than the start element in the array
      and obviously less than the pivot.
      
      [Pivot -> Largest element in tehe array]
       
