using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LookingAt))]
[RequireComponent(typeof(InputReader))]
public class GrapplingHook : MonoBehaviour
{
    private Rigidbody2D rb;
    private LookingAt _lookingAt;
    private InputReader _inputReader;

    [Header("Hook Settings")]
    [SerializeField] private float hookRange = 10f; // Maximum distance the hook can reach
    [SerializeField] private float hookDistance = 0f; // Distance between the hook point and the edge of hook
    [SerializeField] private float hookPullSpeed = 5f;

    private bool isHook = false; // Whether the player is Pressing the hook button
    private bool Hooking = false; // Whether the player is currently using the hook (e.g., swinging or pulling towards a point)

    [Header("Other")]
    [SerializeField] private GameObject GrapplingHookModel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (_lookingAt == null)
            _lookingAt = this.gameObject.GetComponent<LookingAt>();

        if (_inputReader == null)
            _inputReader = this.gameObject.GetComponent<InputReader>();

        if (GrapplingHookModel == null)
            Debug.LogError("GrapplingHookPrefab is not assigned in the inspector.");
    }

    private void Update()
    {
        if (_inputReader.HookIsPressed() && !Hooking)
        {
            isHook = true;
        }
    }

    private void FixedUpdate()
    {
        if (isHook)
        {
            UseGrapplingHook();
        }
    }

    private void UseGrapplingHook()
    {
#warning "Please continue working here."
        Vector2 lookingAt = _lookingAt.LookAtPosition();
        Vector2 hookDirection = lookingAt - rb.position;
    }
}
