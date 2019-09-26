using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaming : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "BasicCow")
        {
            Rigidbody2D cowRb = collision.gameObject.GetComponent<Rigidbody2D>();
            cowRb.position = new Vector2(cowRb.position.x, cowRb.position.y + 0.5f);
        }
    }
}
