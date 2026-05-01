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

    public void WonAndGoMain()
    {
        PlayerData.Instance.UnlockLevel(PassLevel);
        SceneManager.Instance.LoadScene(LevelSelectScene);
    }

    public void WonAndNext()
    {
        PlayerData.Instance.UnlockLevel(PassLevel);
        SceneManager.Instance.LoadScene("Level0" + (PassLevel + 1));
    }
}
