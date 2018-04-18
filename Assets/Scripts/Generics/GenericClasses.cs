using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericClasses : MonoBehaviour
{
    private void Start()
    {
        GenericClass<int> instance = new GenericClass<int>();
        instance.Print(2000);

        GenericClass<string> instanceString = new GenericClass<string>();
        instanceString.Print("Hello World!");

        float t = GetComponent<float>();
    }
}

public class GenericClass<T> {

    public void Print(T data)
    {
        Debug.LogFormat("Type: {0} | Value: {1}",
            typeof(T).ToString(),
            data);
    }

    public T GetComponent<T>() where T : Component {
        T data;

        // find component
        // ...

        return null;
    }

}
