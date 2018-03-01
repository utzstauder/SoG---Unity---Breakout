using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController {

    [SerializeField] private float speed = 1f;

    private IPlayerInput input;

	void Awake () {
        input = GetComponent<IPlayerInput>();

        if (input == null)
        {
            input = gameObject.AddComponent<PlayerInput>();
        }
	}
	
	// Update is called once per frame
	//void Update () {
    //transform.position += Vector3.right * input.Horizontal * speed
    //                    + Vector3.forward * input.Vertical * speed;
	//}

    public void Move(Vector3 direction)
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
