using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Awake()
    {
        if (player == null)
            player = FindFirstObjectByType<Player>();
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(0, player.transform.position.y, Camera.main.transform.position.z);
    }
}
