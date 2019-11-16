using UnityEngine;

public class BaseCow : MonoBehaviour
{
    public float speed;
    public int score;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb2D;
    private float deathTimer = 3.0f;
    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
        rb2D = GetComponent<Rigidbody2D> ();
    }

    void Start() {
        score = 1;
        speed = Random.Range(1f, 5f);
        var movement = Random.value > 0.5f ? Vector2.left * speed : Vector2.right * speed;

        bool flipSprite = (spriteRenderer.flipX ? (movement.x < 0.01f) : (movement.x > 0.01f));
        if (flipSprite) 
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        rb2D.velocity = movement;
    }

    void Update() {
        deathTimer -= Time.deltaTime;
        if (deathTimer < 0.0f) {
            Destroy(this);
        }
    }
}
