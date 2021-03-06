﻿using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject[] powerupPrefabs;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hit();
    }

    protected virtual void Hit()
    {
        Die();
    }

    protected virtual void Die()
    {
        // 1) brick position
        // transform.position
        // 2) power up prefab reference
        // Debug.Log(powerupPrefab);

        // spawn power up
        if (powerupPrefabs != null)
        {
            if (powerupPrefabs.Length > 0)
            {
                // get random index
                int randomIndex = Random.Range(0, powerupPrefabs.Length);

                // get random powerup prefab
                GameObject powerupPrefab = powerupPrefabs[randomIndex];

                if (powerupPrefab != null)
                {
                    // instantiate new gameobject
                    GameObject powerup = Instantiate(powerupPrefab, transform.position, Quaternion.identity);
                    // GameObject powerup = Instantiate(gameObject, Random.insideUnitSphere * Random.Range(0, 4f), Quaternion.identity);

                    // find DynamicObjects
                    GameObject dynamicObjects = GameObject.Find("DynamicObjects");

                    // no DynamicObjects? create it!
                    if (dynamicObjects == null)
                    {
                        dynamicObjects = new GameObject("DynamicObjects");
                    }

                    // parent instantiated object to DynamicObjects gameobject
                    powerup.transform.parent = dynamicObjects.transform;
                }
            }
        }

        Destroy(gameObject);
    }
}
