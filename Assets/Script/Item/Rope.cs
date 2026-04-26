using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    [Header("Points")]
    public Transform startPoint;
    public Transform endPoint;

    private LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.useWorldSpace = true;

        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

        if (line.material == null)
        {
            line.material = new Material(Shader.Find("Sprites/Default"));
        }
    }

    void Update()
    {
        if (startPoint == null || endPoint == null) return;

        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, endPoint.position);
    }
}