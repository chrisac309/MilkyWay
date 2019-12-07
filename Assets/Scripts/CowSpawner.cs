using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject basicCowObject;
    public float cowSpawnRate = 1.0f;
    private float timeUntilSpawn = 0.0f;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0.0f) {
            Instantiate(basicCowObject, this.gameObject.transform.position + new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, 0.0f), Quaternion.identity);
            timeUntilSpawn = Random.Range(cowSpawnRate * (2/3), cowSpawnRate * (4/3));
        }
    }
}
