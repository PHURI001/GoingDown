using UnityEngine;

public class Portal : MonoBehaviour
{
    public int PassLevel = 1;
    public string LevelSelectScene = "Main";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Win();
            }
        }
    }

    public void WonAndWarp()
    {
        PlayerData.Instance.UnlockLevel(PassLevel + 1);
        SceneManager.Instance.LoadScene(LevelSelectScene);
    }
}
