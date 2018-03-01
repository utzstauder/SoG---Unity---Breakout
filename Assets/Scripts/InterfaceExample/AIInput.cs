using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour, IPlayerInput
{
    #region Interface Properties

    public float Horizontal {
        get {
            return horizontal;
        }
    }

    public float Vertical {
        get {
            return vertical;
        }
    }

    #endregion

    private float horizontal;
    private float vertical;

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        horizontal = 0;
        vertical = 0;

        if (transform.position.x < target.position.x)
        {
            horizontal = 1;
        } else
        {
            horizontal = -1;
        }

        if (transform.position.z < target.position.z)
        {
            vertical = 1;
        } else
        {
            vertical = -1;
        }
    }
}
