using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Employee")]
public class Employee {
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

    public void Save(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));

        using (StreamWriter stream = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static Employee Load(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));

        using (StreamReader stream = new StreamReader(filename, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            Employee data = serializer.Deserialize(stream) as Employee;
            return data;
        }
    }

    #endregion
}
