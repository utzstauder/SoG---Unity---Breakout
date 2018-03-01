using UnityEngine;

public class FethiInput : MonoBehaviour, IPlayerInput
{
    // Value types
    private int frames;
    private int step;
    private float horizontal;
    private float vertical;

    // Use this for initialization
    void Start()
    {
        // Set start values of frames and steps
        frames = 0;
        step = -10;
	}
	
	// Update is called once per frame
	void Update()
    {
        // Reset frames after one second.
        frames = frames > 60 ? 0 : frames + 1;

        // After one second, player step.
        if (frames == 0)
        {
            // Count the step to 10.
            step = step > 5 ? 0 : step + 1;

            // Cube run left and right.
            if (transform.position.x < -10f)
                horizontal = -step;
            else if (transform.position.x > 10f)
                horizontal = step;
            else if (transform.position.x >= -10f && transform.position.x <= 10f)
                horizontal = Random.Range(-step, step);
        }
	}

    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }
}
