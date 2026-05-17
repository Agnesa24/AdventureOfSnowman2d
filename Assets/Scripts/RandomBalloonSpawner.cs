using Unity.Burst.Intrinsics;
using UnityEngine;

public class RandomBalloonSpawner : MonoBehaviour
{

    [SerializeField] private GameObject balloonPrefab;
    //[SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject blackBalloonPrefab;

    private int balloonCount = 0;
    //private int rockCount = 0;
    private int blackBalloonCount = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonPrefab != null && balloonCount < 5)
        {
            var randomPosition = new Vector2(Random.Range(-18f, 17f),Random.Range(-3.86f, 2.65f)); //the first 6 for the x axis, the second one is the y axis 

            GameObject balloon = Instantiate(balloonPrefab, randomPosition, Quaternion.identity);
            balloon.GetComponent<Balloon>().spawner = this;
            balloonCount++;

        }
        //if (rockPrefab != null && rockCount < 5)
        //{
        //    var randomPosition = new Vector2(Random.Range(-18f, 17f),Random.Range(-3.86f, 2.65f)); //the first 6 for the x axis, the second one is the y axis 

        //    GameObject rock = Instantiate(rockPrefab, randomPosition, Quaternion.identity);
        //    rock.GetComponent<rockPrefab>().spawner = this;
        //    rockCount++;

        //}
        if (blackBalloonPrefab != null && blackBalloonCount < 1)
        {
            var randomPosition = new Vector2(Random.Range(-18f, 17f),Random.Range(-3.86f, 2.65f)); //the first 6 for the x axis, the second one is the y axis 
    
            GameObject balloon = Instantiate(blackBalloonPrefab, randomPosition, Quaternion.identity);
            balloon.GetComponent<Balloon>().spawner = this;
           
            blackBalloonCount++;

        }
    }


    //public void DestroyRock()
    //{
    //    rockCount--;
    //}

    public void DestroyBlackBalloon()
    {
        blackBalloonCount--;
    }

    public void BalloonPopped()
    {
        balloonCount--;
    }
}
