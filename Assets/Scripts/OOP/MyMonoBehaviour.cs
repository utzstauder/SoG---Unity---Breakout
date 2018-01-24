using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour {

    // This function is called when the object becomes enabled and active.
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // This function is called when the behaviour becomes disabled () or inactive.
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // disable this Component / MonoBehaviour
            this.enabled = !this.enabled;
        }
	}

    // This function is called when the MonoBehaviour will be destroyed.
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
