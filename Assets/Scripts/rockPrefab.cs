using UnityEngine;

public class rockPrefab : MonoBehaviour
{
    public RandomBalloonSpawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly"))
        {
            spawner.DestroyRock(); 
            Destroy(gameObject);
        }
    }
}
