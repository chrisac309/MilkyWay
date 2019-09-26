using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject basicCowObject;
    public float cowSpawnRate = 1.0f;
    private float timeUntilSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0.0f) {
            Instantiate(basicCowObject, new Vector3(Random.Range(-5.0f, 5.0f), -3.5f, 0.0f), Quaternion.identity);
            timeUntilSpawn = cowSpawnRate;
        }
    }
}
