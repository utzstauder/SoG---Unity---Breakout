using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyScriptableObject : ScriptableObject {

    public enum AttackType
    {
        Melee,
        Ranged,
        Area
    }

    public string name;
    public int attackPower;
    public AttackType attackType;

}
