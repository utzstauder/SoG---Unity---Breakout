﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpInfo : MonoBehaviour {

	void Start () {
        //Employee hans = new Employee("Hans", 50);
        //hans.Save();

        string filename = Application.dataPath + "/Data/Hans.xml";
        Employee wurst = Employee.Load(filename);

        Debug.LogFormat("Name: {0}, Age: {1}", wurst.name, wurst.age);
	}

}
