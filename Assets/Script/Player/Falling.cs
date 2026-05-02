using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class Falling : MonoBehaviour
{
    Rigidbody2D rb;

    public float extraFallForce = 30f;
    public float maxFallSpeed = -25f;
    public float damageThreshold = -14f;
    public LayerMask groundLayer;

    public Player player;

    float lastVelocityY;

    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        lastVelocityY = rb.linearVelocity.y;

        if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Vector2.down * extraFallForce, ForceMode2D.Force); //Gravity F=ma ,Falling
        }

        if (rb.linearVelocity.y < maxFallSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxFallSpeed);
        }

        //Debug.Log("rb.linearVelocity.y.ToString("F2"));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0 || collision.gameObject.CompareTag("Mud"))
        {
            if (lastVelocityY <= damageThreshold)
            {
                audioSource.Play();
                player.TakeDamage();
            }
        }
    }
}
