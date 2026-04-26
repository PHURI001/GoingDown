using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hook : MonoBehaviour
{
    //[SerializeField] private PlayerController player;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private InputReader _inputReader;

    [Header("Hook Settings")]
    //[SerializeField] private float distanceNormal = 0.05f;
    //[SerializeField] private float distanceWhileUsing = 5f;

    private bool isHooking = false;
    private bool isHooked = false;

    [SerializeField] private SpringJoint2D hookJoint;

    void Awake()
    {
        //if (player == null)
        //    player = FindFirstObjectByType<PlayerController>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        if (_inputReader == null)
            _inputReader = FindFirstObjectByType<InputReader>();
        if (hookJoint == null)
            hookJoint = GetComponent<SpringJoint2D>();
    }
    private void Update()
    {
        //if (_inputReader.IsJump())
        //{
        //    Unhooking();
        //    return;
        //}

        if (_inputReader.HookIsPressed() && !_inputReader.UmbrellaIsPressed())
        {
            Hooking();
            isHooking = true;
        }
        else
        {
            Unhooking();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHooking && !isHooked && !collision.CompareTag("Mud") && !collision.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            isHooked = true;
        }
    }

    private void Hooking()
    {
        hookJoint.frequency = 1f;
    }

    private void Unhooking()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        hookJoint.frequency = 0f;
        isHooked = false;
    }

    public bool IsHooked() { return isHooked; }
}
