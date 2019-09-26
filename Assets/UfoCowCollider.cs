using System;
using UnityEngine;

public class UfoCowCollider : MonoBehaviour
{
    private Collider2D coll2D;
    // Start is called before the first frame update
    void Start()
    {
     coll2D = GetComponent<Collider2D>();   
    }

    void OnTriggerEnter2D(Collider2D coll) {
        var tag = coll.gameObject.tag;
         if (tag.Equals("Cow", StringComparison.OrdinalIgnoreCase)) {
            // Figure out why the UFO is still affected by Physics
            Physics2D.IgnoreCollision(coll2D, coll);
            // We got a cow! Add the cow's score value to our running total
            var cow = coll.gameObject.GetComponent<BaseCow>();
            CowScore.playerScore += cow.score;
            Destroy(coll.gameObject);
        }
    }
}
