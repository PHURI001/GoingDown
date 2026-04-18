using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private GameInput _input;
    private GameInput.PlayerActions _player;

    private void Awake()
    {
        _input = new GameInput();
        _player = _input.Player;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public Vector2 GetMouse() { return Mouse.current.position.ReadValue(); }
    public Vector2 GetMovement() { return _player.Move.ReadValue<Vector2>(); }
    public bool JumpTriggered() { return _player.Jump.triggered; }
}
