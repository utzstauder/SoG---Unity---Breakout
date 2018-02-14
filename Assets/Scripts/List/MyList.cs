using UnityEngine;

/// <summary>
/// Custom class that implements basic list functionalities
/// </summary>
public class MyList {

    public MyNode first;

    public MyList()
    {
        first = null;
    }

    /// <summary>
    /// Adds an element at the end of the list.
    /// </summary>
    /// <param name="value">The element value</param>
    public void Add(int value)
    {
        // create new node with value
        MyNode newNode = new MyNode(value);

        if (first == null)
        {
            // list is empty
            first = newNode;
        } else
        {
            // list is not empty
            MyNode last = first;
            while(last.next != null)
            {
                // find last element
                last = last.next;
            }

            // add element at end of list
            last.next = newNode;
        }
    }

    /// <summary>
    /// Returns the node at position <paramref name="index"/>
    /// </summary>
    /// <param name="index">The position of the node</param>
    /// <returns>The node</returns>
    public MyNode GetElement(int index)
    {
        if (first == null)
        {
            Debug.Log("List empty");
            return null;
        }

        MyNode returnElement = first;
        int iterator = 0;

        while (returnElement != null && iterator < index)
        {
            returnElement = returnElement.next;
            iterator++;
        }

        if (iterator == index)
        {
            return returnElement;
        }

        return null;
    }

    /// <summary>
    /// Removes node at <paramref name="index"/>
    /// </summary>
    /// <param name="index">The position of the node</param>
    public void RemoveAt(int index)
    {
        if (first == null)
        {
            Debug.Log("List empty");
            return;
        }

        MyNode targetNode = first;
        MyNode prevNode = first;
        int iterator = 0;

        while (targetNode != null && iterator < index)
        {
            prevNode = targetNode;
            targetNode = targetNode.next;
            iterator++;
        }

        if (iterator == index && targetNode != null)
        {
            prevNode.next = targetNode.next;
        }
    }

    /// <summary>
    /// Returns the index of <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The node to look for</param>
    /// <returns>The index</returns>
    public int GetIndex(MyNode node)
    {
        int index = 0;
        MyNode iteratorNode = first;

        while (iteratorNode != null)
        {
            if (iteratorNode == node)
            {
                return index;
            }

            index++;
            iteratorNode = iteratorNode.next;
        }

        return -1;
    }

    /// <summary>
    /// Returns the length of the list.
    /// </summary>
    /// <returns>The length</returns>
    public int GetLength()
    {
        int length = 0;
        MyNode iterator = first;

        while(iterator != null)
        {
            length++;
            iterator = iterator.next;
        }

        return length;
    }

    /// <summary>
    /// Logs the entire list to the console.
    /// </summary>
    public void Print()
    {
        MyNode printNode = first;
        while (printNode != null)
        {
            Debug.Log(printNode.value);
            printNode = printNode.next;
        }
    }
}

public class MyNode
{
    public MyNode next;
    public int value;

    public MyNode()
    {
        next  = null;
        value = 0;
    }

    public MyNode(int value)
    {
        next = null;
        this.value = value;
    }
}