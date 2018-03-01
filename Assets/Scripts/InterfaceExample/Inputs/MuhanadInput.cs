using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuhanadInput : MonoBehaviour, IPlayerInput
{
    public float Horizontal
    {
        get
        {
            return horizontal;
        }
    }

    public float Vertical
    {
        get
        {
            return vertical;
        }
    }
    private float vertical;
    private float horizontal;
    private Transform target;
    
   
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
      
        if (transform.position.x < target.position.x)
        {
            horizontal = (transform.position.x - target.position.x) * 0.100f * Time.deltaTime;
        }
        else
        {
            horizontal = (transform.position.x - target.position.x) * 0.100f * Time.deltaTime;
        }

        if (transform.position.z < target.position.z)
        {
            vertical = (transform.position.x - target.position.x) * 0.100f * Time.deltaTime;
        }
        else
        {
            vertical = (transform.position.x - target.position.x) * 0.100f * Time.deltaTime;
        }


    }
}
