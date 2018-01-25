using UnityEngine;

public class MyArrayScript : MonoBehaviour {

    int number = 10;

    int[] empty;

    int[] numbers = new int[3];

    int[] otherNumbers = new int[] { 1, 2, 3, 4, 5, 10, 20 };

	void Start () {
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

        // assign values like this
        numbers[3] = 10;

        for (int i = 0; i < 100; i++)
        {
            // get "random" index
            int randomIndex = Random.Range(0, otherNumbers.Length);
            Debug.LogFormat("random index = {0}, element value = {1}",
                            randomIndex,
                            otherNumbers[randomIndex]);
        }
	}
	
}
