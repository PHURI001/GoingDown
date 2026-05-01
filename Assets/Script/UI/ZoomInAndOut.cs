using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInAndOut : MonoBehaviour
{
    public RectTransform centerPoint;
    public Image img;

    void Start()
    {
        img.enabled = true;
        StartCoroutine(ShrinkToCenter(0.4f));
    }

    public IEnumerator ExpandFromCenter(float duration, Action<bool> onDone = null)
    {
        RectTransform rt = img.rectTransform;

        rt.anchoredPosition = Vector2.zero;
        rt.localScale = Vector3.zero;
        img.enabled = true;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = t / duration;
            rt.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, normalized);
            yield return null;
        }

        rt.localScale = Vector3.one;

        onDone?.Invoke(true);
    }

    public IEnumerator ShrinkToCenter(float duration, Action<bool> onDone = null)
    {
        RectTransform rt = img.rectTransform;

        rt.anchoredPosition = Vector2.zero;
        rt.localScale = Vector3.one;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = t / duration;
            rt.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, normalized);
            yield return null;
        }

        rt.localScale = Vector3.zero;
        img.enabled = false;

        onDone?.Invoke(true);
    }
}