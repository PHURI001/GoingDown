using TMPro;
using UnityEngine;

public class StarCheck : MonoBehaviour
{
    TMP_Text text;

    Player player;

    private void Update()
    {
        if (player == null)
            player = FindAnyObjectByType<Player>();
        
        if (text == null)
            text = GetComponent<TMP_Text>();

        text.text = player.Score.ToString();
    }
}
