using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AaronInput : MonoBehaviour, IPlayerInput
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

    private float horizontal;
    private float vertical;

    private Transform target;

    int distance = 5;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (transform.position.x < target.position.x)
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 1;
        }

        if (transform.position.z < target.position.z)
        {
            vertical = -1;
        }
        else
        {
            vertical = 1;
        }

       
    }

}
