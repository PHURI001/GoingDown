using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputReader))]
public class LookingAt : MonoBehaviour
{
    InputReader _inputReader;
    private Vector2 mousePosition;
    private float angle;
    private Vector2 _direction;

    private void Awake()
    {
        if (_inputReader == null)
            _inputReader = this.gameObject.GetComponent<InputReader>();
    }
    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(_inputReader.GetMouse());
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

        Debug.DrawRay(transform.position, _direction, Color.red);
    }

    public Vector2 LookAtPosition()
    {
        return _direction;
    }
}
