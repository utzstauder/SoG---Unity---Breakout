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

    public bool Jump {
        get { return Input.GetButton("Jump"); }
    }
}
