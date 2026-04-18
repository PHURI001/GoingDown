using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private float groundCheckDistance = 1.25f;

    private bool jumpTriggered = false;
    [SerializeField] private bool isGrounded = false;

    private GameInput _input;
    private GameInput.PlayerActions _player;

    private void Awake()
    {
        _input = new GameInput();
        _player = _input.Player;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 input = _player.Move.ReadValue<Vector2>();
        movement = new Vector2(input.x, 0).normalized;

        if (_player.Jump.triggered)
            jumpTriggered = true;
    }

    private void FixedUpdate()
    {
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
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        //Debug.Log("Jumped!");
    }
}
