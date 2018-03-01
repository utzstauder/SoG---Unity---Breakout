using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenryInput : MonoBehaviour, IPlayerInput
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

    #endregion Interface Properties

    private float horizontal;
    private float vertical;

    private Transform target;

    [Range(0.0f, 50.0f)]
    public float distance = 5.0f;
    private float pointToPlayer;

    private bool follow = true;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        StopMoving();

        if(follow)
        {
            FollowTarget();
        }
    }

    /// <summary>
    /// Object stop Moving if it is in range
    /// </summary>
    void StopMoving()
    {
        Vector3 pointToPlayer = target.transform.position - transform.position;

        if (pointToPlayer.magnitude < distance)
        {
            follow = false;
        }
        else
        {
            follow = true;
        }
    }

    /// <summary>
    /// Object follow Target
    /// </summary>
    void FollowTarget()
    {
        horizontal = 0;
        vertical = 0;

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
}