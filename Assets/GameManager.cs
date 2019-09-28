using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LevelPrefab;

    private Vector3 referencePosition;
    private float levelPrefabWidth;


    // Start is called before the first frame update
    void Start()
    {
        // Using the levelPrefabWidth and the referencePosition, we can determine when to 
        // move one of the three (or five) level prefab objects in front of the player
        referencePosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
