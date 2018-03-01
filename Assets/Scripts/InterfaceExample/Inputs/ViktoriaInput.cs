using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViktoriaInput : MonoBehaviour, IPlayerInput {

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


    private float horizontal;
    private float vertical;
    

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (transform.position.x < target.position.x + 5)
        {
            horizontal = 2;
        }
        else
        {
            horizontal = -2;
        }

        if (transform.position.z < target.position.z + 5)
        {
            vertical = 2;
        }
        else
        {
            vertical = -2;
        }
        
        
        
    }


}
