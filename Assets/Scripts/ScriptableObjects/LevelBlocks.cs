using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelBlock
{
    public string name;
    public GameObject prefab;
    public string category;
}

[CreateAssetMenu]
public class LevelBlocks : ScriptableObject {
    public LevelBlock[] levelBlocks;
}
