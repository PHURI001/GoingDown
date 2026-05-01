using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class UIButtonFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    RectTransform rect;
    Vector3 originalScale;

    public float hoverScale = 1.1f;
    public float hoverSpeed = 10f;

    public float clickScale = 0.9f;
    public float clickSpeed = 12f;

    public AudioSource audioSource;
    public AudioClip clickSound;

    public bool IsFinished { get; private set; }

    bool isHovering;
    bool isClicked;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        originalScale = rect.localScale;
        IsFinished = false;
    }

    void Update()
    {
        if (isClicked) return;

        Vector3 target = isHovering ? originalScale * hoverScale : originalScale;
        rect.localScale = Vector3.Lerp(rect.localScale, target, Time.deltaTime * hoverSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked)
            StartCoroutine(ClickEffect());
    }

    IEnumerator ClickEffect()
    {
        isClicked = true;
        IsFinished = false;

        if (audioSource && clickSound)
            audioSource.PlayOneShot(clickSound);

        Vector3 shrink = originalScale * clickScale;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * clickSpeed;
            rect.localScale = Vector3.Lerp(originalScale, shrink, t);
            yield return null;
        }

        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * clickSpeed;
            rect.localScale = Vector3.Lerp(shrink, originalScale, t);
            yield return null;
        }

        IsFinished = true;
        isClicked = false;
    }
}