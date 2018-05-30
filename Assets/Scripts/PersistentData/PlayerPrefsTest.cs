using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour {

    int PersistentNumber {
        get {
            return PlayerPrefs.GetInt("MyPersistentNumber");
        }
        set {
            PlayerPrefs.SetInt("MyPersistentNumber", value);
        }
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            PersistentNumber++;
        }
	}

    private void OnGUI()
    {
        GUILayout.Label("Persistent number: " + PersistentNumber);
    }
}
