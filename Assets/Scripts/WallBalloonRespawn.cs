using UnityEngine;
using UnityEngine.SceneManagement;

public class WallBalloonRespawn : MonoBehaviour
{
    public GameObject balloonPrefab;

    public Vector2 minSpawn;
    public Vector2 maxSpawn;

    private GameObject currentBalloon;

    void Start()
    {
        SpawnBalloon();
    }

    void SpawnBalloon()
    {
        Vector2 pos = new Vector2(
            Random.Range(minSpawn.x, maxSpawn.x),
            Random.Range(minSpawn.y, maxSpawn.y)
        );

        currentBalloon = Instantiate(balloonPrefab, pos, Quaternion.identity);

        currentBalloon.GetComponent<Balloon>().spawner = this;
    }

    public void BalloonPopped()
    {
        Invoke(nameof(SpawnBalloon), 2f);
    }
}
