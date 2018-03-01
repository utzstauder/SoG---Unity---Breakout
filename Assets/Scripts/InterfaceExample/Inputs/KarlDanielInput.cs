using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarlDanielInput : MonoBehaviour, IPlayerInput{

    #region Interface Properties
    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }
    #endregion

    private float horizontal;
    private float vertical;

    private Transform target;


    void Start ()
    {
        target = GameObject.Find("Player").transform;
    }
	
	void Update ()
    {
        if (transform.position.x < target.position.x)
        {
            horizontal = (target.position.x - transform.position.x) * 0.1f;
        }
        else
        {
            horizontal = (target.position.x - transform.position.x) * 0.1f;
        }

        if (transform.position.z < target.position.z)
        {
            vertical = (target.position.z - transform.position.z) * 0.1f;
        }
        else
        {
            vertical = (target.position.z - transform.position.z) * 0.1f;
        }
    }
}
