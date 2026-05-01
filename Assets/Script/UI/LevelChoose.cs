using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelChoose : MonoBehaviour
{
    PlayerData playerData;

    public Button[] levelButtons;
    public ZoomInAndOut zoom;

    private void Start()
    {
        playerData = PlayerData.Instance;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int index = i;

            if (playerData.LevelUnlock[i])
            {
                levelButtons[i].interactable = true;

                var lockObj = levelButtons[i].transform.Find("Lock");
                if (lockObj != null) lockObj.gameObject.SetActive(false);

                levelButtons[i].onClick.AddListener(() =>
                {
                    StartCoroutine(LoadLevel("Level0" + (index + 1)));
                });
            }
            else
            {
                levelButtons[i].interactable = false;

                var lockObj = levelButtons[i].transform.Find("Lock");
                if (lockObj != null) lockObj.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return zoom.ExpandFromCenter(0.4f);
        SceneManager.Instance.LoadScene(sceneName);
    }

    public void BackToLogin()
    {
        StartCoroutine(Back());
    }

    IEnumerator Back()
    {
        yield return zoom.ExpandFromCenter(0.4f);
        SceneManager.Instance.LoadScene("Login");
    }
}