using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LevelPrefab;
    private GameObject[] prefabArray;
    private Transform cameraTransform;
    private int nextPrefabPosition = 0;
    private int prefabArrayLength = 5;
    public float referencePosition;
    private float shiftDistance;
    private float cameraWidth;


    // Start is called before the first frame update
    void Start()
    {
        // Using the levelcameraWidth and the referencePosition, we can determine when to 
        // move one of the three (or five) level prefab objects in front of the player
        cameraTransform = Camera.main.transform; 
        referencePosition = cameraTransform.position.x;
        cameraWidth = Camera.main.orthographicSize;
        shiftDistance =  cameraWidth * 5;
        initializePrefabArray();
    }

    // Update is called once per frame
    void Update()
    {
        var currentCameraPos = cameraTransform.position.x;
        if(referencePosition + cameraWidth < currentCameraPos) {
            shiftNextPrefab();
            referencePosition = currentCameraPos;
            nextPrefabPosition++;
            if (nextPrefabPosition >= prefabArrayLength) {
                nextPrefabPosition = 0;
            }
        }
    }

    private void initializePrefabArray() {
        prefabArray = new GameObject[prefabArrayLength];
        prefabArray[0] = Instantiate(LevelPrefab, new Vector3(0, 0), Quaternion.identity);
        prefabArray[1] = Instantiate(LevelPrefab, new Vector3(cameraWidth, 0), Quaternion.identity);
        prefabArray[2] = Instantiate(LevelPrefab, new Vector3(cameraWidth * 2, 0), Quaternion.identity);
        prefabArray[3] = Instantiate(LevelPrefab, new Vector3(cameraWidth * 3, 0), Quaternion.identity);
        prefabArray[4] = Instantiate(LevelPrefab, new Vector3(cameraWidth * 4, 0), Quaternion.identity);
    }

    private void shiftNextPrefab() {
        var pos = prefabArray[nextPrefabPosition].transform.position;
        var shift = pos.x + 5 * cameraWidth;
        prefabArray[nextPrefabPosition].transform.position = new Vector3(shift, pos.y);
    }
}
