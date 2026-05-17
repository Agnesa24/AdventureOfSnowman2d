using UnityEngine;
using UnityEngine.SceneManagement;

public class meltPurly : MonoBehaviour
{
    //for audio 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameEndSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(gameEndSound);
            SceneManager.LoadScene("MenuScene");
        }
    }
}
