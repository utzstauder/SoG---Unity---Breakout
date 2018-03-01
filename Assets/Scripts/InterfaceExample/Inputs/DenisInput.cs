using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenisInput : MonoBehaviour, IPlayerInput
{
    #region Interface Properties

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

    #endregion

    private float horizontal;
    private float vertical;


    private float x;
    private float y;
    private float z;

    private float range = 0;


    void Start()
    {
    }

    void Update()
    {

        if (range == 0)
    {
        z = 0.1f + z;

        x = Random.Range(-0.01f, 0.01f) * z;
        y = Random.Range(-0.01f, 0.01f) * z;

        horizontal = x;
        vertical = y;

    }
     
    if (transform.position.x < 0 && range == 1)
    {
        range = 0;
    }

    if (transform.position.x > 0 && range == 2)
    {
        range = 0;
    }

    if (transform.position.z< 0 && range == 3)
    {
        range = 0;
    }

    if (transform.position.z > 0 && range == 4)
    {
        range = 0;
    }
    

    if (transform.position.x > 8)
    {
        range = 1;
        z = 0;

        horizontal = -0.2f;
    }


    if (transform.position.x< -8)
    {
        range = 2;
        z = 0;

        horizontal = 0.2f;
    }


    if (transform.position.z > 8)
    {
        range = 3;
        z = 0;

        vertical = -0.2f;
    }

    if (transform.position.z < -8)
    {
        range = 4;
        z = 0;

        vertical = 0.2f;
    }


    }
}