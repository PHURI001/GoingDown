using TMPro;
using UnityEngine;

public class UmbrellaCheck : MonoBehaviour
{
    TMP_Text text;

    Umbrella umbrella;

    private void Update()
    {
        if (umbrella == null)
            umbrella = FindAnyObjectByType<Umbrella>();

        if (text == null)
            text = GetComponent<TMP_Text>();

        text.text = Mathf.RoundToInt(umbrella.GetDurability()).ToString();
    }
}
