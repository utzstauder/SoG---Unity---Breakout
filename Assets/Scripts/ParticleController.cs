using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

#region Private Fields

    [SerializeField] int amount = 50;

    ParticleSystem ps;

    #endregion


#region Unity Messages

    // Use this for initialization
    void Awake () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            ps.Emit(amount);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (ps.isEmitting)
            {
                ps.Stop();
            } else
            {
                ps.Play();
            }
        }
	}

#endregion

}
