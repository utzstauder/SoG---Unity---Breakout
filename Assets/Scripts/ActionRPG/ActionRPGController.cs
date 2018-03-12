using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRPGController : MonoBehaviour {

    [SerializeField] LayerMask movementLayers;

    private void Start()
    {
        int layer1 = LayerMask.NameToLayer("BlockMovement");
        int layer2 = LayerMask.NameToLayer("Water");

        int layermask1 = 1 << layer1;
        int layermask2 = 1 << layer2;

        int finalmask = layermask1 | layermask2;   // binary OR operator

        Debug.Log(finalmask);

        // movementLayers = finalmask;
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
            }
        }
	}
}
