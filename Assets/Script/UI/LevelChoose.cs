using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour
{
    PlayerData playerData;

    public Button[] levelButtons;

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
                    SceneManager.Instance.LoadScene("Level0" + (index + 1));
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
}
