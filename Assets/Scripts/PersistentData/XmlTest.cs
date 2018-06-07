using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class XmlTest : MonoBehaviour {

    const string employeeDataPath = "Data/Employees";

	void Start () {
        // string dataPath = Application.dataPath + employeeDataPath;
        string dataPath = Path.Combine(Application.dataPath, employeeDataPath);

        string[] files = Directory.GetFiles(dataPath, "*.xml");

        EmpInfo empInfo = new EmpInfo();

        foreach (string file in files)
        {
            System.DateTime modDate = File.GetLastWriteTime(file);
            Debug.Log(modDate.ToString("HH:mm"));

            Employee newEmployee = Employee.Load(file);
            empInfo.employees.Add(newEmployee);
        }

        empInfo.Save();

	}

}
