﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArraySort : MonoBehaviour {

	void Start () {
        // 1) get random array
        int[] myArray = GetRandomArray(5);

        // 2) output original array
        PrintArray(myArray);

        Swap(myArray, 0, myArray.Length - 1);
        PrintArray(myArray);

        // 3) sort array

        // 4) output sorted array
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
}
