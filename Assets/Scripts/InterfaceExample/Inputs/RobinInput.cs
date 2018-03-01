using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobinInput : MonoBehaviour, IPlayerInput  {

    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }

    private float horizontal;
    private float vertical;

    private Transform targetOne;

    
    void Start()
    {
        targetOne = GameObject.Find("Player").transform;
    }

  


    void Update()
    {
        horizontal = 0;
        vertical = 0;
        
        if(transform.position.x < targetOne.position.x)
        {
            horizontal = -1;
        }
        else
        {
            horizontal =  1;
            transform.Rotate(150f, 10f, 15f);
        }

        if(transform.position.z < targetOne.position.z )
        {
            vertical = -1;
            transform.Rotate(90f, 100f, 30f);
        }
        else
        {
            vertical =  1;
            transform.Rotate(30f, 0f, 30f);
        } 
        
    }
    
}
