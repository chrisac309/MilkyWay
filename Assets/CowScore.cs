using UnityEngine;
using UnityEngine.UI;

public class CowScore : MonoBehaviour
{     
    Text ourComponent;           // Our refference to text component
    public static int playerScore;

    private static int previousPlayerScore;  
    void Start() {
         // Get component Text from that gameObject
         ourComponent = gameObject.GetComponent<Text>();
         previousPlayerScore = 0;
         playerScore = 0;
    }

     void LateUpdate () {         
         if (previousPlayerScore != playerScore) {
            // Assign new string to "Text" field in that component
            ourComponent.text = "Cows: " + playerScore;
            previousPlayerScore = playerScore;
         }
     }
}
