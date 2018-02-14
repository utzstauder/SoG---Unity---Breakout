using UnityEngine;
using System.Linq;

public class MyArrayScript : MonoBehaviour {

    public int randomArrayLength = 100;

    int number = 10;

    int[] empty;

    int[] numbers = new int[3];

    int[] otherNumbers = new int[] { 1, 2000, 3, 4, 5, 10, 20 };

	void Start () {
        MyPrint("Hello", "World", "What's up?");
        MyPrint("Yo!");

        Debug.LogFormat("number = {0}", number);

        Debug.LogFormat("empty = {0}", empty);
        Debug.LogFormat("length of numbers = {0}", numbers.Length);
        Debug.LogFormat("length of other numbers = {0}", otherNumbers.Length);

        // iterate through array
        for (int i = 0; i < otherNumbers.Length; i++)
        {
            // access element by index
            Debug.Log(otherNumbers[i]);
        }


        int[] randomNumbers = new int[randomArrayLength];

        for (int i = 0; i < randomArrayLength; i++)
        {
            // get "random" index
            int randomIndex = Random.Range(0, otherNumbers.Length);
            //Debug.LogFormat("random index = {0}, element value = {1}",
            //                randomIndex,
            //                otherNumbers[randomIndex]);
            randomNumbers[i] = otherNumbers[randomIndex];
        }

        // calculate average
        float randomAverage = Average(randomNumbers);
        randomAverage = (float)randomNumbers.Average();
        float actualAverage = Average(otherNumbers);

        float someAverage = Average(2, 50, 200, -10);

        Debug.LogFormat("random average = {0} | actual average = {1}", randomAverage, actualAverage);
	}
	

    int Sum(params int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    float Average(params int[] array)
    {
        float average = 0;

        int sum = Sum(array);
        average = (float)sum / array.Length;

        return average;
    }


    void MyPrint(params string[] text)
    {
        for(int i = 0; i < text.Length; i++)
        {
            Debug.Log(text[i]);
        }
    }
}
