using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 10f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameEndSound;

    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("purly"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
            GameData.SaveScore(playerName);

            Destroy(collision.gameObject);

            StartCoroutine(PlaySoundAndLoad());
        }
    }

    private IEnumerator PlaySoundAndLoad()
    {
        audioSource.PlayOneShot(gameEndSound);

        yield return new WaitForSeconds(gameEndSound.length);

        SceneManager.LoadScene("MenuScene");
    }
}