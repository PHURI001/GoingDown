using UnityEngine;

public class UiIdle : MonoBehaviour
{
    public float amplitude = 10f;
    public float speed = 2f;

    RectTransform rect;
    Vector2 startPos;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        rect.anchoredPosition = startPos + new Vector2(0, y);
    }
}
