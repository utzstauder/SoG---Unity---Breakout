﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("empinfo")]
public class EmpInfo : GenericXmlSerializableClass<EmpInfo> {

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
}
