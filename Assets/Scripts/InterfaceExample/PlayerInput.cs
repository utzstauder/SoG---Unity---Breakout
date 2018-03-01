using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput {

	public float Horizontal {
        get { return Input.GetAxis("Horizontal"); }
    }

    public float Vertical {
        get { return Input.GetAxis("Vertical");  }
    }


    private IPlayerController controller;

    void Awake()
    {
        controller = GetComponent<IPlayerController>();
        if (controller == null)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        controller.Move(Vector3.right * Horizontal + Vector3.forward * Vertical);
    }

}
