using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JannikInput : MonoBehaviour, IPlayerInput
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
    private float distance;
    public float minDistance = 6;
    public float maxDistance = 20;

    private Transform target;
    // Use this for initialization
    void Start()
    {

        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = 0f;
        horizontal = 0f;

        distance = Vector3.Distance(target.transform.position, transform.position);
        //Debug.LogFormat("Distance={0}", distance);

        if (distance <= minDistance)
        {
            if (transform.position.x > target.position.x)
            {
                horizontal = 0.5f;
            }
            else
            {
                horizontal = -0.5f;
            }
            if (transform.position.z > target.position.z)
            {
                vertical = 0.5f;
            }
            else
            {
                vertical = -0.5f;
            }
            Debug.LogFormat("horizontal: {0}, vertical: {1}", horizontal, vertical);
        }
        
        if (distance >= maxDistance)
        {
            if (transform.position.x < target.position.x)
            {
                horizontal = Random.Range(0.2f, 0.9f);
            }
            else
            {
                horizontal = -Random.Range(0.2f, 0.9f);
            }
            if (transform.position.z < target.position.z)
            {
                vertical = Random.Range(0.2f, 0.9f);
            }
            else
            {
                vertical = -Random.Range(0.2f, 0.9f);
            }
            Debug.LogFormat("horizontal: {0}, vertical: {1}", horizontal, vertical);
        }
        
    }
}