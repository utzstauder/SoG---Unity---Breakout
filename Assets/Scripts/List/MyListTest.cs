using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyListTest : MonoBehaviour {

	void Start () {
        MyList<int> list = new MyList<int>();

        // fill list
        for(int i = 0; i < 10; i++)
        {
            list.Add(i * 2);
        }

        // Print()
        list.Print();

        // GetElement
        MyNode<int> node = list.GetElement(5);
        Debug.LogFormat("Node value at position {0}: {1}", 5, node.value);

        // RemoveAt
        list.RemoveAt(4);
        Debug.LogFormat("Removed node at position {0}", 4);

        // GetIndex
        int index = list.GetIndex(node);
        Debug.LogFormat("Found node with value {0} at index {1}", node.value, index);
    }

}
