using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerController))]
public class Umbrella : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputReader _inputReader;
    private PlayerController _playerController;

    [SerializeField] private float maxDurability = 100f;
    [SerializeField] private float durability;
    [SerializeField] private float durabilityDecreaseRate = 10f;

    private bool isUsingUmbrella = false;
    private bool isUmbrellaBroken => durability <= 0;

    private void Awake()
    {
#warning "Don't forget to ask the game designer to be sure."
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
        if (_inputReader.UmbrellaIsPressed())
            isUsingUmbrella = true;
        else
            isUsingUmbrella = false;
    }

    private void FixedUpdate()
    {
        if (!isUmbrellaBroken && isUsingUmbrella && durability > 0 && !_playerController.IsOnGround())
        {
            UsingUmbrella();
        }
    }

    public void Collect()
    {
        durability = maxDurability;
    }

#warning "Please continue working here."
    private void UsingUmbrella()
    {
        // logic to reduce fall speed, e.g., by applying an upward force or modifying gravity

        durability -= durabilityDecreaseRate * Time.fixedDeltaTime;

        if (isUmbrellaBroken)
        {
            // Handle umbrella breakage (e.g., play sound, show visual effect)
        }

        Debug.Log($"Using umbrella. Durability: {durability}");
    }
}
