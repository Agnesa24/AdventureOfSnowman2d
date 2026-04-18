using UnityEngine;

public class WallBalloonRespawn : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Transform wallSpawnPoint;

    private bool popped = false;

   /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly") && !popped)
        {
            popped = true;
            GameData.score++;
            FindAnyObjectByType<ScoreManager>().AddScore();

            // Delay destroy to match the spawn delay
            Invoke(nameof(SpawnNewBalloon), 2f);
            Invoke(nameof(DestroySelf), 2f); // destroy AFTER spawn
        }
    }*/

    void SpawnNewBalloon()
    {
        //Vector3 spawnPos = wallSpawnPoint.position;
        //spawnPos.z = 0;
        //spawnPos += wallSpawnPoint.up * 0.5f;
        Instantiate(balloonPrefab, wallSpawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly") && !popped)
        {
            popped = true;
            FindAnyObjectByType<ScoreManager>().AddScore(); // handles GameData.score++ too
            Invoke(nameof(SpawnNewBalloon), 2f);
            Invoke(nameof(HideBalloon), 0f); // hide immediately
        }
    }

    void HideBalloon()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
