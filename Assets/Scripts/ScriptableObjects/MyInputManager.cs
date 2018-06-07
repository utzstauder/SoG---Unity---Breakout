using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Axis
{
    public string name;
    public string descriptiveName;

}

[CreateAssetMenu]
public class MyInputManager : ScriptableObject {

    public Axis[] axes;
	
}
