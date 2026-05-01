using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour
{
    public ZoomInAndOut zoom;

    public void NextGame()
    {
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        Time.timeScale = 1f;

        yield return zoom.ExpandFromCenter(0.4f);

        FindAnyObjectByType<Portal>().WonAndNext();
    }

    public void Leave()
    {
        StartCoroutine(BackToMain());
    }

    IEnumerator BackToMain()
    {
        Time.timeScale = 1f;

        yield return zoom.ExpandFromCenter(0.4f);

        FindAnyObjectByType<Portal>().WonAndGoMain();
    }
}