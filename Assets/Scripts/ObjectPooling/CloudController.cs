using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    public GameObject dropPrefab;

    public float dropRange = 10f;

    [Range(1, 1000)]
    public int dropsPerFrame = 1;


    // object pool
    Stack<GameObject> inactiveObjects;

    public int initialPoolAmount = 10000;

    private void Awake()
    {
        inactiveObjects = new Stack<GameObject>();

        PoolObjects();

        Debug.LogFormat("inactiveObjects count: {0}", inactiveObjects.Count);
    }

    // Update is called once per frame
    void Update () {
        if (dropPrefab != null)
        {
            for (int i = 0; i < dropsPerFrame; i++)
            {
                GameObject newDrop = GetObjectFromPool();

                newDrop.transform.position = new Vector3(
                    Random.Range(-dropRange, dropRange),
                    transform.position.y,
                    Random.Range(-dropRange, dropRange));

                newDrop.SetActive(true);
            }
        }
    }


    void PoolObjects()
    {
        for (int i = 0; i < initialPoolAmount; i++)
        {
            CreateObject();
        }
    }

    GameObject CreateObject()
    {
        GameObject newObject = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        newObject.transform.parent = transform;

        newObject.SetActive(false);
        inactiveObjects.Push(newObject);

        return newObject;
    }

    GameObject GetObjectFromPool()
    {
        if (inactiveObjects.Count > 0)
        {
            GameObject objectFromPool = inactiveObjects.Pop();
            
            return objectFromPool;
        } else
        {
            return CreateObject();
        }
    }

    public void ReturnToPool(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
        inactiveObjects.Push(pooledObject);
    }
}
