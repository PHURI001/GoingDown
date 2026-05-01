using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] healthBar;

    public Player player;

    private void Update()
    {
        if (player == null)
            player = FindAnyObjectByType<Player>();
        for (int i = 0; i < healthBar.Length; i++)
        {
            if (i < player.Health)
                healthBar[i].SetActive(true);
            else
                healthBar[i].SetActive(false);
        }
    }
}
