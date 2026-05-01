using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 3;

    public void TakeDamage()
    {
        Debug.Log("Player takes damage!");
        Health--;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died.");
    }
}
