using UnityEngine;
using System.Collections;

public class LoginUI : MonoBehaviour
{
    public UIButtonFX playButton;
    public UIButtonFX creditButton;

    public ZoomInAndOut zoom;

    void Start()
    {
        StartCoroutine(BindButtons());
    }

    IEnumerator BindButtons()
    {
        yield return new WaitUntil(() => playButton != null && creditButton != null);

        playButton.StartCoroutine(Handle(playButton, "Main"));
        creditButton.StartCoroutine(Handle(creditButton, "Credit"));
    }

    IEnumerator Handle(UIButtonFX btn, string scene)
    {
        yield return new WaitUntil(() => btn.IsFinished);

        yield return zoom.ExpandFromCenter(0.4f);

        SceneManager.Instance.LoadScene(scene);
    }
}