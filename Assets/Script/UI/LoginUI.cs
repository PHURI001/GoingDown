using UnityEngine;

public class LoginUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.Instance.LoadScene("Main");
    }

    public void Credit()
    {
        SceneManager.Instance.LoadScene("Credit");
    }
}
