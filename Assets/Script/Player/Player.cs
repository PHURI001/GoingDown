using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 3;
    public int Score = 0;

    public GameObject GameWin;
    public GameObject GameOver;
    public TMP_Text ScoreText;

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
        Score = 0;
        GameOver.SetActive(true);
        //Debug.Log("Player has died.");
    }

    public void Win()
    {
        Time.timeScale = 0f;
        GameWin.SetActive(true);
        ScoreText.text = Score.ToString();
        //Debug.Log("Player wins!");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            Score++;
            //Debug.Log("Score: " + Score);
            Destroy(collision.gameObject);
        }
    }
}
