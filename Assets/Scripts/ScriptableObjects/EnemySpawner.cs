using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public EnemyScriptableObject[] enemyTypes;

	void Update () {
		if (Input.GetMouseButtonDown(0) && enemyTypes.Length > 0)
        {
            SpawnEnemy(enemyTypes[Random.Range(0, enemyTypes.Length)]);
        }
	}

    void SpawnEnemy(EnemyScriptableObject enemyType)
    {
        Debug.Log(enemyType.name);
    }
}
