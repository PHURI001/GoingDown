using UnityEngine;

public class Credit : MonoBehaviour
{
    public void Back()
    {
        SceneManager.Instance.LoadScene("Login");
    }
}
