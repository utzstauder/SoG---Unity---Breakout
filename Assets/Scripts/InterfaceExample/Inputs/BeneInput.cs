using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeneInput : MonoBehaviour, IPlayerInput
{

    Vector3 target;
    GameObject player;
    private Vector3 toPlayer;
    float attackTimer = 0;
    float strollcount = 0;

    enum State
    {
        attacking,
        strolling,
        chasing
    }
    State enemyState = State.strolling;

    [SerializeField] float stopDistance = 1.5f;
    [SerializeField] float attackDistance = 2f;
    [SerializeField] float attackCoolDown = 1.5f;
    [SerializeField] [Range(1, 100)] float lookDistance = 10f;

    public float Horizontal
    {
        get
        {
            if (target == null) return 0f;
            if (toPlayer.magnitude < lookDistance && toPlayer.magnitude > stopDistance)
            {
                enemyState = State.chasing;
                return toPlayer.normalized.x;
            }
            else if (toPlayer.magnitude > lookDistance)
            {
                enemyState = State.strolling;
                return target.normalized.x;
            }
            return 0;
        }
    }

    public float Vertical
    {
        get
        {
            if (target == null) return 0f;
            if (toPlayer.magnitude < lookDistance && toPlayer.magnitude > stopDistance)
            {
                enemyState = State.chasing;
                return toPlayer.normalized.z;
            }
            else if (toPlayer.magnitude > lookDistance)
            {
                enemyState = State.strolling;
                return target.normalized.z;
            }
            return 0;
        }
    }

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        StrollAround();
        toPlayer = player.transform.position - transform.position;
        Attack();
    }

    private void StrollAround()
    {
        if (strollcount <= 0)
        {
            target = Random.insideUnitSphere * 5;
            target.y = 0f;
            strollcount = Random.Range(1f, 5f);
        }
        else if (strollcount > 0)
        {
            strollcount -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (toPlayer.magnitude < attackDistance && attackTimer <= 0)
        {
            enemyState = State.attacking;
            Debug.Log("I am attacking you!");
            Debug.Log("I wish I could apply Knockback...");
            attackTimer = attackCoolDown;
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }
}

