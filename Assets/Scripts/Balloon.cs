using UnityEngine;

public class Balloon : MonoBehaviour
{
    public WallBalloonRespawn spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly"))
        {
            FindAnyObjectByType<ScoreManager>().AddScore();

            spawner.BalloonPopped();

            Destroy(gameObject);
        }
    }
}