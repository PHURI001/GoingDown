using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class UIButtonFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    RectTransform rect;
    Vector3 originalScale;

    [Header("Hover")]
    public float hoverScale = 1.1f;
    public float hoverSpeed = 10f;

    [Header("Click")]
    public float clickScale = 0.9f;
    public float zoomSpeed = 8f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    bool isHovering = false;
    bool isClicked = false;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        originalScale = rect.localScale;
    }

    void Update()
    {
        if (isClicked) return;

        Vector3 targetScale = isHovering ? originalScale * hoverScale : originalScale;
        rect.localScale = Vector3.Lerp(rect.localScale, targetScale, Time.deltaTime * hoverSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;

        if (audioSource && hoverSound)
            audioSource.PlayOneShot(hoverSound);
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

        if (audioSource && clickSound)
            audioSource.PlayOneShot(clickSound);

        Vector3 shrinkTarget = originalScale * clickScale;

        while (Vector3.Distance(rect.localScale, shrinkTarget) > 0.01f)
        {
            rect.localScale = Vector3.Lerp(rect.localScale, shrinkTarget, Time.deltaTime * zoomSpeed);
            yield return null;
        }

        while (Vector3.Distance(rect.localScale, Vector3.one * 5f) > 0.05f)
        {
            rect.localScale = Vector3.Lerp(rect.localScale, Vector3.one * 5f, Time.deltaTime * zoomSpeed);
            yield return null;
        }
    }
}