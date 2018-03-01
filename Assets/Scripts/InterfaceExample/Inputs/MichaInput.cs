using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaInput : MonoBehaviour, IPlayerInput {
    float sin;
    int radius;
    int steps=1;
    
    public float Horizontal
    {
        get
        {
            if (Input.GetButton("Horizontal"))
            {
                return Input.GetAxis("Horizontal");
            }
            else if (Input.GetButton("Vertical"))
            {
                return Input.GetAxis("Vertical") * sin;
            }
            else return 0;


        }

    }
    public float Vertical
    { 
        get {
            if  (Input.GetButton("Vertical"))
            {
                 return Input.GetAxis("Vertical");
            }
            else if (Input.GetButton("Horizontal"))
            {
                return Input.GetAxis("Horizontal") * sin;
            }
            else return 0;


        }
    }
    private void Update()
    { if( radius >= 5 || radius <= -5)
        {
            steps *= -1;
        }
        radius += steps;
        sin = Mathf.Sin(radius);
        Debug.Log(sin);
    }
  
	
      
}
       
