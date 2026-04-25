using UnityEngine;

public class Item_Umbrella : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Umbrella inventory = collision.GetComponent<Umbrella>();
            if (inventory != null)
            {
                inventory.Collect();
                Destroy(gameObject);
            }
        }
    }
}
