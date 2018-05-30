using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Employee")]
public class Employee : GenericXmlSerializableClass<Employee> {
    [XmlElement("name")] public string name;

    [XmlElement("age")]  public int age;

    public Employee() {
        name = "John Doe";
        age = 18;
    }

    public Employee(string name, int age)
    {
        this.name = name;
        this.age = age;
    }


    #region XML

    public void Save()
    {
        string filename = Application.dataPath + "/Data/" + name + ".xml";
        Save(filename);
    }

    #endregion
}
