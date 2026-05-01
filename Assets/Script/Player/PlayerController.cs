using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Hook hook;

    private Rigidbody2D rb;
    private InputReader _inputReader;

    private Vector2 movement;

    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private float groundCheckDistance = 1.1f;

    private bool jumpTriggered = false;
    [SerializeField] private bool isGrounded = false;
    //[SerializeField] private bool isMud = false;

    [SerializeField] private SpringJoint2D hookJoint;

    [Header("Environment Settings")]
    [SerializeField] private float mudDrag = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (_inputReader == null)
            _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        LookAtMouse();

        Vector2 input = _inputReader.GetMovement();
        movement = new Vector2(input.x, 0).normalized;

        if (_inputReader.JumpTriggered())
            jumpTriggered = true;
    }

    private void FixedUpdate()
    {
        if (IsHooked()) { MovementWhileHooked(); return; }
        else { hookJoint.enabled = false; }

        Move();

        isGrounded = Physics2D.Raycast(rb.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(rb.position, Vector2.down * groundCheckDistance, Color.red);

        if (jumpTriggered && isGrounded)
        {
            Jump();
        }

        jumpTriggered = false;
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(movement.x * SpeedCalculator(), rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        //Debug.Log("Jumped!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mud"))
        {
            rb.linearDamping = mudDrag;
            //isMud = true;
        }
        else
        {
            rb.linearDamping = 0f;
            //isMud = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mud"))
        {
            rb.linearDamping = 0f;
            //isMud = false;
        }
    }

    public bool IsOnGround()
    {
        return isGrounded;
    }

    private float SpeedCalculator() { return moveSpeed * speedMultiplier; }

    private float speedMultiplier = 1f;
    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = value;
    }

    private void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(_inputReader.GetMouse());

        if (mousePos.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    //public bool CanIHook()
    //{
    //    bool canHook = transform;
    //    //if (isGrounded && !isMud)
    //    //{
    //    //    canHook = true;
    //    //}
    //    return canHook;
    //}

    public bool IsHooked() { return hook.IsHooked(); }

    [Header("Hook Movement Settings")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float maxHorizontalSpeed = 8f;

    [SerializeField] private float distanceAdjustSpeed = 5f;
    [SerializeField] private float MinHookDistance = -1f;
    [SerializeField] private float maxHookDistance = 3f;
    private void MovementWhileHooked()
    {
        hookJoint.enabled = true;

        Vector2 input = _inputReader.GetMovement();

        if (Mathf.Abs(input.x) > 0.1f)
        {
            rb.AddForce(new Vector2(input.x * moveForce, 0f));
        }

        float clampedX = Mathf.Clamp(rb.linearVelocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);
        rb.linearVelocity = new Vector2(clampedX, rb.linearVelocity.y);

        if (Mathf.Abs(input.y) > 0.1f)
        {
            float newDistance = hookJoint.distance;

            if (input.y < 0)
            {
                newDistance += distanceAdjustSpeed * Time.fixedDeltaTime;
            }
            else if (input.y > 0)
            {
                newDistance -= distanceAdjustSpeed * Time.fixedDeltaTime;
            }

            newDistance = Mathf.Clamp(newDistance, MinHookDistance, maxHookDistance);

            hookJoint.distance = newDistance;
        }
    }
}
