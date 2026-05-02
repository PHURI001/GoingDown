using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class Falling : MonoBehaviour
{
    Rigidbody2D rb;

    public float gravityAcceleration = 9.81f;
    public float extraGravityMultiplier = 2f;
    public float maxFallSpeed = -25f;
    public float damageThreshold = -14f;
    public LayerMask groundLayer;

    public Player player;
    public AudioSource audioSource;

    float lastVelocityY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        lastVelocityY = rb.linearVelocity.y;

        // ถ้ากำลังตก
        if (rb.linearVelocity.y < 0)
        {
            float mass = rb.mass;

            float force = mass * gravityAcceleration;

            force *= extraGravityMultiplier;

            rb.AddForce(Vector2.down * force, ForceMode2D.Force); //Projectile F=ma, Falling
        }

        // simmu air resistance 
        if (rb.linearVelocity.y < maxFallSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxFallSpeed);
        }
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
