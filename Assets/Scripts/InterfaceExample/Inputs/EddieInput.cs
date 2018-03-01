using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EddieInput : MonoBehaviour, IPlayerInput {

    private Transform target;
    private float horizontal = 0;
    private float vertical = 0;
    private bool hit;
    private float flymin = 2f;
    private float flymax = 4f;
    private float attackDistance = 8f;
    private float speed = 1f;
    private int ran;
    
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

    void Start()
    {
        target = GameObject.Find("Player").transform;
        ran = Random.Range(1, 3);


    }

    void Update()
    {
        Debug.Log(target.transform.position);
        Debug.Log(gameObject.transform.position);
        Debug.LogFormat("Distance{0}", Vector3.Distance(target.position, transform.position));
        Mover();
        Hitter();
        Fly();

    }

    void Fly()
    {
        if (hit)
        {
            
            Vector3 flyer = new Vector3(transform.position.x,Random.Range(flymin,flymax), transform.position.z);
            transform.position = flyer;
            transform.Rotate(Vector3.up * (ran * speed*5));
            gameObject.transform.LookAt(target);

        }
        else
        {
            transform.Rotate(Vector3.up * (ran * speed));
            
            ResetFly();

        }

    }

    void ResetFly()
    {
        Vector3 flyer = new Vector3(transform.position.x, 1f, transform.position.z);
        transform.position = flyer;

    }

    void Hitter()
    {
        if (Vector3.Distance(target.position, transform.position) < attackDistance)
        {
           
            hit = true;
            print(hit);
            Fly();
        }

        if (Vector3.Distance(target.position, transform.position) > attackDistance)
        {

            hit = false;
            print(hit);
        }


    }

    void Mover()
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


  
}
