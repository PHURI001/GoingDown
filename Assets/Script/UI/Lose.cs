using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour
{
    public ZoomInAndOut zoom;

    public void RestartGame()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        Time.timeScale = 1f;

        yield return zoom.ExpandFromCenter(0.4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void Leave()
    {
        StartCoroutine(LeaveToMain());
    }

    IEnumerator LeaveToMain()
    {
        Time.timeScale = 1f;

        yield return zoom.ExpandFromCenter(0.4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}