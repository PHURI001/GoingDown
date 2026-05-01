using UnityEngine;

public class Win : MonoBehaviour
{
    public void NextGame()
    {
        Time.timeScale = 1f;
        FindAnyObjectByType<Portal>().WonAndNext();
    }

    public void Leave()
    {
        Time.timeScale = 1f;
        FindAnyObjectByType<Portal>().WonAndGoMain();
    }
}
