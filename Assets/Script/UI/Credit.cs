using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour
{
    public ZoomInAndOut zoom;

    public void Back()
    {
        StartCoroutine(BackToLogin());
    }

    IEnumerator BackToLogin()
    {
        yield return zoom.ExpandFromCenter(0.4f);
        SceneManager.Instance.LoadScene("Login");
    }
}