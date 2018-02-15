using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    CloudController cloudController;

    private void Awake()
    {
        cloudController = FindObjectOfType<CloudController>();
        Debug.Log(cloudController);
    }

    private void OnTriggerEnter(Collider other)
    {
        cloudController.ReturnToPool(gameObject);
    }


}
