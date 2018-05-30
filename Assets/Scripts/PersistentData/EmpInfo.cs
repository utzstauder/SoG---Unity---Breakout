using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("empinfo")]
public class EmpInfo {

    [XmlArray("employees"), XmlArrayItem("employee")]
    public List<Employee> employees;

    public EmpInfo()
    {
        employees = new List<Employee>();
    }


    public void Save()
    {
        string filename = Application.dataPath + "/Data/empinfo.xml";
        Save(filename);
    }

    public void Save(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(EmpInfo));

        using (StreamWriter stream = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static EmpInfo Load(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(EmpInfo));

        using (StreamReader stream = new StreamReader(filename, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            EmpInfo data = serializer.Deserialize(stream) as EmpInfo;
            return data;
        }
    }
}
