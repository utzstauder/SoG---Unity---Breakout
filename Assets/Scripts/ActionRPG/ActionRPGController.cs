using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRPGController : MonoBehaviour {

    [SerializeField] LayerMask movementLayers;

    Vector3 targetPosition;
    Coroutine moveCoroutine;
    [SerializeField, Range(0.01f, 1f)] float maxDistanceToTarget = 0.1f;
    [SerializeField, Range(1f, 10f)]  float movementSpeed        = 5f;


    [Header("UI"), SerializeField] WorldspaceLabelUI labelPrefab;


    private void Start()
    {
        int layer1 = LayerMask.NameToLayer("BlockMovement");
        int layer2 = LayerMask.NameToLayer("Water");

        int layermask1 = 1 << layer1;
        int layermask2 = 1 << layer2;

        int finalmask = layermask1 | layermask2;   // binary OR operator

        Debug.Log(finalmask);

        // movementLayers = finalmask;

        // StartCoroutine(MoveRandomly(1f));
    }

    //int Add(int a, int b)
    //{
    //    return a + b;
    //}

    //void Add(int a, int b, out int result)
    //{
    //    result = a + b;
    //}

    void Update () {

		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, float.MaxValue, movementLayers))
            {
                Debug.LogFormat("Ray hit {0} at {1}",
                    hitInfo.transform.gameObject.name,
                    hitInfo.point);

                // transform.position = hitInfo.point; BAD!

                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }

                moveCoroutine = StartCoroutine(MoveToTarget(hitInfo.point));

                if (labelPrefab != null)
                {
                    WorldspaceLabelUI label = Instantiate(labelPrefab);
                    label.Init(hitInfo.point + Vector3.up * 2, hitInfo.transform.gameObject.name);
                }
            }
        }

        //if (Vector3.Distance(transform.position, targetPosition) > maxDistanceToTarget)
        //{
        //    Vector3 direction = targetPosition - transform.position;
        //    direction.y = 0;
        //    direction.Normalize();

        //    transform.position += direction * movementSpeed * Time.deltaTime;
        //}
	}


    IEnumerator MoveRandomly(float delay)
    {
        int count = 0;
        while (true)
        {
            Debug.Log(count++);
            Debug.Log(moveCoroutine);

            Vector3 randomPosition = Random.onUnitSphere * 10;
            randomPosition.y = 0;

            yield return StartCoroutine(MoveToTarget(randomPosition));
        }
    }

    IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > maxDistanceToTarget)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;
            direction.Normalize();

            transform.position += direction * movementSpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        moveCoroutine = null;
    }
}
