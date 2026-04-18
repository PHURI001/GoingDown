using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class LookingAt : MonoBehaviour
{
    private Vector2 mousePosition;
    private float angle;
    private Vector2 _direction;
    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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
