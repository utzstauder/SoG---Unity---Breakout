using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArraySort : MonoBehaviour {

    public int n = 8;

	void Start () {
        // 1) get random array
        int[] myArray = GetRandomArray(5);

        // 2) output original array
        PrintArray(myArray);

        Swap(myArray, 0, myArray.Length - 1);
        PrintArray(myArray);

        // 3) sort array
        //BubbleSort(myArray);
        //SelectionSort(myArray);
        //myArray = Quicksort(0, myArray.Length - 1, myArray);
        //PrintArray(Quicksort(0, myArray.Length - 1, myArray));

        // 4) output sorted array
        Debug.Log("-----");
        //PrintArray(myArray);

        float tStart = Time.realtimeSinceStartup;
        Debug.LogFormat("Fibonacci({0}) = {1}", n, MyMathFunctions.Fibonacci(n));
        Debug.LogFormat("Time: {0}", Time.realtimeSinceStartup - tStart);

        tStart = Time.realtimeSinceStartup;
        Debug.LogFormat("FibonacciProcedural({0}) = {1}", n, MyMathFunctions.FibonacciProcedural(n));
        Debug.LogFormat("Time: {0}", Time.realtimeSinceStartup - tStart);
    }

    /// <summary>
    /// Swaps two elements in array <paramref name="array"/>
    /// </summary>
    /// <param name="array">The array</param>
    /// <param name="a">Index of first element</param>
    /// <param name="b">Index of second element</param>
    void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }

    /// <summary>
    /// Returns an array with length <paramref name="length"/>
    /// filled with random integer values.
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    int[] GetRandomArray(int length)
    {
        // check if in valid range
        if (length <= 0)
        {
            Debug.LogWarning("Parameter length not in valid range!");
            length = 1;
        }

        // initialize array
        int[] returnArray = new int[length];

        // fill array
        for (int i = 0; i < returnArray.Length; i++)
        {
            returnArray[i] = Random.Range(0, 100);
        }

        // return array
        return returnArray;
    }


    /// <summary>
    /// Outputs the array to the console.
    /// </summary>
    /// <param name="array">The array</param>
    void PrintArray(int[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            Debug.LogFormat("{0}: {1}", i, array[i]);
        }
    }


    /// <summary>
    /// Sorts all elements in <paramref name="array"/> in ascending order
    /// using the BubbleSort algorithm.
    /// </summary>
    /// <param name="array">The array</param>
    void BubbleSort(int[] array)
    {
        bool change = true;

        for (int i = 0; i < array.Length && change; i++)
        {
            change = false;

            for (int a = 0; a < array.Length - ( i + 1); a++)
            {                  
                if (array[a] > array[a + 1])
                {
                    Swap(array, a, a + 1);
                    change = true;
                }
            }
        }
    }


    /// <summary>
    /// Sorts the <paramref name="array"/> in ascending order
    /// using the SelectionSort algorithm.
    /// </summary>
    /// <param name="array">The array</param>
    void SelectionSort(int[] array)
    {
        int selectionIndex;
        int selectionValue;
        bool cacheFilled;

        for (int i = 0; i < array.Length-1; i++)
        {
            selectionIndex = i;
            selectionValue = 0;
            cacheFilled = false;

            for (int j = i+1; j < array.Length; j++)
            {
                if (!cacheFilled && array[i] > array[j])
                {
                    selectionIndex = j;
                    selectionValue = array[j];
                    cacheFilled = true;
                }
                else if (cacheFilled && selectionValue > array[j])
                {
                    selectionIndex = j;
                    selectionValue = array[j];
                    cacheFilled = true;
                }

                if (j >= array.Length - 1)
                {




                    if (cacheFilled && array[i] > selectionValue)
                    {
                    Swap(array, i, selectionIndex);
                    
                    }
                        
                }
                cacheFilled = false;

            }
        }
    }

    int[] Quicksort(int left, int right, int[] array)
    {
        if(left < right)
        {
            int pivot = Divide(left, right, array);
            Quicksort(left, pivot, array);
            Quicksort(pivot + 1, right, array);
        }
        return array;
    }

    int Divide(int left, int right, int[] array)
    {
        int i = left;
        int j = right -1;
        int pivot = array[right];
        do
        {
            while(array[i] < pivot && i < right -1)
            {
                i++;
            }
            while (array[j] >= pivot && j > left)
            {
                j--;
            }
            if(i > j)
            {
                Swap(array, i, j);
            }
        } while (i < j);
        if(array[i] > pivot)
        {
            Swap(array, i, right);
        }
        return i;
    }
}
