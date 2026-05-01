using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 3;

    public GameObject GameWin;
    public GameObject GameOver;

    public void TakeDamage()
    {
        //Debug.Log("Player takes damage!");
        Health--;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 0f;
        GameOver.SetActive(true);
        //Debug.Log("Player has died.");
    }

    public void Win()
    {
        Time.timeScale = 0f;
        GameWin.SetActive(true);
        //Debug.Log("Player wins!");
    }
}
