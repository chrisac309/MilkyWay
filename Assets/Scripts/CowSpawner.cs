using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject basicCowObject;
    public Vector3 cowSpawnerPos;
    public float cowSpawnRate = 1.0f;
    private float timeUntilSpawn = 0.0f;

    void Start() {
        cowSpawnerPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0.0f) {
            Instantiate(basicCowObject, cowSpawnerPos + new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, 0.0f), Quaternion.identity);
            timeUntilSpawn = cowSpawnRate;
        }
    }
}
