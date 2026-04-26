using Unity.Burst.Intrinsics;
using UnityEngine;

public class RandomBalloonSpawner : MonoBehaviour
{

    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private GameObject rockPrefab;
    private int balloonCount = 0;
    private int rockCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonPrefab != null && balloonCount < 5)
        {
            var randomPosition = new Vector2(Random.Range(-6.78f, 6.57f), Random.Range(-3.86f, 2.65f)); //the first 6 for the x axis, the second one is the y axis 

            GameObject balloon = Instantiate(balloonPrefab, randomPosition, Quaternion.identity);
            balloon.GetComponent<Balloon>().spawner = this;
            balloonCount++;

        }
        if (rockPrefab != null && rockCount < 5)
        {
            var randomPosition = new Vector2(Random.Range(-6.78f, 6.57f), Random.Range(-3.86f, 2.65f)); //the first 6 for the x axis, the second one is the y axis 

            GameObject rock = Instantiate(rockPrefab, randomPosition, Quaternion.identity);
            rock.GetComponent<rockPrefab>().spawner = this;
            rockCount++;

        }
    }


    public void DestroyRock()
    {
        rockCount--;
    }
    public void BalloonPopped()
    {
        balloonCount--;
    }
}
