using UnityEngine;

public class Balloon : MonoBehaviour
{
    public RandomBalloonSpawner spawner;


    /*for sounds*/
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip yellowBalloonSound;
    [SerializeField] private AudioClip blackBalloonSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly") && gameObject.CompareTag("blackBalloon"))
        {
            FindAnyObjectByType<ScoreManager>().SubtractScore();
            spawner.DestroyBlackBalloon();

            audioSource.PlayOneShot(blackBalloonSound);
        }
        else if (collision.CompareTag("purly") && gameObject.CompareTag("balloonTag"))
        {
            FindAnyObjectByType<ScoreManager>().AddScore();
            spawner.BalloonPopped();

            audioSource.PlayOneShot(yellowBalloonSound);
        }

        Destroy(gameObject);
    }
}