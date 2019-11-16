using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed = 2f;
    public float force = 300f;

    public GameObject playerBeam;

    private Rigidbody2D rb2D;
    private Collider2D coll2D;
    // Use this for initialization

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    void Start () {    
        // Fly towards the right
        dragDistance = Screen.height * 20 / 100; //dragDistance is 20% height of the screen
        rb2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
        toggleBeam(false);

        rb2D.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update () {
        checkUserInput();
        rb2D.velocity = Vector2.right * speed;
    }

    
    private void jump() {
        rb2D.AddForce(Vector2.up * force);
    }

    private void toggleBeam(bool? activate = null) {
        playerBeam.SetActive(activate ?? !playerBeam.activeSelf);
    }


    void OnCollisionEnter2D(Collision2D coll) {
        var tag = coll.gameObject.tag;
        if (tag.Equals("Terrain", StringComparison.OrdinalIgnoreCase)) {
            // Restart
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }

    private void checkUserInput() {
        detectTouch();
        // Jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump();
        } else if (Input.GetKeyDown(KeyCode.B)) {
            // Beam is activated
            toggleBeam();
        }
    }

    private void detectTouch()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                    if (lp.y > fp.y)  //If the movement was up
                    {   //Up swipe
                        toggleBeam(false);
                    }
                    else
                    {   //Down swipe
                        toggleBeam(true);
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    jump();
                }
            }
        }
    }
}