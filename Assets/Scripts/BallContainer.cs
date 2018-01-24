using UnityEngine;

public class BallContainer : MonoBehaviour {

    public GameObject ballPrefab;

	void Update () {
		if (transform.childCount < 1)
        {
            SpawnBall(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            MultiplyBalls(2);
        }
	}

    GameObject SpawnBall(Vector3 position)
    {
        if (ballPrefab == null)
        {
            Debug.LogError("No prefab reference set.");
            return null;
        }

        // instantiate ball
        GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);

        // parent to this transform
        ball.transform.parent = transform;

        // return reference to new GameObject ball
        return ball;
    }

    /// <summary>
    /// Creates additional balls as child objects of this transform.
    /// </summary>
    /// <param name="factor">The multiplying factor. factor = 2 creates 1 additional ball for each ball.</param>
    public void MultiplyBalls(int factor)
    {
        // childcount buffer
        // transform.childCount scales dynamically with each new child transform
        int childCountBuffer = transform.childCount;

        // iterate through all child objects
        for (int i = 0; i < childCountBuffer; i++)
        {
            Transform child = transform.GetChild(i);

            // instantiate (factor - 1) balls for each child object
            for (int b = 0; b < (factor - 1); b++)
            {
                // instantiate ball and keep reference
                GameObject ball = SpawnBall(child.position);

                // do we have a reference?
                if (ball != null)
                {
                    // get script reference
                    Ball ballScript = ball.GetComponent<Ball>();

                    // get random direction in upwards facing semi circle
                    Vector2 direction = Random.insideUnitCircle;

                    // make sure it points upwards
                    if (direction.y < 0)
                    {
                        direction.y *= -1;
                    }

                    // set initial direction for each new ball
                    ballScript.SetDirection(direction);
                }
                
            }

        }

    }


    /// <summary>
    /// Changes the speed of every child object (ball)
    /// </summary>
    /// <param name="speedChange">The delta speed</param>
    public void ChangeBallSpeed(float speedChange)
    {
        // iterate through all child objects (= balls)
        for(int i = 0; i < transform.childCount; i++)
        {
            // get script reference
            Ball ballScript = transform.GetChild(i).gameObject.GetComponent<Ball>();

            if (ballScript != null)
            {
                // change speed for every ball
                ballScript.ChangeSpeed(speedChange);
            }
        }
    }
}
