using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Umbrella : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float maxDurability = 100f;
    [SerializeField] private float durability;
    [SerializeField] private float durabilityDecreaseRate = 10f;

    private bool isUsingUmbrella = false;
    private bool isUmbrellaBroken => durability <= 0;

    GameInput _input;
    GameInput.PlayerActions _player;

    private void Awake()
    {
        _input = new GameInput();
        _player = _input.Player;

#warning "Don't forget to ask the game designer to be sure."
        durability = maxDurability;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_player.Umbrella.IsPressed()) 
            isUsingUmbrella = true;
        else
            isUsingUmbrella = false;
    }

    private void FixedUpdate()
    {
        if (!isUmbrellaBroken && isUsingUmbrella && durability > 0)
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
    }
}
