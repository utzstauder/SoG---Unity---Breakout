using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRPGController : MonoBehaviour {

    private void Start()
    {
        int a = 10;
        int b = 20;
        Debug.LogFormat("a = {0}, b = {1}", a, b);

        int c;
        Add(a, b, out c);
        Debug.LogFormat("c = {0}", c);
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    void Add(int a, int b, out int result)
    {
        result = a + b;
    }




    void Update () {

		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, float.MaxValue))
            {
                Debug.LogFormat("Ray hit {0} at {1}",
                    hitInfo.transform.gameObject.name,
                    hitInfo.point);
            }
        }
	}
}
