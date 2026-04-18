using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 10f;

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
            SceneManager.LoadScene("MenuScene");
        }
    }
}