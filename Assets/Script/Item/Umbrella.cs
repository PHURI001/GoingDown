using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerController))]
public class Umbrella : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputReader _inputReader;
    private PlayerController _playerController;

    [Header("Umbrella Settings")]
    [SerializeField] private float maxDurability = 100f;
    [SerializeField] private float durability;
    [SerializeField] private float durabilityDecreaseRate = 10f;

    private bool isUsingUmbrella = false;
    private bool isUmbrellaBroken => durability <= 0;

    // Sprite
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite umbrellaOpenSprite;
    [SerializeField] private Sprite umbrellaCloseSprite;

    [Header("Player Settings")]
    [SerializeField] private float normalSpeedMultiplier = 1f;
    [SerializeField] private float UsingUmbrellaSpeedMultiplier = 0.6f;

    private void Awake()
    {
        durability = maxDurability;

        if (_inputReader == null)
            _inputReader = GetComponent<InputReader>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_inputReader.UmbrellaIsPressed() && !_inputReader.HookIsPressed())
            isUsingUmbrella = true;
        else
            isUsingUmbrella = false;
    }

    private void FixedUpdate()
    {
        if (!isUmbrellaBroken && isUsingUmbrella && durability > 0 && !_playerController.IsOnGround())
        {
            _playerController.SetSpeedMultiplier(UsingUmbrellaSpeedMultiplier);
            UsingUmbrella();
            UmbellaOpen(true);
        }
        else
        {
            _playerController.SetSpeedMultiplier(normalSpeedMultiplier);
            UmbellaOpen(false);
        }
    }

    public void Collect()
    {
        durability = maxDurability;
    }

    [SerializeField] private float fallSpeedLimit = -2f;
    private void UsingUmbrella()
    {
        if (rb.linearVelocity.y < fallSpeedLimit)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fallSpeedLimit);
        }

        durability -= durabilityDecreaseRate * Time.fixedDeltaTime;

        if (isUmbrellaBroken)
        {
            isUsingUmbrella = false;
            Debug.Log("Umbrella Broken!");
        }

        //Debug.Log($"Using umbrella. Durability: {durability}");
    }

    private void UmbellaOpen(bool isOpen)
    {
        if (isOpen)
        {
            spriteRenderer.transform.localPosition = new Vector2(0.25f, 0.4f);
            spriteRenderer.flipY = false;
            spriteRenderer.sprite = umbrellaOpenSprite;
        }
        else
        {
            spriteRenderer.transform.localPosition = new Vector2(-0.25f, -0.4f);
            spriteRenderer.flipY = true;
            spriteRenderer.sprite = umbrellaCloseSprite;
        }
    }
}
