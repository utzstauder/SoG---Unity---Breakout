using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed = 1f;

    private IPlayerInput input;

	void Awake () {
        input = GetComponent<IPlayerInput>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * input.Horizontal * speed
                            + Vector3.forward * input.Vertical * speed;
	}
}
