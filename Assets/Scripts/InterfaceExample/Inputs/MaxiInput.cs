using UnityEngine;

public class MaxiInput : MonoBehaviour, IPlayerInput {

        // private declared variables are displayed here

        private Transform target;
        private float horizontal;
        private float vertical;

        // poisition of player is determined

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    
        // position is targeted when 

    {
        if (transform.position.x < target.position.x)
        {
            horizontal = 1;
        }
        else
        {
            horizontal = -1;
        }

        if (transform.position.z < target.position.z)
        {
            vertical = 1;
        }
        else
        {
            vertical = -1;
        }
    }

    // returned input for horizontal and vertical axis

    public float Horizontal
    {
        get { return Input.GetAxis("Horizontal"); }
    }

    public float Vertical
    {
        get { return Input.GetAxis("Vertical"); }
    }

}
